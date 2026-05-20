---
uid: web-getting-started
title: Web - Getting started
---

# Getting started with web testing

This guide walks you through setting up a Legerity web test project from scratch, configuring browser drivers, and writing your first test. If you've already completed the [quickstart](xref:get-started-quickstart), this goes deeper into web-specific configuration and patterns.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download)
- One or more browsers installed (Chrome, Firefox, Edge, or Safari)

## Project setup

The fastest way to get started is with the Legerity template:

```powershell
dotnet new install Legerity.Templates
mkdir MyWebApp.UITests && cd MyWebApp.UITests
dotnet new legerity-web
```

Or add Legerity to an existing test project manually:

```powershell
dotnet add package Legerity.Web
dotnet add package Selenium.WebDriver.ChromeDriver
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

## Configuring the browser

Create a `BaseTestClass` that configures your target browser and application URL:

```csharp
public abstract class BaseTestClass : LegerityTestClass
{
    private const string AppUrl = "https://myapp.example.com";

    public BaseTestClass()
        : base(new WebAppManagerOptions
        {
            DriverType = WebAppDriverType.Chrome,
            Url = AppUrl,
            ImplicitWait = TimeSpan.FromSeconds(5),
        })
    {
    }
}
```

### Browser window size

By default, the browser opens at 1280x800. You can set a specific size or maximize:

```csharp
new WebAppManagerOptions
{
    DriverType = WebAppDriverType.Chrome,
    Url = AppUrl,
    DesiredSize = new Size(1920, 1080),  // Specific size
    // or
    Maximize = true,                      // Maximize the window
}
```

### Testing multiple browsers

Use NUnit's `TestFixtureSource` to run the same tests across browsers:

```csharp
public abstract class BaseTestClass : LegerityTestClass
{
    private const string AppUrl = "https://myapp.example.com";

    public static IEnumerable<AppManagerOptions> BrowserOptions => new List<AppManagerOptions>
    {
        new WebAppManagerOptions
        {
            DriverType = WebAppDriverType.Chrome,
            Url = AppUrl,
            ImplicitWait = TimeSpan.FromSeconds(5),
        },
        new WebAppManagerOptions
        {
            DriverType = WebAppDriverType.Firefox,
            Url = AppUrl,
            ImplicitWait = TimeSpan.FromSeconds(5),
        },
        new WebAppManagerOptions
        {
            DriverType = WebAppDriverType.Edge,
            Url = AppUrl,
            ImplicitWait = TimeSpan.FromSeconds(5),
        },
    };
}

[TestFixtureSource(typeof(BaseTestClass), nameof(BrowserOptions))]
public class LoginTests : BaseTestClass
{
    public LoginTests(AppManagerOptions options) : base(options) { }

    [SetUp]
    public void SetUp() => StartApp();

    [TearDown]
    public void TearDown() => StopApp();

    [Test]
    public void ShouldDisplayLoginForm()
    {
        var loginPage = new LoginPage();
        loginPage.VerifyPageShown();
    }
}
```

NUnit creates a separate fixture per browser, running all tests in each.

## Writing a page object

Model each page of your web application as a class extending `BasePage`:

```csharp
public class LoginPage : BasePage
{
    protected override By Trait => By.Id("loginForm");

    public TextInput UsernameInput => App.FindElement(By.Id("username"));
    public TextInput PasswordInput => App.FindElement(By.Id("password"));
    public Button LoginButton => App.FindElement(By.Id("loginButton"));

    public DashboardPage Login(string username, string password)
    {
        UsernameInput.SetText(username);
        PasswordInput.SetText(password);
        LoginButton.Click();
        return new DashboardPage();
    }
}
```

Notice that element properties return Legerity web wrappers (`TextInput`, `Button`) instead of raw `WebElement`. The implicit operator handles the conversion automatically, and you get typed methods like `SetText()` instead of `SendKeys()`.

## Writing tests

```csharp
public class LoginTests : BaseTestClass
{
    [SetUp]
    public void SetUp() => StartApp();

    [TearDown]
    public void TearDown() => StopApp();

    [Test]
    public void ShouldLoginSuccessfully()
    {
        var dashboard = new LoginPage().Login("admin", "password123");
        Assert.That(dashboard.WelcomeMessage.Text, Does.Contain("Welcome"));
    }

    [Test]
    public void ShouldShowErrorOnInvalidCredentials()
    {
        var loginPage = new LoginPage();
        loginPage.Login("wrong", "credentials");

        loginPage.WaitUntil(
            WaitUntilConditions.ElementIsVisibleInPage<LoginPage>(By.Id("errorMessage")),
            TimeSpan.FromSeconds(5));
    }
}
```

## Using web-specific locators

The `WebByExtras` class provides locators tailored for HTML:

```csharp
// Find input elements by their type attribute
app.FindElement(WebByExtras.InputType("email"));
app.FindElement(WebByExtras.InputType("password"));

// Fluent extensions for scoped searches
app.FindElements(By.TagName("select").ThenFindOptions());
app.FindElements(By.TagName("ul").ThenFindListItems());
app.FindElements(By.TagName("table").ThenFindTableRows());
```

## Inspecting your web application

Use your browser's built-in developer tools (F12) to inspect the DOM and identify element locators. Key tips:

- **Right-click > Inspect** on any element to see its HTML structure, IDs, classes, and attributes.
- **Add `data-testid` attributes** to your application's elements for reliable, automation-friendly locators that don't change with styling or layout updates.
- **Use the Console** to test CSS selectors and XPath expressions before putting them in your tests.

## Best practices

- **Add `data-testid` attributes to your app's UI.** These are the most stable locators because they exist solely for testing and won't change when designers update CSS classes or restructure the DOM.
- **Test in CI with headless browsers.** Chrome and Firefox both support headless mode, which is faster and doesn't require a display server. Configure this via `DriverOptions` on your `WebAppManagerOptions`.
- **Use element wrappers for form interactions.** `TextInput.SetText()` clears the field before typing. `Select.SelectOptionByDisplayValue()` handles the dropdown interaction. These are more reliable than raw `SendKeys()`.
- **Match your `ImplicitWait` to your app's responsiveness.** A fast SPA might need only 2-3 seconds. A server-rendered app with network calls might need 5-10 seconds.
