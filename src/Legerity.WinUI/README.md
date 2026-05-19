# Legerity for WinUI

[![NuGet](https://img.shields.io/nuget/v/Legerity.WinUI.svg)](https://www.nuget.org/packages/Legerity.WinUI/)

WinUI extension for the Legerity UI testing framework. Provides typed element wrappers for WinUI controls beyond the core UWP set.

## Installation

```bash
dotnet add package Legerity.WinUI
```

## What's included

- **`InfoBar`** - Inline notification bar
- **`MenuBar`** - Application menu bar
- **`MenuBarItem`** - Individual menu bar item
- **`NavigationView`** - Navigation pane control
- **`NavigationViewItem`** - Individual navigation item
- **`NumberBox`** - Numeric text input with validation
- **`RatingControl`** - Star rating input
- **`TabView`** - Tabbed document interface

## Quick start

```csharp
using Legerity.Windows;
using Legerity.Windows.Elements.WinUI;

public class MainPage : BasePage
{
    protected override By Trait => WindowsByExtras.AutomationId("MainPage");

    public NavigationView NavView => FindElement(WindowsByExtras.AutomationId("NavView"));

    public TabView Tabs => FindElement(WindowsByExtras.AutomationId("TabView"));
}
```

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).
