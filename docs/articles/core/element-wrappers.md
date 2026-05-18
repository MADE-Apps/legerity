---
uid: core-element-wrappers
title: Element wrappers
---

# Element wrappers

Element wrappers are Legerity's primary abstraction for interacting with UI controls. They wrap a raw driver element (`AppiumElement` or `WebElement`) with a typed class that exposes the control's properties and actions as first-class methods.

The difference is stark. Here's what setting a value on a Windows slider looks like without a wrapper:

```csharp
WebElement slider = app.FindElement(By.Id("VolumeSlider"));
slider.Click();
var current = double.Parse(slider.GetAttribute("RangeValue.Value"));
while (Math.Abs(current - 75) > double.Epsilon)
{
    slider.SendKeys(current < 75 ? Keys.ArrowRight : Keys.ArrowLeft);
    current = double.Parse(slider.GetAttribute("RangeValue.Value"));
}
```

And with the Legerity `Slider` wrapper:

```csharp
Slider slider = app.FindElement(By.Id("VolumeSlider"));
slider.SetValue(75);
```

The wrapper encapsulates the interaction model, boundary checking, and attribute parsing. Your test code expresses intent, not implementation.

## How element wrappers work

Every element wrapper uses [implicit operators](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators) to enable seamless casting from the raw element type. When you assign the result of `FindElement` to a wrapper type, C# automatically invokes the implicit operator to construct the wrapper:

```csharp
// FindElement returns WebElement, but the implicit operator
// converts it to a TextInput wrapper automatically
TextInput username = app.FindElement(By.Id("usernameInput"));
```

This means you can use wrappers anywhere you would use raw elements. No factory methods, no explicit casts, no boilerplate.

Each wrapper maintains a reference to the underlying element via the `Element` property and to the creating driver via `ElementDriver`. The wrapper is always in sync with the live DOM/UI tree.

## Built-in element wrappers

Legerity ships wrappers for common controls on each platform:

- **Web** - TextInput, Select, CheckBox, RadioButton, Button, NumberInput, DateInput, RangeInput, FileInput, TextArea, Table, List, Image, Form, Option, TableRow. See [Web element wrappers](xref:web-element-wrappers).
- **Windows** - TextBox, ComboBox, Slider, DatePicker, TimePicker, ListView, GridView, CheckBox, RadioButton, ToggleSwitch, Button, and 20+ more. See [Windows element wrappers](xref:windows-element-wrappers).
- **Android** - EditText, Spinner, DatePicker, CheckBox, RadioButton, Switch, ToggleButton, Button, TextView, View. See [Android element wrappers](xref:android-element-wrappers).
- **iOS** - TextField, Slider, Switch, Button, Label, ProgressView. See [iOS element wrappers](xref:ios-element-wrappers).
- **WinUI** - NavigationView, NumberBox, TabView, RatingControl, InfoBar, MenuBar. See [WinUI](xref:windows-winui).

## Common wrapper API

All element wrappers share a base set of properties and methods inherited from [`ElementWrapper<T>`](xref:Legerity.ElementWrapper`1) (for Appium-based platforms) or `WebElementWrapper` (for web):

| Member | Description |
|--------|-------------|
| `Element` | The underlying raw element. |
| `ElementDriver` | The driver that created this element. |
| `IsVisible` | Whether the element is currently visible. |
| `IsEnabled` | Whether the element is currently enabled for interaction. |
| `Click()` | Click the element. |
| `GetAttribute(name)` | Get an attribute value from the element. |
| `FindElement(locator)` | Find a child element within this wrapper. |
| `VerifyElementShown(locator, timeout?)` | Assert a child element is visible, with optional timeout. |
| `VerifyElementNotShown(locator)` | Assert a child element is not visible. |
| `VerifyElementsShown(locator, timeout?)` | Assert multiple child elements are visible. |

## Finding elements within wrappers

Element wrappers expose `FindElement` for locating child elements. This is essential for composite controls that contain other interactive elements:

```csharp
ComboBox combo = app.FindElement(By.Id("CountrySelector"));
WebElement selectedText = combo.FindElement(By.ClassName("ComboBoxItem"));
```

The child element can itself be cast to another wrapper:

```csharp
ListView list = app.FindElement(By.Id("ItemList"));
TextBlock firstItem = list.FindElement(By.ClassName("ListViewItem"));
```

## Creating custom element wrappers

When your application uses custom controls or controls not covered by the built-in wrappers, you can create your own. A custom wrapper is a class that extends one of the platform-specific base types and adds properties and methods for the control's behavior.

### Base types

| Platform | Base class |
|----------|-----------|
| Windows | [`WindowsElementWrapper`](xref:Legerity.Windows.Elements.WindowsElementWrapper) |
| Android | [`AndroidElementWrapper`](xref:Legerity.Android.Elements.AndroidElementWrapper) |
| iOS | [`IOSElementWrapper`](xref:Legerity.IOS.Elements.IOSElementWrapper) |
| Web | [`WebElementWrapper`](xref:Legerity.Web.Elements.WebElementWrapper) |
| Cross-platform | [`ElementWrapper<T>`](xref:Legerity.ElementWrapper`1) |

