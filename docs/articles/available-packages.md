---
uid: available-packages
title: Available packages | Legerity
---

# Available Legerity packages

[Legerity](https://www.nuget.org/packages?q=Legerity) components are publicly available via NuGet.org. Each available package is detailed below.

For non-core platform controls, for example, the Windows Community Toolkit, we provide additional extension packages for you to take advantage of within your UI test projects.

| Package | Current | Preview |
| ------ | ------ | ------ |
| Legerity | [![Nuget](https://img.shields.io/nuget/v/Legerity.svg)](https://www.nuget.org/packages/Legerity/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.svg)](https://www.nuget.org/packages/Legerity/) |
| Legerity.Core | [![Nuget](https://img.shields.io/nuget/v/Legerity.Core.svg)](https://www.nuget.org/packages/Legerity.Core/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Core.svg)](https://www.nuget.org/packages/Legerity.Core/) |
| Legerity.Windows | [![Nuget](https://img.shields.io/nuget/v/Legerity.Windows.svg)](https://www.nuget.org/packages/Legerity.Windows/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Windows.svg)](https://www.nuget.org/packages/Legerity.Windows/) |
| Legerity.Android | [![Nuget](https://img.shields.io/nuget/v/Legerity.Android.svg)](https://www.nuget.org/packages/Legerity.Android/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Android.svg)](https://www.nuget.org/packages/Legerity.Android/) |
| Legerity.IOS | [![Nuget](https://img.shields.io/nuget/v/Legerity.IOS.svg)](https://www.nuget.org/packages/Legerity.IOS/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.IOS.svg)](https://www.nuget.org/packages/Legerity.IOS/) |
| Legerity.Web | [![Nuget](https://img.shields.io/nuget/v/Legerity.Web.svg)](https://www.nuget.org/packages/Legerity.Web/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Web.svg)](https://www.nuget.org/packages/Legerity.Web/) |
| Legerity.MADE | [![Nuget](https://img.shields.io/nuget/v/Legerity.MADE.svg)](https://www.nuget.org/packages/Legerity.MADE/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.MADE.svg)](https://www.nuget.org/packages/Legerity.MADE/) |
| Legerity.Telerik.Uwp | [![Nuget](https://img.shields.io/nuget/v/Legerity.Telerik.Uwp.svg)](https://www.nuget.org/packages/Legerity.Telerik.Uwp/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Telerik.Uwp.svg)](https://www.nuget.org/packages/Legerity.Telerik.Uwp/) |
| Legerity.WCT | [![Nuget](https://img.shields.io/nuget/v/Legerity.WCT.svg)](https://www.nuget.org/packages/Legerity.WCT/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.WCT.svg)](https://www.nuget.org/packages/Legerity.WCT/) |
| Legerity.WinUI | [![Nuget](https://img.shields.io/nuget/v/Legerity.WinUI.svg)](https://www.nuget.org/packages/Legerity.WinUI/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.WinUI.svg)](https://www.nuget.org/packages/Legerity.WinUI/) |

## Bringing your control libraries to Legerity

Do you have a collection of custom controls that you'd like to see added to the Legerity framework? Feel free to drop a feature request into our [work tracker](https://github.com/MADE-Apps/legerity/issues)!

We also encourage you to build out your custom control wrapper elements within the framework and help out our community!

## Legerity

The Legerity package is a meta-package that contains all of the core platform components of the framework including the page object pattern components, plus all Windows, Android, iOS, and Web element wrappers.

It has dependencies on the additional packages:

- Core
- Windows
- Android
- IOS
- Web

<span class="button">

[Write tests with Legerity](building-with-legerity.md)

</span>

## Core

The Core package provides the base capabilities to get you building maintainable UI tests quickly.

It includes features such as:

- BasePage, a base page object for creating maintainable UI tests following the page object pattern.
- AppManager, for configuring, launching, and managing the lifecycle of your application under test.
- ElementWrapper, a base for our platform element wrappers and the capabilities for you to build your own.

<span class="button">

[Learn the page object pattern](best-practices.md)

</span>

<span class="button">

[Discover building element wrappers](building-platform-wrappers.md)

</span>

## Windows

The Windows package provides the capabilities for building platform element wrappers for Windows applications.

It includes the base `WindowsElementWrapper` as well as the following element wrappers for core Windows controls:

- AppBarButton, a clickable app bar button element
- AppBarToggleButton, an app bar button element with a toggle state
- AutoSuggestBox, a text input element which also has auto-complete capabilities
- Button, a clickable button element
- CalendarDatePicker, a popup element with capabilities to select a date from a calendar
- CalendarView, a calendar date picker element
- CheckBox, a checkable element
- ComboBox, a drop down selector
- CommandBar, a wrapper element for displaying app bar button elements
- DatePicker, an element for selecting and validating dates
- FlipView, a carousel-like element for viewing items within a collection
- GridView, a visual list based element which shows items in a grid
- Hub, a layout element for displaying content within sections
- HyperlinkButton, a clickable URL button element
- InkToolbar, a wrapper element for displaying ink selection elements
- ListBox, a list item selector
- ListView, a visual list based element which shows items in a vertical list
- MenuFlyoutItem, a clickable element from a menu flyout
- MenuFlyoutSubItem, a clickable sub element of a menu flyout item
- PasswordBox, a text input element for secret values
- Pivot, a layout element for displaying content on pivotal pages
- ProgressBar, a visual indicator element for percentage progress
- ProgressRing, a visual indicator element for progress
- RadioButton, a selectable button element
- Slider, a value selection element that allows a value to be selected in a range
- TextBlock, a readonly text element
- TextBox, a text input element
- TimePicker, an element for selecting and validating time
- ToggleButton, a button element with a toggle state
- ToggleSwitch, a slider element with an on/off toggle state

<span class="button">

[Using the Windows package](features/windows.md)

</span>

### MADE.NET

The MADE.NET package is an extension to the Windows components providing the element wrappers for [MADE.NET UI controls](https://made-apps.github.io/MADE.NET/) for Windows applications.

It includes the following element wrappers:

- DropDownList, a drop down element capable of selecting multiple options
- InputValidator, a validation element capable of validating the state of an input element

<span class="button">

[Using the MADE.NET package](features/made-windows.md)

</span>

### Telerik for UWP

The Telerik for UWP package is an extension to the Windows components providing the element wrappers for [Telerik for UWP controls](https://www.telerik.com/universal-windows-platform-ui) for Windows applications.

It includes the following element wrappers:

- RadAutoCompleteBox, a text input element which also has auto-complete capabilities
- RadBulletGraph, a graphing element for bullet graphs
- RadBusyIndicator, a status indicator element
- RadNumericBox, a text input element for numeric values with value stepper capabilities

<span class="button">

[Using the Telerik for UWP package](features/telerik-for-uwp.md)

</span>

### Windows Community Toolkit

The Windows Community Toolkit package is an extension to the Windows components providing the element wrappers for [Windows Community Toolkit controls](https://docs.microsoft.com/en-us/windows/communitytoolkit/) for Windows applications.

It includes the following element wrappers:

- BladeView, an Azure portal-like bladed UI element which can be opened to show drill-down information
- Expander, a wrapper element capable of showing and hiding content
- InAppNotification, a popup element for displaying notifications within applications
- RadialGauge, a graphing element for a gauge

<span class="button">

[Using the Windows Community Toolkit package](features/windows-community-toolkit.md)

</span>

### Windows UI (WinUI)

The WinUI package is an extension to the Windows components providing the element wrappers for [WinUI 2 controls](https://docs.microsoft.com/en-us/windows/apps/winui/winui2/) for Windows applications.

Currently, there is no support for WinUI 3 due to limitations in the [WinAppDriver](https://github.com/microsoft/WinAppDriver/) which is used for running UI tests for Windows applications.

It includes the following element wrappers:

- MenuBar
- MenuBarItem
- NavigationView
- NavigationViewItem
- NumberBox
- TabView

<span class="button">

[Using the WinUI package](features/windows-ui.md)

</span>

## Android

The Android package provides the capabilities for building platform element wrappers for Android applications.

It includes the base `AndroidElementWrapper` as well as the following element wrappers for core Android controls:

- Button, a clickable button element
- CheckBox, a checkable element
- DatePicker, an element for selecting and validating dates
- EditText, a text input element
- RadioButton, a selectable button element
- Spinner, a drop down selector
- Switch, a slider element with an on/off toggle state
- TextView, a readonly text element
- ToggleButton, a button element with a toggle state
- View, a base for Android elements

<span class="button">

[Using the Android package](features/android.md)

</span>

## IOS

The iOS package provides the capabilities for building platform element wrappers for iOS applications.

It currently only includes the base `IOSElementWrapper` for building element wrappers for iOS controls. As we added more iOS element wrappers, we will update the documentation here.

<span class="button">

[Using the iOS package](features/ios.md)

</span>

## Web

The Web package provides the capabilities for building platform element wrappers for Web applications.

It includes the base `WebElementWrapper` as well as the following element wrappers for core Web controls:

- Button, a clickable button element
- CheckBox, a checkable element
- FileInput, an input element for uploading files
- Image, a visual element for display images
- List, an ordered or unordered list element with items
- NumberInput, a text input element for numeric values
- Option, an child option for a drop down element
- RadioButton, a selectable button element
- RangeInput, a value selection element that allows a value to be selected in a range
- Select, a drop down selector
- TextArea, a multi-line text input element
- TextInput, a default text input element

<span class="button">

[Using the Web package](features/web.md)

</span>