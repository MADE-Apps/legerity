<img src="assets/ProjectBanner.png" alt="Legerity project banner" />

# Legerity

<div style="margin-bottom:16px;">
    <div>
        <div><span>/<span>ləˈdʒɛr ɪ ti</span>/ (l<i>uh</i>-<b>jer</b>-i-tee)</span></div>
    </div>
    <div>
        <div>
            <div>
                <div><i><span>noun</span></i></div>
            </div>
        </div>
        <ol>
            <li>
                <div style="margin-left:20px">
                    <div class="LTKOO sY7ric">
                        <div style="display:inline" data-dobid="dfn"><span>physical or mental quickness; nimbleness;
                                agility.</span></div>
                    </div>
                </div>
            </li>
        </ol>
    </div>
</div>

[![GitHub release](https://img.shields.io/github/release/MADE-Apps/legerity.svg)](https://github.com/MADE-Apps/legerity/releases)
[![Nuget](https://img.shields.io/nuget/v/Legerity.svg)](https://www.nuget.org/packages/Legerity/)
[![Nuget Preview](https://img.shields.io/nuget/vpre/Legerity.svg?label=nuget%20%28preview%29)](https://www.nuget.org/packages/Legerity/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.Core.svg)](https://www.nuget.org/packages/Legerity)
[![Build status](https://github.com/MADE-Apps/legerity/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/MADE-Apps/legerity/actions/workflows/ci.yml)
[![Legerity docs](https://img.shields.io/badge/docs-Legerity-blue.svg)](https://made-apps.github.io/legerity/)
[![Legerity discussions](https://img.shields.io/badge/discuss-Legerity-blue.svg)](https://github.com/MADE-Apps/legerity/discussions)

Legerity is an automated UI testing framework for building maintainable tests quickly for Windows, Android, iOS, and Web applications with C#/.NET.

It simplifies the development by providing easy-to-use element wrappers for native app controls that allow developers to quickly get up and running with UI tests in no time.

Legerity also provides a best practice page object pattern for building UI tests with a maintainable structure. Together with native app control wrappers, Legerity provides the best experience for building maintainable UI automation with speed.

**[Discover what's new in Legerity](https://github.com/MADE-Apps/legerity/releases)**

## Features ⭐

- **AppManager** - A wrapper around the [Selenium WebDriver](https://github.com/SeleniumHQ/selenium) and [Appium WebDrivers](https://github.com/appium/appium-dotnet-driver) to simplify starting your UI tests. Supports running a single set of UI tests across multiple platforms or browsers.
- **Page Object Pattern** - Provides a `BasePage` that can be used to create page objects associated with pages in your application that are easy to implement and maintain.
- **[Page Object Generator](tools/Legerity.PageObjectGenerator)** - A dotnet CLI tool that automatically generates page objects from your application's XAML, AXML, HTML, and Storyboard/XIB layout files.
- **Element Wrappers** - Contains a collection of out-of-the-box wrappers for native UI elements that are easy to use with interactions.
- **[Project Templates](tools/Legerity.Templates)** - `dotnet new` templates to scaffold test projects for each platform.
- **Testing Frameworks** - Legerity is agnostic of .NET testing frameworks (e.g. NUnit, xUnit, MSTest, etc.) so you can work with what you know.
- **CI** - Legerity is also agnostic of host CI runner platforms (e.g. GitHub Actions, Azure Pipelines, etc.) and can be run anywhere.
- **Extendable** - Platform-specific packages ([Legerity.Windows](https://www.nuget.org/packages/Legerity.Windows), [Legerity.Android](https://www.nuget.org/packages/Legerity.Android), [Legerity.IOS](https://www.nuget.org/packages/Legerity.IOS), [Legerity.Web](https://www.nuget.org/packages/Legerity.Web), [Legerity.WinUI](https://www.nuget.org/packages/Legerity.WinUI)) include out-of-the-box element wrappers. Use [Legerity.Core](https://www.nuget.org/packages/Legerity.Core) to build wrappers for your own custom UI components.

## Documentation 📃

If you want to deep dive into the Legerity framework with details on how to use the features, you can browse the [documentation](https://made-apps.github.io/legerity/) for help getting up and running!

Our documentation includes usages examples, as well as API documentation for your technical reference.

## Installation 💾

Legerity is publicly available via NuGet. Each available package is detailed below.

| Package | Downloads |
| ------ | ------ |
| [![Nuget](https://img.shields.io/nuget/v/Legerity.svg?label=Legerity)](https://www.nuget.org/packages/Legerity/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.svg)](https://www.nuget.org/packages/Legerity) |
| [![Nuget](https://img.shields.io/nuget/v/Legerity.Core.svg?label=Legerity.Core)](https://www.nuget.org/packages/Legerity.Core/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.Core.svg)](https://www.nuget.org/packages/Legerity.Core) |
| [![Nuget](https://img.shields.io/nuget/v/Legerity.Windows.svg?label=Legerity.Windows)](https://www.nuget.org/packages/Legerity.Windows/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.Windows.svg)](https://www.nuget.org/packages/Legerity.Windows) |
| [![Nuget](https://img.shields.io/nuget/v/Legerity.Android.svg?label=Legerity.Android)](https://www.nuget.org/packages/Legerity.Android/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.Android.svg)](https://www.nuget.org/packages/Legerity.Android) |
| [![Nuget](https://img.shields.io/nuget/v/Legerity.IOS.svg?label=Legerity.IOS)](https://www.nuget.org/packages/Legerity.IOS/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.IOS.svg)](https://www.nuget.org/packages/Legerity.IOS) |
| [![Nuget](https://img.shields.io/nuget/v/Legerity.Web.svg?label=Legerity.Web)](https://www.nuget.org/packages/Legerity.Web/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.Web.svg)](https://www.nuget.org/packages/Legerity.Web) |
| [![Nuget](https://img.shields.io/nuget/v/Legerity.Web.Authentication.svg?label=Legerity.Web.Authentication)](https://www.nuget.org/packages/Legerity.Web.Authentication/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.Web.Authentication.svg)](https://www.nuget.org/packages/Legerity.Web.Authentication) |
| [![Nuget](https://img.shields.io/nuget/v/Legerity.WinUI.svg?label=Legerity.WinUI)](https://www.nuget.org/packages/Legerity.WinUI/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.WinUI.svg)](https://www.nuget.org/packages/Legerity.WinUI) |

### Tools

| Tool | Install |
| ------ | ------ |
| Page Object Generator | `dotnet tool install -g Legerity.PageObjectGenerator` |
| Project Templates | `dotnet new install Legerity.Templates` |
| Windows Driver | [Legerity.WindowsDriver](https://www.nuget.org/packages/Legerity.WindowsDriver/) |

## Support Legerity 💗

As many developers know, projects like Legerity are built and maintained in spare time. If you find this project useful, please **Star** the repo and if possible, sponsor the project development on GitHub.

## Contributing 🚀

Looking to help build Legerity? Take a look through our [contribution guidelines](CONTRIBUTING.md). We actively encourage you to jump in and help with any issues!

## Building Legerity 🛠

Legerity is built using .NET 10 with SDK-style projects.

You can build the solution using Visual Studio or the .NET CLI:

```bash
dotnet build src/Legerity.sln
```

## Got components? 💭

Do you have a collection of custom components that you'd like to see added to the Legerity framework? Feel free to drop a feature request into our [work tracker](https://github.com/MADE-Apps/legerity/issues)!

Even better, why not help build out your custom control wrapper elements within the framework and help out the community!

### UI Automation tooling 🧰

When contributing to new element wrappers, we recommended using the [Accessibility Insights tool](https://accessibilityinsights.io/en/). The tool is capable of inspecting and providing property values for Android, Web, and Windows applications.

Alternatively, you can use the [Inspect.exe tool](https://docs.microsoft.com/en-us/windows/win32/winauto/inspect-objects) for Windows applications installed with the Windows SDKs. This is not recommended as the tool is considered legacy and can often cause oddities in UI when using.

## License

Legerity is made available under the terms and conditions of the [MIT license](LICENSE).
