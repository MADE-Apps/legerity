---
uid: get-started-overview
title: Overview
---

# Legerity

Legerity is a C# UI test framework built on [Selenium](https://www.selenium.dev/) and [Appium](https://appium.io/) that helps you write maintainable automated tests for Windows, Android, iOS, and Web applications.

If you've ever written raw Selenium tests, you know the pain: brittle locators, duplicated interaction logic, and test suites that break every time the UI changes. Legerity solves this with two core abstractions, **element wrappers** and **page objects**, that let you interact with UI controls at a higher level while keeping your tests readable and resilient.

## What Legerity gives you

**Element wrappers** encapsulate native platform controls (buttons, sliders, date pickers, selects) so you can interact with them using meaningful methods like `SetText()`, `SelectItem()`, and `SetValue()` instead of raw `SendKeys()` and `Click()` calls. Each wrapper handles the underlying complexity of the control for you.

**Page objects** provide a structured way to model your application's pages. You define the elements and interactions for each page once, then reuse them across all your tests. When the UI changes, you update the page object and every test that uses it stays green.

**A fluent locator API** lets you compose element queries with readable chaining syntax like `By.TagName("button").WithText("Submit")` instead of juggling XPath strings.

**Thread-safe parallel test execution** out of the box. Each test gets its own isolated driver instance via `AsyncLocal<WebDriver>`, so you can run your suite in parallel without driver conflicts.

**Framework agnostic** design means you can use NUnit, xUnit, MSTest, or any other .NET test framework. Legerity provides the infrastructure; you choose the test runner.

## Architecture

Legerity is organized as a set of NuGet packages, each targeting a specific platform:

| Package | Description |
|---------|-------------|
| `Legerity.Core` | Core framework: `AppManager`, `BasePage`, `ElementWrapper<T>`, locators, wait conditions, and extensions. Required by all other packages. |
| `Legerity.Web` | Web element wrappers and browser driver management for Chrome, Firefox, Safari, and Edge. |
| `Legerity.Windows` | Windows (UWP/WinUI) element wrappers and Windows Driver integration. |
| `Legerity.WinUI` | Additional element wrappers for WinUI 2 controls (NavigationView, NumberBox, TabView, etc.). |
| `Legerity.Android` | Android element wrappers and Appium driver management. |
| `Legerity.IOS` | iOS element wrappers and Appium driver management. |
| `Legerity.Web.Authentication` | Pre-built page objects for common web login flows (Azure AD, Google, Facebook). |
| `Legerity` | Meta-package that pulls in all platform packages for convenience. |

There are also three developer tools:

| Tool | Description |
|------|-------------|
| `Legerity.Templates` | `dotnet new` project templates for scaffolding test projects on each platform. |
| `Legerity.PageObjectGenerator` | CLI tool that generates page object classes from XAML and AXML layout files. |
| `Legerity.WindowsDriver` | A W3C WebDriver server for Windows UI Automation. Distributed as a standalone executable via NuGet. |

## Supported platforms

- **.NET 10.0** (required, .NET Standard 2.0 support was dropped in v1.0)
- **Selenium 4.35+** (via Appium 8.x)
- **Appium 8.x** for mobile and Windows
- **Browsers:** Chrome, Firefox, Safari, Edge

## Next steps

- [Quickstart](xref:get-started-quickstart) - Get your first test running in under 5 minutes.
- [What's new in v1.0](xref:whats-new-v1) - See what changed in the latest major release.
- [Migration guide: v0.x to v1.0](xref:migration-v0-to-v1) - Upgrade from the previous version.
