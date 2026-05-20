---
uid: windows-element-wrappers
title: Windows - Element wrappers
---

# Windows element wrappers

`Legerity.Windows` provides typed wrappers for 36 standard UWP/WinUI XAML controls. Each wrapper extends [`WindowsElementWrapper`](xref:Legerity.Windows.Elements.WindowsElementWrapper) and exposes control-specific properties and methods.

All wrappers use implicit operators for seamless casting:

```csharp
TextBox name = app.FindElement(WindowsByExtras.AutomationId("NameInput"));
ComboBox country = app.FindElement(WindowsByExtras.AutomationId("CountrySelector"));
Slider volume = app.FindElement(WindowsByExtras.AutomationId("VolumeSlider"));
```

## Text controls

### TextBox

Wraps the UWP `TextBox` control:

```csharp
TextBox input = app.FindElement(WindowsByExtras.AutomationId("NameInput"));

string text = input.Text;
bool isReadonly = input.IsReadonly;

input.SetText("John Doe");
input.AppendText(" Jr.");
input.ClearText();
```

### PasswordBox

Wraps the UWP `PasswordBox` control:

```csharp
PasswordBox password = app.FindElement(WindowsByExtras.AutomationId("PasswordInput"));
password.SetText("securepassword");
```

### TextBlock

Wraps the UWP `TextBlock` (read-only display text):

```csharp
TextBlock header = app.FindElement(WindowsByExtras.AutomationId("PageHeader"));
string displayText = header.Text;
```

### AutoSuggestBox

Wraps the UWP `AutoSuggestBox` with suggestion list support:

```csharp
AutoSuggestBox search = app.FindElement(WindowsByExtras.AutomationId("SearchBox"));
search.SetText("hello");
search.SelectSuggestion("Hello World");
```

## Selection controls

### ComboBox

Wraps the UWP `ComboBox` control:

```csharp
ComboBox combo = app.FindElement(WindowsByExtras.AutomationId("CountrySelector"));

string selected = combo.SelectedItem;
combo.SelectItem("United Kingdom");
combo.SelectItemByPartialName("United");
```

### ListBox

Wraps the UWP `ListBox` control:

```csharp
ListBox list = app.FindElement(WindowsByExtras.AutomationId("ItemList"));
list.SelectItem("Option A");
```

### ListView

Wraps the UWP `ListView` control:

```csharp
ListView listView = app.FindElement(WindowsByExtras.AutomationId("ItemList"));
listView.ClickItem("Item 1");
```

### GridView

Wraps the UWP `GridView` control:

```csharp
GridView gridView = app.FindElement(WindowsByExtras.AutomationId("PhotoGrid"));
gridView.ClickItem("Photo 1");
```

### FlipView

Wraps the UWP `FlipView` control:

```csharp
FlipView flipView = app.FindElement(WindowsByExtras.AutomationId("Carousel"));
flipView.SelectItem("Slide 2");
```

## Toggle controls

### CheckBox

```csharp
CheckBox check = app.FindElement(WindowsByExtras.AutomationId("AcceptTerms"));
check.Check();
check.Uncheck();
bool isChecked = check.IsChecked;
```

### RadioButton

```csharp
RadioButton option = app.FindElement(WindowsByExtras.AutomationId("OptionA"));
option.Click();
bool isSelected = option.IsSelected;
```

### ToggleSwitch

```csharp
ToggleSwitch toggle = app.FindElement(WindowsByExtras.AutomationId("DarkMode"));
toggle.Toggle();
toggle.On();
toggle.Off();
bool isOn = toggle.IsOn;
```

### ToggleButton

```csharp
ToggleButton toggleBtn = app.FindElement(WindowsByExtras.AutomationId("BoldButton"));
toggleBtn.Toggle();
```

### AppBarToggleButton

```csharp
AppBarToggleButton appBarToggle = app.FindElement(WindowsByExtras.AutomationId("MuteToggle"));
appBarToggle.Toggle();
```

## Input controls

### Slider

```csharp
Slider slider = app.FindElement(WindowsByExtras.AutomationId("VolumeSlider"));
double value = slider.Value;
double min = slider.Minimum;
double max = slider.Maximum;

slider.SetValue(75);
```

### DatePicker

