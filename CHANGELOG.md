# Changelog

## v1.0.0

### Breaking Changes

#### Target Framework

- **Dropped .NET Standard 2.0 support.** All libraries now target **.NET 10.0** exclusively. Consumers on .NET Framework or older .NET Core versions will need to upgrade.
- Test projects, samples, and tools updated from .NET 6.0 to .NET 10.0.

#### Appium 8.x Migration

- **Upgraded Appium.WebDriver from 4.4.5 to 8.x.** This is a major breaking change affecting all element types and driver references.
- **`AppiumWebElement` replaced by `AppiumElement`.** All element wrappers, constructors, and implicit operators now use `AppiumElement` from `OpenQA.Selenium.Appium`.
- **Platform-specific element types removed.** `WindowsElement`, `AndroidElement`, and `IOSElement` no longer exist in Appium 8.x. All platform wrappers now use `AppiumElement` as their base element type.
- **Generic driver types removed.** `WindowsDriver<WindowsElement>`, `AndroidDriver<AndroidElement>`, and `IOSDriver<IOSElement>` are now simply `WindowsDriver`, `AndroidDriver`, and `IOSDriver`.
- **`AddAdditionalCapability` replaced.** Use `AppiumOptions` properties (`PlatformName`, `DeviceName`, `PlatformVersion`, `App`, `AutomationName`) or `AddAdditionalAppiumOption()` for vendor-specific capabilities.
- **`MobileCapabilityType` enum removed.** Capability constants are no longer used; capabilities are set via typed properties on `AppiumOptions`.

#### Selenium 4.x Migration

- **Upgraded Selenium.WebDriver from 3.x to 4.35** (transitive via Appium 8.x).
- **`RemoteWebDriver` replaced by `WebDriver`.** All driver references, properties, and method signatures now use `OpenQA.Selenium.WebDriver` as the common base type. This includes `AppManager.App`, `BasePage.App`, and `LegerityTestClass.App`.
- **`RemoteWebElement` replaced by `WebElement`.** All element references now use `OpenQA.Selenium.WebElement`. Implicit operators on element wrappers accept `WebElement` instead of `RemoteWebElement`.
- **`FindElementByXPath()`, `FindElementById()`, `FindElementByName()` removed.** Use `FindElement(By.XPath(...))`, `FindElement(By.Id(...))`, `FindElement(By.Name(...))` instead.

#### Removed Browser Support

- **Opera** (`WebAppDriverType.Opera`) - removed, Opera browser support was dropped in Selenium 4.
- **Internet Explorer** (`WebAppDriverType.InternetExplorer`) - removed, IE is end-of-life.
- **Edge Chromium** (`WebAppDriverType.EdgeChromium`) - removed, redundant since `WebAppDriverType.Edge` is Chromium-based by default in Selenium 4.

#### Removed Dependencies

- **`Microsoft.Edge.SeleniumTools`** - removed. Edge is now handled natively by Selenium 4's `EdgeDriver`.

#### Removed Packages

- **`Legerity.MADE`** - removed. MADE.NET control wrappers (`DropDownList`, `InputValidator`).
- **`Legerity.Telerik.Uwp`** - removed. Telerik UWP control wrappers (`RadAutoCompleteBox`, `RadBulletGraph`, `RadBusyIndicator`, `RadNumericBox`).
- **`Legerity.WCT`** - removed. Windows Community Toolkit control wrappers (`BladeView`, `Carousel`, `Expander`, `InAppNotification`, `RadialGauge`).
- Associated test projects and sample applications for the above packages have also been removed.

### New Features

#### Fluent Selector Chaining

A new fluent API for composing element locator queries, available as extension methods on `By`:

**Simple shortcuts** (extend any `By` locator):

- `.WithText(text)` - match elements with exact text content
- `.WithPartialText(text)` - match elements with partial text content
- `.WithAttribute(name, value)` - match elements with an exact attribute value
- `.WithPartialAttribute(name, value)` - match elements with a partial attribute value
- `.And(otherBy)` - combine with another locator (intersection)
- `.ThenFind(childBy)` - find children within matched elements

