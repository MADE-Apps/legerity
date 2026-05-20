---
uid: ios-element-wrappers
title: iOS - Element wrappers
---

# iOS element wrappers

`Legerity.IOS` provides typed wrappers for 6 standard iOS UIKit controls. Each wrapper extends [`IOSElementWrapper`](xref:Legerity.IOS.Elements.IOSElementWrapper) and exposes control-specific properties and methods.

All wrappers use implicit operators for seamless casting:

```csharp
TextField email = app.FindElement(By.Name("Email"));
Switch notifications = app.FindElement(By.Name("Notifications"));
Slider brightness = app.FindElement(By.Name("Brightness"));
```

## TextField

Wraps the iOS `UITextField` / `XCUIElementTypeTextField` control:

```csharp
TextField email = app.FindElement(By.Name("Email"));

string text = email.Text;

email.SetText("user@example.com");
email.AppendText(" more text");
email.ClearText();
```

The `ClearTextButton` property provides access to the clear button (the X icon) when the field has text:

```csharp
if (email.ClearTextButton != null)
{
    email.ClearTextButton.Click();
}
```

## Slider

Wraps the iOS `UISlider` / `XCUIElementTypeSlider`:

```csharp
Slider brightness = app.FindElement(By.Name("Brightness"));
brightness.SetValue(0.75); // iOS sliders use 0.0 to 1.0 range
```

## Switch

Wraps the iOS `UISwitch` / `XCUIElementTypeSwitch`:

```csharp
Switch notifications = app.FindElement(By.Name("Notifications"));
notifications.Toggle();
notifications.On();
notifications.Off();
bool isOn = notifications.IsOn;
```

## Button

Wraps the iOS `UIButton` / `XCUIElementTypeButton`:

```csharp
Button submit = app.FindElement(By.Name("Submit"));
submit.Click();
bool isEnabled = submit.IsEnabled;
```

## Label

Wraps the iOS `UILabel` / `XCUIElementTypeStaticText` (read-only text):

```csharp
Label header = app.FindElement(By.Name("PageHeader"));
string displayText = header.Text;
```

## ProgressView

Wraps the iOS `UIProgressView` / `XCUIElementTypeProgressIndicator`:

```csharp
ProgressView progress = app.FindElement(By.Name("UploadProgress"));
double value = progress.Value; // 0.0 to 1.0
```

## IOSElementWrapper base

All iOS wrappers inherit from `IOSElementWrapper`, which provides:

| Member | Description |
|--------|-------------|
| `Element` | The underlying `AppiumElement`. |
| `Driver` | Typed `IOSDriver` reference. |
| `IsVisible` | Whether the element is displayed. |
| `IsEnabled` | Whether the element is interactive. |
| `Click()` | Tap the element. |
| `GetAttribute(name)` | Read an element attribute. |
| `FindElement(locator)` | Find a child element within this control. |

## Creating custom iOS wrappers

For controls not covered by the built-in wrappers, extend `IOSElementWrapper`:

```csharp
public class SegmentedControl : IOSElementWrapper
{
    public SegmentedControl(AppiumElement element) : base(element) { }

    public static implicit operator SegmentedControl(WebElement e) => new(e as AppiumElement);

    public string SelectedSegment =>
        FindElements(By.ClassName("XCUIElementTypeButton"))
            .FirstOrDefault(b => b.Selected)?.Text ?? string.Empty;

    public void SelectSegment(string label)
    {
        FindElements(By.ClassName("XCUIElementTypeButton"))
            .First(b => b.Text == label)
            .Click();
    }
}
```

For more details on creating custom wrappers, see [Element wrappers](xref:core-element-wrappers).
