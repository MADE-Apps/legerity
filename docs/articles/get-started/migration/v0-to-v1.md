---
uid: migration-v0-to-v1
title: "Migration guide: v0.x to v1.0"
---

# Migrating from v0.x to v1.0

Legerity v1.0 upgrades the entire dependency stack (Appium 8.x, Selenium 4.x, .NET 10.0) and introduces breaking changes across the API surface. This guide walks through every change you need to make, with before/after code examples.

The migration is mechanical. Most changes are find-and-replace operations on type names, and the compiler will catch anything you miss.

## 1. Update your target framework

All Legerity packages now require .NET 10.0. Update your test project's target framework:

```xml
<!-- Before -->
<TargetFramework>net6.0</TargetFramework>

<!-- After -->
<TargetFramework>net10.0</TargetFramework>
```

## 2. Update NuGet packages

Update all Legerity packages to v1.0:

```powershell
dotnet add package Legerity.Core --version 1.0.0
dotnet add package Legerity.Web --version 1.0.0
dotnet add package Legerity.Windows --version 1.0.0
# ... update all Legerity packages you use
```

## 3. Replace driver types

Selenium 4 removes `RemoteWebDriver` and `RemoteWebElement` in favor of their base types. Update all references:

```csharp
// Before
RemoteWebDriver app = AppManager.StartApp(options);
RemoteWebElement element = app.FindElement(By.Id("myElement"));

// After
WebDriver app = AppManager.StartApp(options);
WebElement element = app.FindElement(By.Id("myElement"));
```

For platform-specific drivers, the generic type parameters are gone:

```csharp
// Before
WindowsDriver<WindowsElement> app = ...;
AndroidDriver<AndroidElement> app = ...;
IOSDriver<IOSElement> app = ...;

// After
WindowsDriver app = ...;
AndroidDriver app = ...;
IOSDriver app = ...;
```

## 4. Replace element types

Appium 8 replaces `AppiumWebElement` with `AppiumElement` and removes platform-specific element types entirely:

```csharp
// Before
WindowsElement element = ...;
AndroidElement element = ...;
IOSElement element = ...;
AppiumWebElement element = ...;

// After (all platforms)
AppiumElement element = ...;
```

## 5. Update custom element wrappers

If you've created custom element wrappers, update the constructor and implicit operators:

```csharp
// Before (v0.x)
public class MyButton : WindowsElementWrapper
{
    public MyButton(WindowsElement element) : base(element) { }

    public static implicit operator MyButton(WindowsElement e) => new(e);
    public static implicit operator MyButton(AppiumWebElement e) => new(e as WindowsElement);
    public static implicit operator MyButton(RemoteWebElement e) => new(e as WindowsElement);
}

// After (v1.0)
public class MyButton : WindowsElementWrapper
{
    public MyButton(AppiumElement element) : base(element) { }

    public static implicit operator MyButton(WebElement e) => new(e as AppiumElement);
}
```

The same pattern applies to `AndroidElementWrapper`, `IOSElementWrapper`, and `WebElementWrapper` subclasses. The key changes:

- Constructor takes `AppiumElement` (or `WebElement` for web wrappers) instead of platform-specific types.
- A single implicit operator from `WebElement` replaces the multiple operators from platform-specific types.

## 6. Update FindElement calls

The convenience methods like `FindElementByXPath()`, `FindElementById()`, and `FindElementByName()` were removed in Selenium 4. Replace them with `FindElement(By.*)`:

```csharp
// Before
var element = app.FindElementByXPath("//button[@name='Submit']");
var element = app.FindElementById("myElement");
var element = app.FindElementByName("username");

// After
var element = app.FindElement(By.XPath("//button[@name='Submit']"));
var element = app.FindElement(By.Id("myElement"));
var element = app.FindElement(By.Name("username"));
```

## 7. Update Appium options

`AddAdditionalCapability` and `MobileCapabilityType` are gone. Use typed properties on `AppiumOptions`:

```csharp
// Before
var options = new AppiumOptions();
options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel");
options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "13");
options.AddAdditionalCapability(MobileCapabilityType.App, "/path/to/app.apk");

// After
var options = new AppiumOptions();
options.PlatformName = "Android";
options.DeviceName = "Pixel";
options.PlatformVersion = "13";
options.App = "/path/to/app.apk";
```

For vendor-specific capabilities not covered by typed properties, use `AddAdditionalAppiumOption()`:

```csharp
options.AddAdditionalAppiumOption("appium:noReset", true);
```

## 8. Update browser configuration

If you're using web testing, remove references to dropped browser types:

```csharp
// Before - remove these
WebAppDriverType.Opera              // Opera support dropped
WebAppDriverType.InternetExplorer   // IE is end-of-life
WebAppDriverType.EdgeChromium       // Redundant

// After - use these
WebAppDriverType.Chrome
WebAppDriverType.Firefox
WebAppDriverType.Safari
WebAppDriverType.Edge  // Chromium-based by default
```

## 9. Remove references to dropped packages

The following packages have been removed in v1.0. Uninstall them from your projects:

- `Legerity.MADE` (MADE.NET control wrappers)
- `Legerity.Telerik.Uwp` (Telerik UWP control wrappers)
- `Legerity.WCT` (Windows Community Toolkit control wrappers)

If you still need wrappers for these controls, create custom element wrappers following the [element wrappers guide](xref:core-element-wrappers). The pattern is identical to the built-in wrappers.

## 10. Verify your tests compile and pass

After making these changes, build and run your tests:

```powershell
dotnet build
dotnet test
```

The compiler will catch any remaining type mismatches. The most common issues at this stage are:

- Missed `RemoteWebDriver` or `RemoteWebElement` references in page objects.
- Custom element wrappers still using old constructor signatures.
- Appium options using the old capability API.

## Summary of type replacements

| v0.x type | v1.0 replacement |
|-----------|-----------------|
| `RemoteWebDriver` | `WebDriver` |
| `RemoteWebElement` | `WebElement` |
| `AppiumWebElement` | `AppiumElement` |
| `WindowsElement` | `AppiumElement` |
| `AndroidElement` | `AppiumElement` |
| `IOSElement` | `AppiumElement` |
| `WindowsDriver<WindowsElement>` | `WindowsDriver` |
| `AndroidDriver<AndroidElement>` | `AndroidDriver` |
| `IOSDriver<IOSElement>` | `IOSDriver` |
| `MobileCapabilityType.*` | Typed `AppiumOptions` properties |
| `FindElementByXPath()` | `FindElement(By.XPath())` |
| `FindElementById()` | `FindElement(By.Id())` |
| `FindElementByName()` | `FindElement(By.Name())` |
