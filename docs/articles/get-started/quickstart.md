---
uid: get-started-quickstart
title: Quickstart
---

# Quickstart

This guide gets you from zero to a passing UI test in under 5 minutes. We'll use a Web test with Chrome as the fastest path to a working example, but the same patterns apply to Windows, Android, and iOS.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download) installed
- [Google Chrome](https://www.google.com/chrome/) installed

## 1. Install the project templates

Legerity ships `dotnet new` templates that scaffold a complete test project for each platform. Install them globally:

```powershell
dotnet new install Legerity.Templates
```

## 2. Create a Web test project

Create a new folder for your test project and scaffold it:

```powershell
mkdir MyApp.UITests
cd MyApp.UITests
dotnet new legerity-web
```

This generates a ready-to-run project structure:

```text
MyApp.UITests/
├── Elements/
├── Pages/
│   └── SamplePage.cs
├── Tests/
│   └── SampleTests.cs
├── BaseTestClass.cs
├── GlobalUsings.cs
└── MyApp.UITests.csproj
```

The project includes NUnit, Selenium, ChromeDriver, and `Legerity.Web` as dependencies.

## 3. Understand the structure

**`BaseTestClass.cs`** extends `LegerityTestClass` and configures the app driver. This is where you set the target URL and browser options:

```csharp
public abstract class BaseTestClass : LegerityTestClass
{
    private const string WebApplication = "https://www.example.com";

    public BaseTestClass()
        : base(new WebAppManagerOptions
        {
            DriverType = WebAppDriverType.Chrome,
            Url = WebApplication,
            ImplicitWait = TimeSpan.FromSeconds(5),
        })
    {
    }
}
```

**`Pages/SamplePage.cs`** is a page object that models a page in your application. It defines a `Trait` (an element that must be present for the page to be valid) and exposes elements as properties:

```csharp
public class SamplePage : BasePage
{
    protected override By Trait => By.TagName("h1");

    public WebElement Heading => App.FindElement(Trait);
}
```

**`Tests/SampleTests.cs`** contains your test cases, using the page object to interact with the app:

```csharp
public class SampleTests : BaseTestClass
{
    [Test]
    public void ShouldShowHeading()
    {
        var page = new SamplePage();
        page.VerifyPageShown();
        Assert.That(page.Heading.Displayed, Is.True);
    }
}
```

## 4. Run the tests

```powershell
dotnet test
```

Chrome launches, navigates to `https://www.example.com`, verifies the heading element is displayed, and the test passes.

## 5. Point it at your app

Update the `WebApplication` constant in `BaseTestClass.cs` to your application's URL, replace `SamplePage` with a page object for your app, and start building real tests.

## What just happened

In a few lines of code, you set up:

1. **Driver management** - `LegerityTestClass` handles starting and stopping the browser for each test.
2. **Page objects** - `BasePage` waits for the page trait to appear, confirming the page loaded.
3. **Element wrappers** - Any element you find can be cast to a Legerity wrapper for richer interactions.

## Next steps

| Goal | Guide |
|------|-------|
| Test a Windows desktop app | [Windows getting started](xref:windows-getting-started) |
| Test an Android app | [Android getting started](xref:android-getting-started) |
| Test an iOS app | [iOS getting started](xref:ios-getting-started) |
| Test across multiple platforms | [Core: test classes](xref:core-test-classes) |
| Learn the page object pattern | [Core: page objects](xref:core-page-objects) |
| Explore element wrappers | [Core: element wrappers](xref:core-element-wrappers) |
| Use fluent locators | [Core: locators](xref:core-locators) |
