---
uid: windows-getting-started
title: Windows - Getting started
---

# Getting started with Windows testing

This guide walks you through setting up a Legerity Windows test project, configuring a UI Automation driver, and writing your first test against a Windows desktop application.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download)
- A Windows 10 or Windows 11 device
- **Legerity Windows Driver**: The W3C WebDriver server for Windows UI Automation included in this repository. See [Windows Driver](xref:tools-windows-driver).

## Project setup

Use the Legerity template:

```powershell
dotnet new install Legerity.Templates
mkdir MyWindowsApp.UITests && cd MyWindowsApp.UITests
dotnet new legerity-windows
```

Or add packages to an existing test project:

```powershell
dotnet add package Legerity.Windows
dotnet add package Legerity.WinUI
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

## Starting the driver

Before running tests, start the Legerity Windows Driver. From the repository root:

```powershell
dotnet run --project tools/Legerity.WindowsDriver -- --port 4723
```

The driver listens on `http://localhost:4723` by default.

> [!NOTE]
> You can also configure `WindowsAppManagerOptions` to launch the driver automatically by setting `LaunchDriver = true`.

## Configuring the test project

Create a `BaseTestClass` that targets your application:

```csharp
public abstract class BaseTestClass : LegerityTestClass
{
    // Application User Model ID (AUMID) for a UWP/WinUI app
    private const string WindowsApplication =
        "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

    public BaseTestClass()
        : base(new WindowsAppManagerOptions
        {
            AppId = WindowsApplication,
            DriverUri = "http://localhost:4723",
            ImplicitWait = TimeSpan.FromSeconds(5),
        })
    {
    }
}
```

### Finding your application's AUMID

For UWP and WinUI apps, the `AppId` is the Application User Model ID. You can find it with PowerShell:

```powershell
Get-StartApps | Where-Object { $_.Name -like "*Calculator*" }
```

For Win32/WPF applications, use the executable path instead:

```csharp
new WindowsAppManagerOptions
{
    AppId = @"C:\Program Files\MyApp\MyApp.exe",
    DriverUri = "http://localhost:4723",
}
```

## Writing a page object

Model your application's pages using `BasePage` with Windows element wrappers:

```csharp
public class CalculatorPage : BasePage
{
    protected override By Trait => WindowsByExtras.AutomationId("CalculatorResults");

    public TextBlock ResultDisplay =>
        App.FindElement(WindowsByExtras.AutomationId("CalculatorResults"));

    public Button NumberButton(int number) =>
        App.FindElement(WindowsByExtras.AutomationId($"num{number}Button"));

    public Button PlusButton =>
        App.FindElement(WindowsByExtras.AutomationId("plusButton"));

    public Button EqualsButton =>
        App.FindElement(WindowsByExtras.AutomationId("equalButton"));

    public string Calculate(int a, int b)
    {
        NumberButton(a).Click();
        PlusButton.Click();
        NumberButton(b).Click();
        EqualsButton.Click();
        return ResultDisplay.Text;
    }
}
```

## Writing tests

```csharp
public class CalculatorTests : BaseTestClass
{
    [SetUp]
    public void SetUp() => StartApp();

    [TearDown]
    public void TearDown() => StopApp();

    [Test]
    public void ShouldAddTwoNumbers()
    {
        var calculator = new CalculatorPage();
        calculator.VerifyPageShown();

        string result = calculator.Calculate(2, 3);
        Assert.That(result, Does.Contain("5"));
    }
}
```

## Inspecting your application's UI tree

To find `AutomationId` values and element structures, use one of these tools:

- **[Accessibility Insights for Windows](https://accessibilityinsights.io/downloads/)** - Microsoft's free tool for inspecting UI Automation properties. Shows AutomationId, Name, ClassName, and the full element tree.
- **[Inspect.exe](https://docs.microsoft.com/en-us/windows/win32/winauto/inspect-objects)** - Ships with the Windows SDK. Provides detailed UI Automation property inspection.

## Using AutomationId locators

`AutomationId` is the primary locator for Windows UI testing. It's a stable identifier set by the application developer specifically for automation:

```csharp
// Direct locator
app.FindElement(WindowsByExtras.AutomationId("submitButton"));

// Fluent chaining
app.FindElement(By.ClassName("Button").WithAutomationId("submitButton"));

// Scoped search
app.FindElement(By.Name("Settings")
    .ThenFindByAutomationId("volumeSlider"));
```

> [!NOTE]
> If the application doesn't set `AutomationProperties.AutomationId` on its controls, you can fall back to `By.Name()` (which matches the `Name` UI Automation property) or `By.ClassName()` (which matches the control type).

## Best practices

- **Use `AutomationId` as your primary locator strategy.** It's set by the developer specifically for automation and won't change with visual updates.
- **Start the driver before running tests.** Either start it manually or set `LaunchDriver = true` in your options for automatic management.
- **Use the `legerity-pop` tool** to auto-generate page objects from your XAML files. See [Page Object Generator](xref:tools-page-object-generator).
- **Test with the Calculator or Clock apps first** to validate your setup before pointing at your own application.
