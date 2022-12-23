---
uid: using_legerity_page_objects
title: Page Objects
---

# Page objects

Page objects are a great way to abstract away the UI test code that is required to perform interactions with a specific page in your application.

The page object is a standard design pattern in UI test automation for improving the maintainability of your tests by reducing the duplication of interaction code.

When you use page objects across all your tests, you can start to write the tests in a more declarative way, which makes them easier to read and understand.

Plus, if your UI changes, you only need to update the page object and not all your tests.

## Understanding the Base Page object in Legerity

Legerity offers a [`BasePage`](xref:Legerity.Pages.BasePage) class as a part of the Core package and provides a starting point for creating pages objects for your application pages.

The base page wraps your application driver, and provides easy-to-use methods for finding elements and performing interactions with them.

> [!NOTE]
> When paired with [element wrappers](xref:using_legerity_element_wrappers), you can start to build a page object model that is even easier to maintain with the additional abstraction of element interactions.

## Creating a page object

Before diving into a page object, let's first look at what a test looks like without a page object.

```csharp
public class LoginTests : LegerityTestClass
{
    [Test]
    public void ShouldLoginSuccessfully()
    {
        this.App.FindElement(By.Id("usernameInput")).SendKeys("username");
        this.App.FindElement(By.Id("passwordInput")).SendKeys("password");
        this.App.FindElement(By.Id("loginButton")).Click();

        Assert.IsTrue(this.App.FindElement(By.Id("loggedInText")).Displayed);
    }
}
```

Although concise, there are a few challenges with this approach.

1. Login may be a common action in your application, so you may want to reuse this code across multiple tests. The current format would require you to copy and paste this code into each test.
2. This test combines both the location of the element with the interaction. If you need to change the interaction model or locator, you would need to update all the tests that use this code.
3. Reading the test code to understand what is happening is not as straight forward as it could be, as from a top level, you need to understand the interaction model and the element locator.

With Legerity's page object model, you can start to abstract away the interaction code and make it easier to reuse across multiple tests.

```csharp
public class LoginPage : BasePage
{
    private readonly By loginButtonLocator = By.Id("loginButton");

    public LoginPage(RemoteWebDriver app)
        : base(app)
    {
    }

    protected override By Trait => loginButtonLocator;

    public RemoteWebElement UsernameInput => this.App.FindElement(By.Id("usernameInput"));
    public RemoteWebElement PasswordInput => this.App.FindElement(By.Id("passwordInput"));
    public RemoteWebElement LoginButton => this.App.FindElement(loginButtonLocator);

    public HomePage Login(string username, string password)
    {
        this.UsernameInput.SendKeys(username);
        this.PasswordInput.SendKeys(password);
        this.LoginButton.Click();

        return new HomePage(this.App);
    }
}

public class HomePage : BasePage
{
    private readonly By loggedInTextLocator = By.Id("loggedInText");

    public HomePage(RemoteWebDriver app)
        : base(app)
    {
    }

    protected override By Trait => loggedInTextLocator;

    public RemoteWebElement LoggedInText => this.App.FindElement(loggedInTextLocator);

    public bool IsLoggedIn()
    {
        return this.LoggedInText.Displayed;
    }
}

public class LoginTests : LegerityTestClass
{
    [Test]
    public void ShouldNavigateToHomePageAfterLogin()
    {
        HomePage homePage = new LoginPage(this.App).Login("username", "password");
        Assert.IsTrue(homePage.IsLoggedIn());
    }
}
```

With this page object, you can start to reuse it across your tests using the abstracted interaction logic.

> [!NOTE]
> In the example page object, page interactions return a page object. This allows you to chain interactions together, which can make it easier to follow the flow of a test. You can even use page object methods to chain page-to-page navigation within your tests.

You can also start to see how the page object can be used to improve the readability of your tests. It allows you to focus on writing tests that meet your functional requirements, rather than the implementation details of how to interact with the UI.

### The page object trait

The page object `Trait` is a property that is used to determine if the page is in a valid state by locating an element that is **always** present on the page.

When you create a page object, you will need to implement the `Trait` property to provide a locator that can be used to determine if the page is in a valid state.

This `Trait` is used during the construction of the page object using the `WaitTimeout` that you can also configured in the constructor. By default, the `WaitTimeout` is set to 2 seconds.

## Combining page objects with element wrappers

Where complex interaction logic is required for elements on a page, you can start to use [element wrappers](xref:using_legerity_element_wrappers) to abstract away this too.

This can help to reduce the amount of code that you need to write in your page objects, and also make it easier to maintain them.

```csharp
public class AddPersonPage : BasePage
{
    public AddPersonPage(RemoteWebDriver app)
        : base(app)
    {
    }

    protected override By Trait => ByExtras.Text("Add Person");

    public TextInput NameInput => this.App.FindElement(By.Id("nameInput"));
    public Select GenderSelect => this.App.FindElement(By.Id("genderSelect"));
    public DateInput DateOfBirthInput => this.App.FindElement(By.Id("dateOfBirthInput"));
    public Button SaveButton => this.App.FindElement(By.Id("saveButton"));

    public PersonDetailPage AddPerson(string name, string gender, DateTime dateOfBirth)
    {
        this.NameInput.SetText(name);
        this.GenderSelect.SelectOptionByDisplayValue(gender);
        this.DateOfBirthInput.SetDate(dateOfBirth);
        this.SaveButton.Click();

        return new PersonDetailPage(this.App);
    }
}
```

In this example, all the underlying common interaction for elements like `Select` and `DateInput` are abstracted away in the element wrapper, so you only need to write the logic for interacting with the elements themselves.