### Example: a custom toggle card wrapper

Suppose your web app has a custom card component with a title, description, and toggle switch. Here's how you'd wrap it:

```csharp
public class ToggleCard : WebElementWrapper
{
    public ToggleCard(WebElement element) : base(element)
    {
    }

    public static implicit operator ToggleCard(WebElement element)
    {
        return new ToggleCard(element);
    }

    public string Title => FindElement(By.ClassName("card-title")).Text;

    public string Description => FindElement(By.ClassName("card-description")).Text;

    public bool IsToggled => FindElement(By.CssSelector("input[type='checkbox']")).Selected;

    public void Toggle()
    {
        FindElement(By.CssSelector("input[type='checkbox']")).Click();
    }

    public void Enable()
    {
        if (!IsToggled) Toggle();
    }

    public void Disable()
    {
        if (IsToggled) Toggle();
    }
}
```

Use it in your tests exactly like the built-in wrappers:

```csharp
ToggleCard notificationsCard = app.FindElement(By.Id("notifications-card"));
Assert.That(notificationsCard.Title, Is.EqualTo("Notifications"));
notificationsCard.Enable();
Assert.That(notificationsCard.IsToggled, Is.True);
```

### Example: a custom Windows control wrapper

```csharp
public class RatingStars : WindowsElementWrapper
{
    public RatingStars(AppiumElement element) : base(element)
    {
    }

    public static implicit operator RatingStars(WebElement element)
    {
        return new RatingStars(element as AppiumElement);
    }

    public int CurrentRating =>
        int.Parse(Element.GetAttribute("RangeValue.Value"));

    public void SetRating(int stars)
    {
        // Click the Nth star child element
        var starElements = FindElements(By.ClassName("RatingStar"));
        if (stars > 0 && stars <= starElements.Count)
        {
            starElements.ElementAt(stars - 1).Click();
        }
    }
}
```

### The implicit operator pattern

The implicit operator is what enables seamless casting from `FindElement` results. The pattern is:

1. For **Appium-based wrappers** (Windows, Android, iOS): the constructor takes `AppiumElement`, and the implicit operator converts from `WebElement` via a cast to `AppiumElement`.
2. For **web wrappers**: the constructor takes `WebElement`, and the implicit operator converts from `WebElement` directly.

```csharp
// Appium platforms
public static implicit operator MyWrapper(WebElement e) => new(e as AppiumElement);

// Web
public static implicit operator MyWrapper(WebElement e) => new(e);
```

## Best practices

- **Wrap controls at the right granularity.** Wrap individual controls (buttons, inputs, selectors), not entire page sections. Use page objects for page-level composition.
- **Expose meaningful properties and methods.** A `Select` wrapper should have `SelectedOption` and `SelectOptionByDisplayValue()`, not generic `GetAttribute()` calls.
- **Always implement the implicit operator.** Without it, you lose the seamless casting from `FindElement` and have to construct wrappers manually.
- **Delegate to the underlying element for standard operations.** Don't reimplement `Click()` or `SendKeys()` unless you need platform-specific behavior.
- **Use `FindElement` within wrappers for child elements.** This scopes the search to the wrapper's element subtree, avoiding false matches from other parts of the UI.
