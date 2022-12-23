---
uid: quick_starts_windows
title: Windows Quick Start
---

# Windows

> This quick start will get you up and running with writing UI tests for a Windows (UWP) application using the [WinAppDriver](https://github.com/microsoft/WinAppDriver) and Legerity.

## Prerequisites

This quick start requires the following:

- An understanding of Selenium and working with the [WebDriver](https://www.selenium.dev/documentation/webdriver/) APIs in .NET
- A functioning installation of the [.NET runtime and SDK](https://dotnet.microsoft.com/en-us/download)
- A Windows 10 or Windows 11 device with the [WinAppDriver](https://github.com/microsoft/WinAppDriver) installed

## Install Legerity templates

Legerity includes project templates to simplify the creation of new UI test projects. To install the templates, run the following command:

```powershell
dotnet new -i Legerity.Templates
```

When creating a project, the template will automatically add to an existing solution file if it can locate one, otherwise you will have to add it manually.

## Create a new Windows UI test project with NUnit

To create a new Windows UI test project with NUnit in your existing repository, created a new project folder and from within it, run the following command:

```powershell
dotnet new legerity-windows
```

This will create a new Windows UI test project with the following structure:

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

The project will include dependencies for NUnit, Appium, and Legerity for Windows (including WinUI).

The `BaseTestClass` class is a simple abstraction used for all of your test classes, based on the Legerity `LegerityTestClass`. The [base test class](xref:using_legerity_test_classes#the-base-test-class) is a great way to centralize common logic for your tests, to abstract the boilerplate code away from your tests, such as managing the application drivers.

> [!NOTE]
> The `BaseTestClass` in this template is currently configured to launch the Clock application on Windows 11. This should be updated to launch your own application via the `WindowsApplication` constant.

The `SamplePage` and `SampleTests` classes are used to show the basic structure of a [page object](xref:using_legerity_page_objects) and [test class](xref:using_legerity_test_classes). In this template, they highlight the launch and verification of the landing page of the Clock application on Windows 11.

> [!NOTE]
> The `SamplePage` and `SampleTests` classes are intended to be used as a guide for structuring tests. These should be removed and replaced with your own tests and page objects.

### Run the tests

To run the tests, you can use the following command from the UI test project:

```powershell
dotnet test
```

The Clock application should launch and the tests should pass.

## Dive into more

Now that you have your test project up and running, you can dive deeper into:

- [Using the base test class](xref:using_legerity_base_test_class)
- [Creating page objects](xref:using_legerity_page_objects)
- [Creating test classes](xref:using_legerity_test_classes)
- [Locating elements with Legerity by locators](xref:using_legerity_by_locators)
- [Using and creating element wrappers](xref:using_legerity_element_wrappers)
- [Using custom conditions to wait for elements](xref:using_legerity_wait_conditions)
