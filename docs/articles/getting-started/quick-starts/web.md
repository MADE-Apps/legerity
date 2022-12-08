---
uid: quick_starts_web
title: Web Quick Start
---

# Web

> This quick start will get you up and running with writing UI tests for a Web application using the [ChromeDriver](https://chromedriver.chromium.org/downloads) and Legerity.

## Prerequisites

This quick start requires the following:

- An understanding of Selenium and working with the [WebDriver](https://www.selenium.dev/documentation/webdriver/) APIs in .NET
- A functioning installation of the [.NET runtime and SDK](https://dotnet.microsoft.com/en-us/download)

## Install Legerity templates

Legerity includes project templates to simplify the creation of new UI test projects. To install the templates, run the following command:

```powershell
dotnet new -i Legerity.Templates
```

When creating a project, the template will automatically add to an existing solution file if it can locate one, otherwise you will have to add it manually.

## Create a new Web UI test project with NUnit

To create a new Web UI test project with NUnit in your existing repository, created a new project folder and from within it, run the following command:

```powershell
dotnet new legerity-web
```

This will create a new Web UI test project with the following structure:

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

The project will include dependencies for NUnit, Selenium, ChromeDriver, and Legerity for Web.

> [!NOTE]
> The ChromeDriver is used to demonstrate the use of the Web driver. You can run your UI tests on as many browsers as you like by installing the relevant driver NuGet package into the project and providing additional `PlatformOptions` to your `BaseTestClass`.

The `BaseTestClass` class is a simple abstraction used for all of your test classes, based on the Legerity `LegerityTestClass`. The [base test class](xref:using_legerity_test_classes#the-base-test-class) is a great way to centralize common logic for your tests, to abstract the boilerplate code away from your tests, such as managing the application drivers.

> [!NOTE]
> The `BaseTestClass` in this template is currently configured to launch `https://www.example.com`. This should be updated to launch your own application via the `WebApplication` constant.

The `SamplePage` and `SampleTests` classes are used to show the basic structure of a [page object](xref:using_legerity_page_objects) and [test class](xref:using_legerity_test_classes). In this template, they highlight locating the main `h1` tag and verifying the element is shown.

> [!NOTE]
> The `SamplePage` and `SampleTests` classes are intended to be used as a guide for structuring tests. These should be removed and replaced with your own tests and page objects.

### Run the tests

To run the tests, you can use the following command from the UI test project:

```powershell
dotnet test
```

Chrome should launch at the expected URL and the tests should pass.

## Dive into more

Now that you have your test project up and running, you can dive deeper into:

- [Using the base test class](xref:using_legerity_base_test_class)
- [Creating page objects](xref:using_legerity_page_objects)
- [Creating test classes](xref:using_legerity_test_classes)
- [Locating elements with Legerity by locators](xref:using_legerity_by_locators)
- [Using and creating element wrappers](xref:using_legerity_element_wrappers)
- [Using custom conditions to wait for elements](xref:using_legerity_wait_conditions)
