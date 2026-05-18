---
uid: core-page-objects
title: Page objects
---

# Page objects

Page objects are a design pattern for UI test automation where each page (or screen, or significant section) in your application is represented by a class. That class encapsulates the element locators and interaction logic for the page, so your test methods read like descriptions of user behavior rather than low-level driver calls.

The pattern solves three problems that make raw Selenium tests painful to maintain:

1. **Duplication.** Without page objects, every test that interacts with the login form duplicates the same `FindElement` and `SendKeys` calls. When a locator changes, you fix it in dozens of places.
2. **Readability.** `new LoginPage().Login("user", "pass")` communicates intent. `app.FindElement(By.Id("usr")).SendKeys("user")` communicates implementation.
3. **Fragility.** When the UI changes, you update the page object once. Every test that uses it continues to work.

Legerity provides [`BasePage`](xref:Legerity.Pages.BasePage) as the foundation for your page objects.

## Creating a page object

A page object extends `BasePage` and implements the `Trait` property. The trait is a `By` locator that identifies an element that is always present when the page is active. Legerity uses this to validate that the page has loaded.

```csharp
public class LoginPage : BasePage
{
    private readonly By usernameLocator = By.Id("usernameInput");
    private readonly By passwordLocator = By.Id("passwordInput");
    private readonly By loginButtonLocator = By.Id("loginButton");

    protected override By Trait => loginButtonLocator;

    public WebElement UsernameInput => App.FindElement(usernameLocator);
    public WebElement PasswordInput => App.FindElement(passwordLocator);
    public WebElement LoginButton => App.FindElement(loginButtonLocator);

    public HomePage Login(string username, string password)
    {
        UsernameInput.SendKeys(username);
        PasswordInput.SendKeys(password);
        LoginButton.Click();
        return new HomePage();
    }
}
```

Key decisions in this example:

- **Element properties are computed** (`=> App.FindElement(...)`) rather than stored. This ensures each access fetches the current element from the driver, avoiding stale element references.
- **Interaction methods return the next page object.** `Login()` returns `HomePage`, enabling test code to chain page navigations fluently.
- **Locators are private fields.** The test doesn't need to know how elements are found, only what interactions are available.

## Using page objects in tests

```csharp
public class LoginTests : BaseTestClass
{
    [SetUp]
    public void SetUp() => StartApp();

    [TearDown]
    public void TearDown() => StopApp();

    [Test]
    public void ShouldNavigateToHomeAfterLogin()
    {
        var homePage = new LoginPage().Login("admin", "password123");
        Assert.That(homePage.IsLoggedIn(), Is.True);
    }

    [Test]
    public void ShouldShowErrorOnInvalidCredentials()
    {
        var loginPage = new LoginPage();
        loginPage.Login("wrong", "credentials");

        loginPage.VerifyElementShown(By.Id("errorMessage"));
    }
}
```

Compare this to the same tests without page objects:

```csharp
[Test]
public void ShouldNavigateToHomeAfterLogin()
{
    App.FindElement(By.Id("usernameInput")).SendKeys("admin");
    App.FindElement(By.Id("passwordInput")).SendKeys("password123");
    App.FindElement(By.Id("loginButton")).Click();

    Assert.That(App.FindElement(By.Id("loggedInText")).Displayed, Is.True);
}
```

The page object version is shorter, clearer, and only breaks if the login flow itself changes, not if a locator ID is renamed.

## Page validation with traits

When you construct a page object, `BasePage` automatically waits for the `Trait` element to appear. If the trait element isn't found within the `WaitTimeout` (defaults to 2 seconds), a `PageNotShownException` is thrown.

```csharp
// This waits up to 2 seconds for the loginButton to appear
var loginPage = new LoginPage();
```

You can customize the timeout in the constructor:

```csharp
public class SlowLoadingPage : BasePage
{
    public SlowLoadingPage() : base()
    {
        WaitTimeout = TimeSpan.FromSeconds(10);
    }

    protected override By Trait => By.Id("mainContent");
}
```

You can also explicitly verify a page is shown at any point:

```csharp
var page = new LoginPage();
page.VerifyPageShown(TimeSpan.FromSeconds(5));
```

## Finding elements within pages

`BasePage` exposes `FindElement` and `FindElements` methods that delegate to the current driver:

```csharp
public class SearchResultsPage : BasePage
{
    protected override By Trait => By.Id("results");

    public WebElement SearchBox => FindElement(By.Id("searchBox"));
    public IReadOnlyCollection<WebElement> ResultItems => FindElements(By.ClassName("result-item"));

    public int ResultCount => ResultItems.Count;
}
```

## Combining page objects with element wrappers

Page objects become even more powerful when you use [element wrappers](xref:core-element-wrappers) for your element properties. Instead of returning raw `WebElement` instances, you return typed wrappers that expose rich interaction APIs.

```csharp
public class AddPersonPage : BasePage
{
    protected override By Trait => ByExtras.Text("Add Person");

    public TextInput NameInput => App.FindElement(By.Id("nameInput"));
    public Select GenderSelect => App.FindElement(By.Id("genderSelect"));
    public DateInput DateOfBirthInput => App.FindElement(By.Id("dateOfBirthInput"));
    public Button SaveButton => App.FindElement(By.Id("saveButton"));

    public PersonDetailPage AddPerson(string name, string gender, DateTime dateOfBirth)
    {
        NameInput.SetText(name);
        GenderSelect.SelectOptionByDisplayValue(gender);
        DateOfBirthInput.SetDate(dateOfBirth);
        SaveButton.Click();
        return new PersonDetailPage();
    }
}
```

The implicit operators on element wrappers handle the cast from `WebElement` to the wrapper type automatically. You get `SetText()`, `SelectOptionByDisplayValue()`, and `SetDate()` instead of the raw `SendKeys()` and `Click()` calls.

## Page-to-page navigation

A common pattern is to have interaction methods return the page object for the next page. This creates a fluent chain that mirrors the user's journey:

```csharp
[Test]
public void ShouldCompleteCheckoutFlow()
{
    var confirmationPage = new LoginPage()
        .Login("user", "pass")       // returns HomePage
        .GoToCart()                   // returns CartPage
        .Checkout()                   // returns CheckoutPage
        .ConfirmOrder();              // returns ConfirmationPage

    Assert.That(confirmationPage.OrderNumber, Is.Not.Empty);
}
```

Each page's interaction method is responsible for performing the action and returning the resulting page. This keeps navigation logic out of your test methods entirely.

## Accessing platform-specific drivers

`BasePage` provides typed driver properties for when you need platform-specific APIs:

```csharp
public class WindowsSettingsPage : BasePage
{
    protected override By Trait => By.Name("Settings");

    public void ResizeWindow(int width, int height)
    {
        WindowsApp.Manage().Window.Size = new Size(width, height);
    }
}
```

Available driver properties: `App` (base `WebDriver`), `WindowsApp`, `AndroidApp`, `IOSApp`, `WebApp`.

## Best practices

- **One page object per page or significant UI section.** Don't create monolithic page objects that cover multiple pages.
- **Keep element properties computed, not cached.** Use `=>` (expression body) instead of `=` (field initializer) to avoid stale element references.
- **Return the next page from interaction methods.** This enables fluent test code and makes navigation explicit.
- **Use the `Trait` to pick a reliable, always-present element.** Good traits are page titles, navigation elements, or form containers. Avoid traits that are conditionally visible.
- **Combine with element wrappers.** Typed wrappers make page object code more expressive and reduce the amount of low-level interaction logic in each method.
