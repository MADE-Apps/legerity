---
uid: ios-getting-started
title: iOS - Getting started
---

# Getting started with iOS testing

This guide walks you through setting up a Legerity iOS test project, configuring Appium with the XCUITest driver, and writing your first test against an iOS application on a simulator.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download)
- A macOS machine with [Xcode](https://developer.apple.com/xcode/) installed (required for iOS simulators)
- [Node.js](https://nodejs.org/) (for Appium)
- [Appium 2.x](https://appium.io/) (`npm install -g appium`) with the XCUITest driver (`appium driver install xcuitest`)

## Project setup

Use the Legerity template:

```powershell
dotnet new install Legerity.Templates
mkdir MyIOSApp.UITests && cd MyIOSApp.UITests
dotnet new legerity-ios
```

Or add packages manually:

```powershell
dotnet add package Legerity.IOS
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

## Starting Appium

Start the Appium server before running tests:

```bash
appium --port 4723
```

Or set `LaunchAppiumServer = true` in your options for automatic management.

## Configuring the test project

Create a `BaseTestClass` that targets your iOS application:

```csharp
public abstract class BaseTestClass : LegerityTestClass
{
    private const string IOSApplication = "com.example.myapp";

    public BaseTestClass()
        : base(new IOSAppManagerOptions
        {
            AppId = IOSApplication,
            DeviceName = "iPhone 15",
            OSVersion = "17.0",
            DriverUri = "http://localhost:4723",
            LaunchAppiumServer = false,
            ImplicitWait = TimeSpan.FromSeconds(10),
        })
    {
    }
}
```

### Key options

| Property | Description |
|----------|-------------|
| `AppId` | The iOS bundle identifier (e.g., `com.example.myapp`). |
| `DeviceName` | The simulator name (e.g., `"iPhone 15"`) or physical device name. |
| `DeviceId` | The specific device UDID (useful for physical devices). |
| `OSVersion` | The iOS version (e.g., `"17.0"`). |
| `AutomationName` | The automation engine. Defaults to `"XCUITest"`. |
| `LaunchAppiumServer` | Set to `true` to have Legerity manage the Appium server lifecycle. |

## Writing a page object

```csharp
public class LoginPage : BasePage
{
    protected override By Trait => By.Name("Login");

    public TextField UsernameInput =>
        App.FindElement(By.Name("Username"));

    public TextField PasswordInput =>
        App.FindElement(By.Name("Password"));

    public Button LoginButton =>
        App.FindElement(By.Name("Login"));

    public HomePage Login(string username, string password)
    {
        UsernameInput.SetText(username);
        PasswordInput.SetText(password);
        LoginButton.Click();
        return new HomePage();
    }
}
```

iOS elements are typically identified by their accessibility label, which maps to `By.Name()` in Appium.

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
        var homePage = new LoginPage().Login("admin", "password123");
        homePage.VerifyPageShown();
    }
}
```

## Using iOS-specific locators

`IOSByExtras` provides locators for iOS accessibility properties:

```csharp
// Find by accessibility label
app.FindElement(IOSByExtras.Label("Submit"));
app.FindElement(IOSByExtras.PartialLabel("Sub"));

// Find by value
app.FindElement(IOSByExtras.Value("50"));
app.FindElement(IOSByExtras.PartialValue("%"));

// Fluent chaining
app.FindElement(By.ClassName("XCUIElementTypeButton").WithLabel("Submit"));
app.FindElement(By.ClassName("XCUIElementTypeSlider")
    .That(by => by.HasValue("75")));
```

## Inspecting your iOS app's UI tree

Use these tools to discover element identifiers:

- **Appium Inspector** - A standalone GUI tool for inspecting the app's element tree. Download from [Appium Inspector releases](https://github.com/appium/appium-inspector/releases).
- **Xcode Accessibility Inspector** - Built into Xcode (Xcode > Open Developer Tool > Accessibility Inspector). Shows accessibility labels, values, and traits.

## Best practices

- **Set accessibility identifiers on your iOS app's controls.** These are the most reliable locators. In SwiftUI, use `.accessibilityIdentifier("myButton")`. In UIKit, set `accessibilityIdentifier` on the view.
- **Use simulators for development, devices for CI.** Simulators are faster for iterative development. Test on real devices before shipping.
- **Set generous timeouts.** iOS simulators can be slow to launch and render. Start with `ImplicitWait` of 10 seconds and adjust based on your app's performance.
- **Handle keyboard interactions carefully.** iOS simulators sometimes show the software keyboard, which can obscure elements. Use `TextField.ClearText()` instead of manual key presses where possible.
