# Legerity.Web

[![NuGet](https://img.shields.io/nuget/v/Legerity.Web.svg)](https://www.nuget.org/packages/Legerity.Web/)

Web platform extension for the Legerity UI testing framework. Provides typed element wrappers for HTML controls.

## Installation

```bash
dotnet add package Legerity.Web
```

## What's included

- **`WebElementWrapper`** - Base wrapper for HTML elements
- **`WebByExtras`** - `InputType`, `ListItem`, `Option`, `TableHeaderCell`, `TableRow` locators
- **Core element wrappers** - `Button`, `CheckBox`, `DateInput`, `FileInput`, `Form`, `Image`, `List`, `NumberInput`, `Option`, `RadioButton`, `RangeInput`, `Select`, `Table`, `TableRow`, `TextArea`, `TextInput`

## Quick start

```csharp
using Legerity.Web;
using Legerity.Web.Elements.Core;

public class LoginPage : BasePage
{
    protected override By Trait => By.Id("loginForm");

    public TextInput Username => FindElement(By.Id("username"));

    public TextInput Password => FindElement(By.Id("password"));

    public Button SignIn => FindElement(By.Id("signIn"));
}
```

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).
