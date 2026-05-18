---
uid: tools-templates
title: Project templates
---

# Project templates

`Legerity.Templates` is a `dotnet new` template pack that scaffolds complete NUnit test projects for each supported platform. Each template includes a base test class, sample page object, and sample test to get you running immediately.

## Installation

```powershell
dotnet new install Legerity.Templates
```

To update to the latest version:

```powershell
dotnet new update
```

## Available templates

| Short name | Platform | Description |
|-----------|----------|-------------|
| `legerity-web` | Web | Chrome-based web test project with `Legerity.Web` and ChromeDriver. |
| `legerity-windows` | Windows | Windows test project with `Legerity.Windows`, `Legerity.WinUI`, and Appium. |
| `legerity-android` | Android | Android test project with `Legerity.Android` and Appium. |
| `legerity-ios` | iOS | iOS test project with `Legerity.IOS` and Appium. |
| `legerity-xplat` | Cross-platform | Multi-platform test project with all platform packages and `TestFixtureSource`-based configuration. |

## Usage

Create a project folder and run the template:

```powershell
mkdir MyApp.UITests
cd MyApp.UITests
dotnet new legerity-web
```

If a `.sln` solution file exists in a parent directory, the template automatically adds the new project to it.

## Generated project structure

All templates produce the same structure:

```text
MyApp.UITests/
├── Elements/              # Custom element wrappers go here
├── Pages/
│   └── SamplePage.cs      # Example page object
├── Tests/
│   └── SampleTests.cs     # Example test class
├── BaseTestClass.cs        # Pre-configured LegerityTestClass
├── GlobalUsings.cs         # Common using statements
└── MyApp.UITests.csproj    # Project file with NuGet dependencies
```

### BaseTestClass

Each template's `BaseTestClass` extends `LegerityTestClass` and is pre-configured for its platform. Update the application constants (URL, AppId, etc.) to point at your application:

```csharp
// Web template
private const string WebApplication = "https://www.example.com";

// Windows template
private const string WindowsApplication = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

// Android template
private const string AndroidApplication = "com.example.myapp";
private const string AndroidApplicationActivity = "com.example.myapp.MainActivity";
```

### SamplePage and SampleTests

These are working examples that demonstrate the page object pattern and test structure. They're intended as a reference for how to organize your own tests. Replace them with your actual page objects and tests once you've verified the project builds and runs.

## Cross-platform template

The `legerity-xplat` template is designed for applications that run on multiple platforms (e.g., .NET MAUI, Uno Platform). It uses NUnit's `TestFixtureSource` to run the same tests against each platform:

```csharp
public static IEnumerable<AppManagerOptions> PlatformOptions => new List<AppManagerOptions>
{
    new WindowsAppManagerOptions { ... },
    new AndroidAppManagerOptions { ... },
    new IOSAppManagerOptions { ... },
    new WebAppManagerOptions { ... },
};
```

Each test fixture is instantiated once per platform option, so your test code runs against every platform without duplication. See [Test classes](xref:core-test-classes) for more details.

## Next steps

After scaffolding your project:

1. Update `BaseTestClass` with your application's configuration.
2. Remove `SamplePage` and `SampleTests`.
3. Create page objects for your application's pages. See [Page objects](xref:core-page-objects).
4. Write tests using those page objects. See [Test classes](xref:core-test-classes).
5. Run with `dotnet test`.
