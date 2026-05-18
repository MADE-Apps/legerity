# Legerity.Android

[![NuGet](https://img.shields.io/nuget/v/Legerity.Android.svg)](https://www.nuget.org/packages/Legerity.Android/)

Android platform extension for the Legerity UI testing framework. Provides typed element wrappers for Android UI controls.

## Installation

```bash
dotnet add package Legerity.Android
```

## What's included

- **`AndroidElementWrapper`** - Base wrapper for Android UI elements
- **`AndroidByExtras`** - `ContentDescription` and `PartialContentDescription` locators
- **Core element wrappers** - `Button`, `CheckBox`, `DatePicker`, `EditText`, `RadioButton`, `Spinner`, `Switch`, `TextView`, `ToggleButton`, `View`

## Quick start

```csharp
using Legerity.Android;
using Legerity.Android.Elements.Core;

public class LoginPage : BasePage
{
    protected override By Trait => By.Id("loginForm");

    public EditText Username => FindElement(By.Id("usernameInput"));

    public EditText Password => FindElement(By.Id("passwordInput"));

    public Button SignIn => FindElement(By.Id("signInButton"));
}
```

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).
