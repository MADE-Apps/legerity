# Legerity for IOS

[![NuGet](https://img.shields.io/nuget/v/Legerity.IOS.svg)](https://www.nuget.org/packages/Legerity.IOS/)

iOS platform extension for the Legerity UI testing framework. Provides typed element wrappers for iOS UI controls.

## Installation

```bash
dotnet add package Legerity.IOS
```

## What's included

- **`IOSElementWrapper`** - Base wrapper for iOS UI elements
- **`IOSByExtras`** - `Label`, `PartialLabel`, `Value`, and `PartialValue` locators
- **Core element wrappers** - `Button`, `Label`, `ProgressView`, `Slider`, `Switch`, `TextField`

## Quick start

```csharp
using Legerity.IOS;
using Legerity.IOS.Elements.Core;

public class LoginPage : BasePage
{
    protected override By Trait => By.Name("loginView");

    public TextField Username => FindElement(By.Name("usernameField"));

    public TextField Password => FindElement(By.Name("passwordField"));

    public Button SignIn => FindElement(By.Name("signInButton"));
}
```

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).
