# Legerity.Core

[![NuGet](https://img.shields.io/nuget/v/Legerity.Core.svg)](https://www.nuget.org/packages/Legerity.Core/)

The core foundation of the Legerity UI testing framework. Provides the base classes and utilities for building maintainable automated UI tests with Selenium and Appium.

## Installation

```bash
dotnet add package Legerity.Core
```

## What's included

- **`BasePage`** - Base class for the page object pattern with trait verification and element finding
- **`AppManager`** - Configures, launches, and manages application driver lifecycle across platforms
- **`ElementWrapper<T>`** - Base class for building typed element wrappers around Appium elements
- **`LegerityTestClass`** - Base test class with app lifecycle management
- **`ByExtras`** - Additional locator constraints (`Text`, `PartialText`)
- **`ByAll`**, **`ByNested`**, **`ByBuilder`** - Composite locator strategies

## Quick start

```csharp
using Legerity;
using Legerity.Pages;
using OpenQA.Selenium;

public class HomePage : BasePage
{
    protected override By Trait => By.Id("home");

    public HomePage()
    {
    }

    public HomePage(WebDriver app)
        : base(app)
    {
    }
}
```

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).