**Builder API** (for complex multi-constraint queries):

- `.That(by => ...)` - add same-element constraints via a builder (intersection)
- `.ThenFind(by => ...)` - scope into children via a builder (nesting)

Builder methods: `.TagName()`, `.Id()`, `.ClassName()`, `.CssSelector()`, `.XPath()`, `.Name()`, `.HasText()`, `.HasPartialText()`, `.HasAttribute()`, `.HasPartialAttribute()`, `.Matching(By)`

**Platform-specific builder extensions:**

- **Windows:** `.HasAutomationId()`, `.WithAutomationId()`, `.ThenFindByAutomationId()`
- **Android:** `.HasContentDescription()`, `.HasPartialContentDescription()`, `.WithContentDescription()`, `.WithPartialContentDescription()`
- **iOS:** `.HasLabel()`, `.HasPartialLabel()`, `.HasValue()`, `.HasPartialValue()`, `.WithLabel()`, `.WithPartialLabel()`, `.WithValue()`, `.WithPartialValue()`
- **Web:** `.HasInputType()`, `.ThenFindByInputType()`, `.ThenFindListItems()`, `.ThenFindOptions()`, `.ThenFindTableRows()`

**Example usage:**

```csharp
// Before
page.FindElement(new ByAll(By.TagName("button"), ByExtras.Text("Accept")));
page.FindElements(new ByNested(By.TagName("form"), By.XPath("//input[@type='radio']")));

// After - simple
page.FindElement(By.TagName("button").WithText("Accept"));

// After - builder
page.FindElement(By.TagName("form")
    .ThenFind(by => by.TagName("input").HasAttribute("type", "radio")));
```

### Bug Fixes

#### `ByAll` Intersection Logic

- Fixed `ByAll.FindElements()` to use `Equals()`-based element comparison instead of `Intersect()`. In Selenium 4.x, `WebElement.GetHashCode()` is not consistent with `Equals()`, causing `Intersect()` to never match elements that represent the same DOM node across separate queries. This was a latent bug that broke all `ByAll` queries after the Selenium 4 upgrade.

#### Thread-Safe Driver Lifecycle

- **`AppManager.App`** now uses `AsyncLocal<WebDriver>` instead of a static property. Each test execution context gets its own driver reference, preventing parallel tests from overwriting each other's drivers.
- **`AppManager.StartedApps`** now uses `ConcurrentDictionary` instead of `List<WebDriver>` for thread-safe access.
- **`AppManager.StopApp()`** now uses `TryRemove` for idempotent cleanup. Only the first caller to remove a driver will call `Quit()`, preventing `ObjectDisposedException` when multiple threads attempt cleanup.
- **`LegerityTestClass.App`** now uses `AsyncLocal<WebDriver>` for thread-safe per-test driver isolation.
- **`LegerityTestClass.apps`** now uses `ConcurrentBag<WebDriver>` for thread-safe collection access.

#### Resilient Driver Disposal

- `AppManager.StopApp()` and `AppManager.StopApps()` now catch exceptions during `Quit()` to handle partially initialized or already-disposed drivers gracefully, preventing teardown failures from masking real test failures.

### Migration Guide

#### Updating Element Wrapper Code

```csharp
// Before (v0.14)
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

#### Updating Driver References

```csharp
// Before (v0.14)
WindowsDriver<WindowsElement> app = ...;
RemoteWebDriver webApp = ...;

// After (v1.0)
WindowsDriver app = ...;
WebDriver webApp = ...;
```

#### Updating Appium Options

```csharp
// Before (v0.14)
options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel");

// After (v1.0)
options.PlatformName = "Android";
options.DeviceName = "Pixel";
```

#### Updating Browser Configuration

```csharp
// Before (v0.14) - remove these
WebAppDriverType.Opera
WebAppDriverType.InternetExplorer
WebAppDriverType.EdgeChromium

// After (v1.0) - use these
WebAppDriverType.Chrome
WebAppDriverType.Firefox
WebAppDriverType.Safari
WebAppDriverType.Edge  // Chromium-based by default
```
