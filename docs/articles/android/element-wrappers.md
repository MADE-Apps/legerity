---
uid: android-element-wrappers
title: Android - Element wrappers
---

# Android element wrappers

`Legerity.Android` provides typed wrappers for 10 standard Android UI controls. Each wrapper extends [`AndroidElementWrapper`](xref:Legerity.Android.Elements.AndroidElementWrapper) and exposes control-specific properties and methods.

All wrappers use implicit operators for seamless casting:

```csharp
EditText username = app.FindElement(By.Id("com.example:id/username"));
Spinner category = app.FindElement(By.Id("com.example:id/category"));
Switch darkMode = app.FindElement(By.Id("com.example:id/darkModeSwitch"));
```

## EditText

Wraps the Android `EditText` input control:

```csharp
EditText email = app.FindElement(By.Id("com.example:id/emailInput"));

string text = email.Text;

email.SetText("user@example.com");
email.AppendText(" more text");
email.ClearText();
```

## Spinner

Wraps the Android `Spinner` (dropdown selection) control:

```csharp
Spinner category = app.FindElement(By.Id("com.example:id/categorySpinner"));

category.SelectItem("Electronics");
```

## DatePicker

Wraps the Android `DatePicker` control:

```csharp
DatePicker datePicker = app.FindElement(By.Id("com.example:id/birthDate"));
datePicker.SetDate(new DateTime(1990, 6, 15));
```

## CheckBox

```csharp
CheckBox terms = app.FindElement(By.Id("com.example:id/acceptTerms"));
terms.Check();
terms.Uncheck();
bool isChecked = terms.IsChecked;
```

## RadioButton

```csharp
RadioButton option = app.FindElement(By.Id("com.example:id/optionA"));
option.Click();
bool isSelected = option.IsSelected;
```

## Switch

```csharp
Switch darkMode = app.FindElement(By.Id("com.example:id/darkModeSwitch"));
darkMode.Toggle();
darkMode.On();
darkMode.Off();
bool isOn = darkMode.IsOn;
```

## ToggleButton

```csharp
ToggleButton wifi = app.FindElement(By.Id("com.example:id/wifiToggle"));
wifi.Toggle();
```

## Button

```csharp
Button submit = app.FindElement(By.Id("com.example:id/submitButton"));
submit.Click();
bool isEnabled = submit.IsEnabled;
```

## TextView

Wraps the Android `TextView` (read-only text display):

```csharp
TextView header = app.FindElement(By.Id("com.example:id/headerText"));
string displayText = header.Text;
```

## View

A generic wrapper for any Android `View`:

```csharp
View container = app.FindElement(By.Id("com.example:id/mainContainer"));
bool isVisible = container.IsVisible;
```

## AndroidElementWrapper base

All Android wrappers inherit from `AndroidElementWrapper`, which provides:

| Member | Description |
|--------|-------------|
| `Element` | The underlying `AppiumElement`. |
| `Driver` | Typed `AndroidDriver` reference. |
| `IsVisible` | Whether the element is displayed. |
| `IsEnabled` | Whether the element is interactive. |
| `Click()` | Click/tap the element. |
| `GetAttribute(name)` | Read an element attribute. |
| `FindElement(locator)` | Find a child element within this control. |

## Creating custom Android wrappers

For controls not covered by the built-in wrappers, extend `AndroidElementWrapper`:

```csharp
public class RecyclerViewItem : AndroidElementWrapper
{
    public RecyclerViewItem(AppiumElement element) : base(element) { }

    public static implicit operator RecyclerViewItem(WebElement e) => new(e as AppiumElement);

    public string Title => FindElement(By.Id("com.example:id/itemTitle")).Text;

    public string Subtitle => FindElement(By.Id("com.example:id/itemSubtitle")).Text;

    public void Tap() => Click();
}
```

For more details on creating custom wrappers, see [Element wrappers](xref:core-element-wrappers).
