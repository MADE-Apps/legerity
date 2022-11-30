---
uid: getting-started
title: Getting Started
---

# Getting started

Getting started with Legerity is quick and easy! Legerity is distributed via NuGet.org, allowing you to install via a package manager.

## Supported platforms

Legerity packages target [.NET Standard 2.0](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0#select-net-standard-version). This means that you can create UI tests with [.NET](https://learn.microsoft.com/en-us/dotnet/fundamentals/implementations#net-5-and-later-versions), .NET Core, [.NET Framework](https://learn.microsoft.com/en-us/dotnet/fundamentals/implementations#net-framework), and [Mono](https://learn.microsoft.com/en-us/dotnet/fundamentals/implementations#mono)!

## Installing

Releases of Legerity are published to [NuGet.org](https://www.nuget.org/packages?q=legerity) and can be installed via your preferred package manager.

To quickly get started with a specific platform, select one of the following quick starts:

- **[Windows](xref:quick_starts_windows)**: Create UI tests for Windows apps using [WinAppDriver](https://github.com/microsoft/WinAppDriver)
- **[Android](xref:quick_starts_android)**: Take advantage of the [Appium](https://appium.io/) ecosystem to create UI tests for Android apps
- **[iOS](xref:quick_starts_ios)**: Build UI tests for iOS apps with the power of [Appium](https://appium.io/)
- **[Web](xref:quick_starts_web)**: Use your favourite browser to create UI tests for web apps using web drivers
- **[Cross-platform](xref:quick_starts_cross_platform)**: Create easy-to-maintain UI tests across multiple platforms with a single test

## Note on terminology

Throughout the documentation, you may see terms that are specific to Legerity.

A _page_ or _page object_ is a class that represents a single page in your app. This is typically a class that inherits from `BasePage` in Legerity and is used to interact with the UI elements on that page.

An _element wrapper_ is a class that represents a single UI element, e.g. an input control. It is a wrapper around the `IWebElement` interface from Selenium, allowing Legerity to provide bespoke interaction methods for the represented UI element. This is typically a class that implements the `IElementWrapper` interface in Legerity and is used to interact with the UI element.

## Let's get started

If you're not sure which platform to start with, we recommend starting with the [Web](xref:quick_starts_web) quick start. This will give you a great overview of Legerity, how to create UI tests, and how to run them.