```csharp
DatePicker datePicker = app.FindElement(WindowsByExtras.AutomationId("BirthDate"));
datePicker.SetDate(new DateTime(1990, 6, 15));
```

### TimePicker

```csharp
TimePicker timePicker = app.FindElement(WindowsByExtras.AutomationId("AlarmTime"));
timePicker.SetTime(new TimeSpan(8, 30, 0));
```

### CalendarDatePicker

```csharp
CalendarDatePicker calendarPicker = app.FindElement(WindowsByExtras.AutomationId("EventDate"));
calendarPicker.SetDate(new DateTime(2026, 12, 25));
```

### CalendarView

```csharp
CalendarView calendar = app.FindElement(WindowsByExtras.AutomationId("Calendar"));
calendar.SelectDate(new DateTime(2026, 12, 25));
```

## Button controls

### Button

```csharp
Button submit = app.FindElement(WindowsByExtras.AutomationId("SubmitButton"));
submit.Click();
```

### HyperlinkButton

```csharp
HyperlinkButton link = app.FindElement(WindowsByExtras.AutomationId("LearnMoreLink"));
link.Click();
```

### AppBarButton

```csharp
AppBarButton appBarBtn = app.FindElement(WindowsByExtras.AutomationId("SaveButton"));
appBarBtn.Click();
```

## Navigation and layout

### Pivot

```csharp
Pivot pivot = app.FindElement(WindowsByExtras.AutomationId("MainPivot"));
pivot.SelectItem("Settings");
```

### Hub

```csharp
Hub hub = app.FindElement(WindowsByExtras.AutomationId("MainHub"));
hub.SelectSection("Featured");
```

### CommandBar

```csharp
CommandBar commandBar = app.FindElement(WindowsByExtras.AutomationId("MainCommandBar"));
commandBar.ClickPrimaryButton("Save");
commandBar.OpenSecondaryMenu();
```

### ScrollViewer

```csharp
ScrollViewer scrollViewer = app.FindElement(WindowsByExtras.AutomationId("ContentScroll"));
scrollViewer.ScrollToBottom();
scrollViewer.ScrollToTop();
```

## Other controls

### ProgressBar

```csharp
ProgressBar progress = app.FindElement(WindowsByExtras.AutomationId("LoadingBar"));
double value = progress.Value;
bool isIndeterminate = progress.IsIndeterminate;
```

### ProgressRing

```csharp
ProgressRing ring = app.FindElement(WindowsByExtras.AutomationId("LoadingRing"));
bool isActive = ring.IsActive;
```

### InkToolbar

```csharp
InkToolbar inkToolbar = app.FindElement(WindowsByExtras.AutomationId("InkToolbar"));
inkToolbar.SelectTool("Pencil");
inkToolbar.OpenStencilFlyout();
```

### MenuFlyoutItem / MenuFlyoutSubItem

```csharp
MenuFlyoutItem menuItem = app.FindElement(By.Name("Cut"));
menuItem.Click();

MenuFlyoutSubItem subMenu = app.FindElement(By.Name("Alignment"));
subMenu.Click(); // Opens submenu
```

## WindowsElementWrapper base

All Windows wrappers inherit from `WindowsElementWrapper`, which provides:

| Member | Description |
|--------|-------------|
| `Element` | The underlying `AppiumElement`. |
| `Driver` | Typed `WindowsDriver` reference. |
| `IsVisible` | Whether the element is displayed. |
| `IsEnabled` | Whether the element is interactive. |
| `Click()` | Click the element. |
| `GetAttribute(name)` | Read a UI Automation property. |
| `FindElement(locator)` | Find a child element within this control. |

## Creating custom Windows wrappers

For custom or third-party controls, extend `WindowsElementWrapper`:

```csharp
public class CustomColorPicker : WindowsElementWrapper
{
    public CustomColorPicker(AppiumElement element) : base(element) { }

    public static implicit operator CustomColorPicker(WebElement e) => new(e as AppiumElement);

    public string SelectedColor => Element.GetAttribute("Value.Value");

    public void SelectColor(string colorName)
    {
        var colorSwatch = FindElement(By.Name(colorName));
        colorSwatch.Click();
    }
}
```

For more details on creating custom wrappers, see [Element wrappers](xref:core-element-wrappers).
