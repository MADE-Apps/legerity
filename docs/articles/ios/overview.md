---
uid: ios-overview
title: Legerity.IOS
---

# Legerity.IOS

`Legerity.IOS` provides element wrappers for standard iOS UIKit controls and Appium driver management for testing iOS applications on simulators and physical devices.

```powershell
dotnet add package Legerity.IOS
```

## What's included

| Feature | Description | Guide |
|---------|-------------|-------|
| Getting started | Appium setup, Xcode simulator configuration, and your first iOS test. | [Getting started](xref:ios-getting-started) |
| Element wrappers | 6 wrappers for standard iOS controls: TextField, Slider, Switch, Button, Label, ProgressView. | [Element wrappers](xref:ios-element-wrappers) |
| iOS locators | `IOSByExtras` with Label, Value locators and fluent extensions. | [Locators](xref:core-locators) |

## When to use this package

- You're testing a native iOS application on a simulator or physical device.
- You're testing a cross-platform app (Xamarin, .NET MAUI, Uno Platform) on the iOS platform.
- You need typed wrappers for iOS controls instead of raw `AppiumElement` interactions.
- You're building a cross-platform test suite that includes iOS coverage.
