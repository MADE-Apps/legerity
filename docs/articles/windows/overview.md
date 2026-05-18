---
uid: windows-overview
title: Legerity.Windows
---

# Legerity.Windows

`Legerity.Windows` provides element wrappers for Windows UWP and WinUI controls, plus integration with the Windows UI Automation driver. It's the package you need for testing Windows desktop applications.

```powershell
dotnet add package Legerity.Windows
```

## What's included

| Feature | Description | Guide |
|---------|-------------|-------|
| Getting started | Driver setup, project configuration, and your first Windows test. | [Getting started](xref:windows-getting-started) |
| Element wrappers | 36 wrappers for UWP/XAML controls: TextBox, ComboBox, ListView, Slider, DatePicker, and more. | [Element wrappers](xref:windows-element-wrappers) |
| WinUI wrappers | 8 additional wrappers for WinUI 2 controls: NavigationView, NumberBox, TabView, and more. | [WinUI](xref:windows-winui) |
| Windows locators | `WindowsByExtras` with `AutomationId` locator and fluent extensions. | [Locators](xref:core-locators) |

## Driver

Legerity uses the **Legerity Windows Driver**, a modern W3C WebDriver server built with FlaUI and ASP.NET Core. It's included in this repository as the `Legerity.WindowsDriver` project. See [Windows Driver](xref:tools-windows-driver) for setup instructions.

## When to use this package

- You're testing a Windows desktop application (UWP, WinUI 2, WinUI 3, WPF with UI Automation support).
- You need typed wrappers for Windows XAML controls instead of raw `AppiumElement` interactions.
- You want `AutomationId`-based element locators.
- You're building a cross-platform suite that includes Windows desktop coverage.
