# Legerity Page Object Generator

[![.NET Tool](https://img.shields.io/nuget/v/Legerity.PageObjectGenerator)](https://www.nuget.org/packages/Legerity.PageObjectGenerator/)

A dotnet CLI tool that auto-generates Legerity page objects from your application's layout files. Parses XAML (Windows), AXML (Android), Storyboard/XIB (iOS), and HTML (Web) files to produce `BasePage`-derived classes with typed element properties.

## Installation

```bash
dotnet tool install -g Legerity.PageObjectGenerator
```

**Or update an existing install**

```bash
dotnet tool update -g Legerity.PageObjectGenerator
```

## Usage

```bash
legerity-pop -i <input-folder> -o <output-folder> -n <namespace> -p <platform>
```

| Option | Description |
|--------|-------------|
| `-i`, `--input` | Path to the folder containing layout files |
| `-o`, `--output` | Path to the folder where generated `.cs` files are written |
| `-n`, `--namespace` | The C# namespace for the generated classes |
| `-p`, `--platform` | Target platform: `Windows`, `Android`, `IOS`, or `Web` |

## Quick start

```bash
legerity-pop -i ./src/MyApp/Views -o ./tests/MyApp.UITests/Pages -n MyApp.UITests.Pages -p Windows
```

This scans all layout files under the input folder, generates a `BasePage`-derived class for each page with typed element properties and locators, and writes them to the output folder.

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).
