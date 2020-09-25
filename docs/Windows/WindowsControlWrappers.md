# Windows control wrappers

The goal of the platform control wrappers is to provide an easy set of elements which surface up properties and actions of the actual controls within the UI to make it easier for you to write tests that interact with them. 

These Windows control wrappers are designed to be used with applications built for the Windows platform.

## UWP Core Controls

These UWP control wrappers are designed to be used with applications built with Windows 10 SDK controls. 

**NOTE**, these control wrappers will also work with the WinUI alternatives. 

### Supported

- [AppBarButton](../../src/Legerity/Windows/Elements/Core/AppBarButton.cs)
- [AppBarToggleButton](../../src/Legerity/Windows/Elements/Core/AppBarToggleButton.cs)
- [AutoSuggestBox](../../src/Legerity/Windows/Elements/Core/AutoSuggestBox.cs)
- [Button](../../src/Legerity/Windows/Elements/Core/Button.cs)
- [CalendarDatePicker](../../src/Legerity/Windows/Elements/Core/CalendarDatePicker.cs)
- [CalendarView](../../src/Legerity/Windows/Elements/Core/CalendarView.cs)
- [CheckBox](../../src/Legerity/Windows/Elements/Core/CheckBox.cs)
- [ComboBox](../../src/Legerity/Windows/Elements/Core/ComboBox.cs)
- [CommandBar](../../src/Legerity/Windows/Elements/Core/CommandBar.cs)
- [DatePicker](../../src/Legerity/Windows/Elements/Core/DatePicker.cs)
- [FlipView](../../src/Legerity/Windows/Elements/Core/FlipView.cs)
- [GridView](../../src/Legerity/Windows/Elements/Core/GridView.cs)
- [Hub](../../src/Legerity/Windows/Elements/Core/Hub.cs)
- [HyperlinkButton](../../src/Legerity/Windows/Elements/Core/HyperlinkButton.cs)
- [InkToolbar](../../src/Legerity/Windows/Elements/Core/InkToolbar.cs)
- [ListView](../../src/Legerity/Windows/Elements/Core/ListView.cs)
- [PasswordBox](../../src/Legerity/Windows/Elements/Core/PasswordBox.cs)
- [Pivot](../../src/Legerity/Windows/Elements/Core/Pivot.cs)
- [ProgressBar](../../src/Legerity/Windows/Elements/Core/ProgressBar.cs)
- [ProgressRing](../../src/Legerity/Windows/Elements/Core/ProgressRing.cs)
- [RadioButton](../../src/Legerity/Windows/Elements/Core/RadioButton.cs)
- [Slider](../../src/Legerity/Windows/Elements/Core/Slider.cs)
- [TextBox](../../src/Legerity/Windows/Elements/Core/TextBox.cs)
- [TimePicker](../../src/Legerity/Windows/Elements/Core/TimePicker.cs)
- [ToggleButton](../../src/Legerity/Windows/Elements/Core/ToggleButton.cs)
- [ToggleSwitch](../../src/Legerity/Windows/Elements/Core/ToggleSwitch.cs)

## WinUI Controls

These UWP control wrappers are designed to be used with controls from the [WinUI](https://github.com/microsoft/microsoft-ui-xaml) suite.

- [NavigationView](../../src/Legerity.WinUI/NavigationView.cs)
- [TabView](../../src/Legerity.WinUI/TabView.cs)

## Windows Community Toolkit Controls

These UWP control wrappers are designed to be used with controls from the [Windows Community Toolkit](https://github.com/windows-toolkit/WindowsCommunityToolkit) suite.

- [RadialGauge](../../src/Legerity.WCT/RadialGauge.cs)
