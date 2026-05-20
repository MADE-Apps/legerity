# Legerity Templates

[![.NET](https://img.shields.io/nuget/v/Legerity.Templates)](https://www.nuget.org/packages/Legerity.Templates/)

A `dotnet new` template pack for creating Legerity UI test projects with NUnit. Includes project templates for Android, iOS, Web, Windows, and cross-platform applications, each pre-configured with a `LegerityTestClass` base, sample tests, and a page object model folder structure.

## Installation

```bash
dotnet new install Legerity.Templates
```

**Or update an existing install**

```bash
dotnet new install Legerity.Templates
```

## Templates

| Template | Short Name | Description |
|----------|-----------|-------------|
| Android NUnit | `legerity-android` | Legerity UI Test project for Android |
| iOS NUnit | `legerity-ios` | Legerity UI Test project for iOS |
| Web NUnit | `legerity-web` | Legerity UI Test project for Web |
| Windows NUnit | `legerity-windows` | Legerity UI Test project for Windows |
| Cross-Platform NUnit | `legerity-xplat` | Legerity UI Test project for Cross-Platform apps |

## Quick start

```bash
dotnet new legerity-web -n MyApp.UITests
```

This creates a new NUnit test project with a `BaseTestClass` derived from `LegerityTestClass`, sample tests, and `Pages`/`Tests` folders ready for your page objects and test cases.

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).
