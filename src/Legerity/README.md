# Legerity

[![NuGet](https://img.shields.io/nuget/v/Legerity.svg)](https://www.nuget.org/packages/Legerity/)

Legerity is a framework for building maintainable automated UI tests with Selenium and Appium for Windows, Android, iOS, and Web applications.

This is a meta-package that includes the core framework and all platform-specific element wrapper packages.

## Installation

```bash
dotnet add package Legerity
```

## What's included

This package bundles the following:

- **[Legerity.Core](https://www.nuget.org/packages/Legerity.Core/)** - `BasePage`, `AppManager`, `ElementWrapper`, and `ByExtras` locator extensions
- **[Legerity.Windows](https://www.nuget.org/packages/Legerity.Windows/)** - Element wrappers for Windows/UWP controls
- **[Legerity.Android](https://www.nuget.org/packages/Legerity.Android/)** - Element wrappers for Android controls
- **[Legerity.IOS](https://www.nuget.org/packages/Legerity.IOS/)** - Element wrappers for iOS controls
- **[Legerity.Web](https://www.nuget.org/packages/Legerity.Web/)** - Element wrappers for HTML controls

If you only need a specific platform, install the individual package instead.

## Quick start

```csharp
using Legerity;
using Legerity.Pages;
using OpenQA.Selenium;

public class LoginPage : BasePage
{
    protected override By Trait => By.Id("loginForm");

    public void Login(string user, string pass)
    {
        FindElement(By.Id("username")).SendKeys(user);
        FindElement(By.Id("password")).SendKeys(pass);
        FindElement(By.Id("submit")).Click();
    }
}
```

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).