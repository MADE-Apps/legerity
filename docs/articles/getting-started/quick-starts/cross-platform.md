---
uid: quick_starts_cross_platform
title: Cross Platform Quick Start
---

# Cross Platform

> This quick start will get you up and running with writing cross-platform UI tests for Android, iOS, Windows, and Web using Legerity. The approach is cross-platform framework agnostic, so whether you've built your app with Xamarin, Flutter, React Native, or any other cross-platform framework, you can use Legerity to write cross-platform UI tests for it.

## Prerequisites

This quick start requires the following:

- An understanding of Selenium and working with the [WebDriver](https://www.selenium.dev/documentation/webdriver/) APIs in .NET
- An understanding of [Appium](https://appium.io/)
- A functioning installation of the [.NET runtime and SDK](https://dotnet.microsoft.com/en-us/download)
- For iOS, a functioning installation of [Xcode](https://developer.apple.com/xcode/) on macOS with simulators installed
- For Windows, a Windows 10 or Windows 11 device with the [WinAppDriver](https://github.com/microsoft/WinAppDriver) installed

## Install Legerity templates

Legerity includes project templates to simplify the creation of new UI test projects. To install the templates, run the following command:

```powershell
dotnet new -i Legerity.Templates
```

When creating a project, the template will automatically add to an existing solution file if it can locate one, otherwise you will have to add it manually.

## Create a new cross-platform UI test project with NUnit

To create a new cross-platform UI test project with NUnit in your existing repository, created a new project folder and from within it, run the following command:

```powershell
dotnet new legerity-xplat
```

This will create a new cross-platform UI test project with the following structure:

```text
MyProject
├── Elements
├── Pages
│   └── SamplePage.cs
├── Tests
│   └── SampleTests.cs
├── BaseTestClass.cs
├── GlobalUsing.cs
├── MyProject.csproj
```

The project will include dependencies for NUnit, Appium, and Legerity for Windows (including WinUI), Android, iOS, and Web.

> [!NOTE]
> The ChromeDriver is used to demonstrate the use of the Web driver. You can run your UI tests on as many browsers as you like by installing the relevant driver NuGet package into the project and providing additional `PlatformOptions` to your `BaseTestClass`.
> Legerity supports Chrome, Firefox, Opera, Safari, Edge, and Internet Explorer.

The `BaseTestClass` class is a simple abstraction used for all of your test classes, based on the Legerity `LegerityTestClass`. The [base test class](xref:using_legerity_test_classes#the-base-test-class) is a great way to centralize common logic for your tests, to abstract the boilerplate code away from your tests, such as managing the application drivers.

The `PlatformOptions` property is used to configure all the various cross-platform drivers for the applications you want to test. You configure as many, or as few, platforms as you desire.

> [!NOTE]
> In this template, the `PlatformOptions` property is configured to launch cross-platform UI tests for Android, iOS, Windows, and Web.

The `SamplePage` and `SampleTests` classes are used to show the basic structure of a [page object](xref:using_legerity_page_objects) and [test class](xref:using_legerity_test_classes).

In this template, they highlight how to use the `App` property of the `BasePage` configured during instantiation to find a UI element specific to a platform.

This approach works well for applications that have a similar user experience across each platform.

This same approach can be used on the [element wrappers](xref:using_legerity_element_wrappers) to abstract the platform-specific logic away from your tests, ensuring an easier interface when using them in your page objects and tests.

> [!NOTE]
> The `SamplePage` and `SampleTests` classes are intended to be used as a guide for structuring tests. These should be removed and replaced with your own tests and page objects.

## Dive into more

Now that you have your test project up and running, you can dive deeper into:

- [Using the base test class](xref:using_legerity_base_test_class)
- [Creating page objects](xref:using_legerity_page_objects)
- [Creating test classes](xref:using_legerity_test_classes)
- [Locating elements with Legerity by locators](xref:using_legerity_by_locators)
- [Using and creating element wrappers](xref:using_legerity_element_wrappers)
- [Using custom conditions to wait for elements](xref:using_legerity_wait_conditions)
