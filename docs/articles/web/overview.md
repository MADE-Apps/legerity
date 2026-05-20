---
uid: web-overview
title: Legerity.Web
---

# Legerity.Web

`Legerity.Web` provides element wrappers for standard HTML form controls and browser driver management for Chrome, Firefox, Safari, and Edge. It's the package you need for testing web applications.

```powershell
dotnet add package Legerity.Web
```

## What's included

| Feature | Description | Guide |
|---------|-------------|-------|
| Getting started | Browser setup, project configuration, and your first web test. | [Getting started](xref:web-getting-started) |
| Element wrappers | 16 wrappers for standard HTML controls: inputs, selects, checkboxes, tables, forms, and more. | [Element wrappers](xref:web-element-wrappers) |
| Authentication pages | Pre-built page objects for Azure AD, Google, and Facebook login flows. | [Authentication](xref:web-authentication) |
| Web locators | `WebByExtras` with `InputType`, `ListItem`, `Option`, `TableRow` locators and fluent extensions. | [Locators](xref:core-locators) |

## Supported browsers

| Browser | Driver type | NuGet driver package |
|---------|------------|---------------------|
| Chrome | `WebAppDriverType.Chrome` | `Selenium.WebDriver.ChromeDriver` |
| Firefox | `WebAppDriverType.Firefox` | `Selenium.WebDriver.GeckoDriver` |
| Safari | `WebAppDriverType.Safari` | Built into macOS |
| Edge | `WebAppDriverType.Edge` | `Microsoft.Edge.SeleniumTools` (Selenium 4 handles natively) |

> [!NOTE]
> Opera and Internet Explorer support was removed in v1.0. Edge Chromium (`WebAppDriverType.EdgeChromium`) was also removed as redundant since `WebAppDriverType.Edge` is Chromium-based by default in Selenium 4.

## When to use this package

- You're testing a web application in one or more browsers.
- You need typed wrappers for HTML form controls instead of raw `WebElement` interactions.
- You want pre-built page objects for common third-party login flows.
- You're building a cross-platform test suite and need web coverage alongside native app tests.
