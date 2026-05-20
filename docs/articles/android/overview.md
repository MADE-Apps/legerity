---
uid: android-overview
title: Legerity.Android
---

# Legerity.Android

`Legerity.Android` provides element wrappers for standard Android UI controls and Appium driver management for testing Android applications on emulators and physical devices.

```powershell
dotnet add package Legerity.Android
```

## What's included

| Feature | Description | Guide |
|---------|-------------|-------|
| Getting started | Appium setup, emulator configuration, and your first Android test. | [Getting started](xref:android-getting-started) |
| Element wrappers | 10 wrappers for standard Android controls: EditText, Spinner, DatePicker, Switch, and more. | [Element wrappers](xref:android-element-wrappers) |
| Android locators | `AndroidByExtras` with `ContentDescription` locator and fluent extensions. | [Locators](xref:core-locators) |

## When to use this package

- You're testing a native Android application on an emulator or physical device.
- You're testing a cross-platform app (Xamarin, .NET MAUI, Uno Platform) on the Android platform.
- You need typed wrappers for Android controls instead of raw `AppiumElement` interactions.
- You're building a cross-platform test suite that includes Android coverage.
