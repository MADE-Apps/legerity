---
uid: android-getting-started
title: Android - Getting started
---

# Getting started with Android testing

This guide walks you through setting up a Legerity Android test project, configuring Appium and an Android emulator, and writing your first test.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js](https://nodejs.org/) (for Appium)
- [Appium 2.x](https://appium.io/) (`npm install -g appium`) with the UiAutomator2 driver (`appium driver install uiautomator2`)
- [Android SDK](https://developer.android.com/studio) with an emulator configured, or a physical Android device with USB debugging enabled

## Project setup

Use the Legerity template:

```powershell
dotnet new install Legerity.Templates
mkdir MyAndroidApp.UITests && cd MyAndroidApp.UITests
dotnet new legerity-android
```

Or add packages manually:

```powershell
dotnet add package Legerity.Android
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

## Starting Appium

Start the Appium server before running tests:

```powershell
appium --port 4723
```

Alternatively, set `LaunchAppiumServer = true` in your options to have Legerity start and stop the Appium server automatically.

## Configuring the test project

Create a `BaseTestClass` that targets your Android application:

```csharp
public abstract class BaseTestClass : LegerityTestClass
{
    private const string AndroidApplication = "com.example.myapp";
    private const string AndroidApplicationActivity = "com.example.myapp.MainActivity";

    public BaseTestClass()
        : base(new AndroidAppManagerOptions
        {
            AppId = AndroidApplication,
            AppActivity = AndroidApplicationActivity,
            DriverUri = "http://localhost:4723",
            DeviceName = "Pixel_6_API_33",
            OSVersion = "13",
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
| `AppId` | The Android package name (e.g., `com.example.myapp`). |
| `AppActivity` | The main activity to launch (e.g., `com.example.myapp.MainActivity`). |
| `AppPath` | Path to the APK file. Use this instead of `AppId` to install and launch from a local APK. |
| `DeviceName` | The emulator AVD name or physical device name. |
| `DeviceId` | The specific device serial number (useful when multiple devices are connected). |
| `OSVersion` | The Android OS version. |
| `LaunchAppiumServer` | Set to `true` to have Legerity manage the Appium server lifecycle. |

### Using a local APK

If you want to install the app from an APK rather than launching an already-installed app:

```csharp
new AndroidAppManagerOptions
{
    AppPath = @"C:\builds\myapp-debug.apk",
    AppActivity = "com.example.myapp.MainActivity",
    DriverUri = "http://localhost:4723",
    DeviceName = "Pixel_6_API_33",
}
```

## Writing a page object

```csharp
public class LoginPage : BasePage
{
    protected override By Trait => By.Id("com.example.myapp:id/loginButton");

    public EditText UsernameInput =>
        App.FindElement(By.Id("com.example.myapp:id/usernameInput"));

    public EditText PasswordInput =>
        App.FindElement(By.Id("com.example.myapp:id/passwordInput"));

    public Button LoginButton =>
        App.FindElement(By.Id("com.example.myapp:id/loginButton"));

    public HomePage Login(string username, string password)
    {
        UsernameInput.SetText(username);
        PasswordInput.SetText(password);
        LoginButton.Click();
        return new HomePage();
    }
}
```

Note that Android resource IDs use the full format `package:id/name`.

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

## Using Android-specific locators

`AndroidByExtras` provides locators for Android's content description (accessibility label):

```csharp
// Find by content description
app.FindElement(AndroidByExtras.ContentDescription("Submit button"));
app.FindElement(AndroidByExtras.PartialContentDescription("Submit"));

// Fluent chaining
app.FindElement(By.ClassName("android.widget.Button")
    .WithContentDescription("Submit"));
```

## Inspecting your Android app's UI tree

Use one of these tools to discover element IDs and the UI hierarchy:

- **Appium Inspector** - A standalone GUI tool for inspecting the app's element tree. Download from [Appium Inspector releases](https://github.com/appium/appium-inspector/releases).
- **Android Studio Layout Inspector** - Built into Android Studio. Shows the view hierarchy of a running app.
- **`uiautomatorviewer`** - Ships with the Android SDK. Located in `<ANDROID_SDK>/tools/bin/`.

## Best practices

- **Use resource IDs as your primary locator.** Android resource IDs (`com.package:id/name`) are stable and unique within a screen.
- **Set generous `ImplicitWait` values.** Android emulators can be slow, especially on first launch. 10 seconds is a reasonable default.
- **Use `LaunchAppiumServer = true` for CI.** This ensures the Appium server starts and stops with your test run.
- **Test on both emulators and physical devices.** Emulators are convenient for development, but physical devices can reveal timing and performance issues.
- **Use content description for elements without IDs.** Some custom views don't expose resource IDs. Content descriptions are the next best locator strategy.
