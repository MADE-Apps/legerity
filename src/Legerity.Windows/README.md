# Legerity.Windows

[![NuGet](https://img.shields.io/nuget/v/Legerity.Windows.svg)](https://www.nuget.org/packages/Legerity.Windows/)

Windows platform extension for the Legerity UI testing framework. Provides typed element wrappers for UWP and WinUI core controls.

## Installation

```bash
dotnet add package Legerity.Windows
```

## What's included

- **`WindowsElementWrapper`** - Base wrapper for Windows UI Automation elements
- **`WindowsByExtras`** - `AutomationId` locator for Windows elements
- **Core element wrappers** - `AppBarButton`, `AutoSuggestBox`, `Button`, `CalendarDatePicker`, `CalendarView`, `CheckBox`, `ComboBox`, `CommandBar`, `DatePicker`, `FlipView`, `GridView`, `Hub`, `HyperlinkButton`, `InkToolbar`, `ListBox`, `ListView`, `MenuFlyoutItem`, `MenuFlyoutSubItem`, `PasswordBox`, `Pivot`, `ProgressBar`, `ProgressRing`, `RadioButton`, `ScrollViewer`, `Slider`, `TextBlock`, `TextBox`, `TimePicker`, `ToggleButton`, `ToggleSwitch`

For WinUI-specific controls (NavigationView, NumberBox, TabView, etc.), see [Legerity.WinUI](https://www.nuget.org/packages/Legerity.WinUI/).

## Quick start

```csharp
using Legerity.Windows;
using Legerity.Windows.Elements.Core;

public class SettingsPage : BasePage
{
    protected override By Trait => WindowsByExtras.AutomationId("SettingsPage");

    public ToggleSwitch DarkMode => FindElement(WindowsByExtras.AutomationId("DarkModeToggle"));

    public Button Save => FindElement(WindowsByExtras.AutomationId("SaveButton"));
}
```

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).
