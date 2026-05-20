---
uid: windows-winui
title: WinUI
---

# WinUI element wrappers

`Legerity.WinUI` provides element wrappers for WinUI 2 controls that aren't part of the standard UWP control set. These are controls from the [Microsoft.UI.Xaml](https://docs.microsoft.com/en-us/windows/apps/winui/winui2/) library.

```powershell
dotnet add package Legerity.WinUI
```

> [!NOTE]
> The `legerity-windows` project template includes `Legerity.WinUI` by default.

## NavigationView

Wraps the WinUI `NavigationView` control (the side navigation pane):

```csharp
NavigationView nav = app.FindElement(WindowsByExtras.AutomationId("MainNav"));

// Select a menu item
nav.SelectMenuItem("Settings");

// Open/close the pane
nav.OpenPane();
nav.ClosePane();

// Check pane state
bool isOpen = nav.IsPaneOpen;
```

## NavigationViewItem

Wraps individual items within a `NavigationView`:

```csharp
NavigationViewItem settingsItem = app.FindElement(WindowsByExtras.AutomationId("SettingsNav"));
settingsItem.Click();
bool isSelected = settingsItem.IsSelected;
```

## NumberBox

Wraps the WinUI `NumberBox` control with numeric input:

```csharp
NumberBox quantity = app.FindElement(WindowsByExtras.AutomationId("QuantityInput"));

double value = quantity.Value;
quantity.SetValue(42);
```

## TabView

Wraps the WinUI `TabView` control:

```csharp
TabView tabs = app.FindElement(WindowsByExtras.AutomationId("EditorTabs"));

// Select a tab
tabs.SelectTab("Document.txt");

// Close a tab
tabs.CloseTab("Document.txt");
```

## RatingControl

Wraps the WinUI `RatingControl`:

```csharp
RatingControl rating = app.FindElement(WindowsByExtras.AutomationId("ProductRating"));

double currentRating = rating.Value;
rating.SetValue(4);
```

## InfoBar

Wraps the WinUI `InfoBar` notification control:

```csharp
InfoBar infoBar = app.FindElement(WindowsByExtras.AutomationId("StatusBar"));

string title = infoBar.Title;
string message = infoBar.Message;
bool isOpen = infoBar.IsOpen;

infoBar.Close();
```

## MenuBar

Wraps the WinUI `MenuBar` control:

```csharp
MenuBar menuBar = app.FindElement(WindowsByExtras.AutomationId("MainMenuBar"));
menuBar.ClickMenuItem("File");
```

## MenuBarItem

Wraps individual items within a `MenuBar`:

```csharp
MenuBarItem fileMenu = app.FindElement(By.Name("File"));
fileMenu.Click();
```

## When to use WinUI wrappers

Use `Legerity.WinUI` when your application uses controls from the WinUI 2 library. If your app only uses standard UWP XAML controls, `Legerity.Windows` is sufficient.

For WinUI 3 (Windows App SDK) applications, the same wrappers apply since WinUI 3 controls share the same UI Automation patterns as their WinUI 2 counterparts.
