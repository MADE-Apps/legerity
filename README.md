<img src="assets/ProjectBanner.png" alt="Legerity project banner" />

# Legerity

Legerity is a framework for building maintainable automated UI tests with speed for Windows, Android, iOS, and Web applications with C#. It simplifies the development by providing easy-to-use element wrappers for native app controls that allow developers to quickly get up and running with UI tests in no time.

Legerity also provides a best practice page object pattern for building UI tests with a maintainable structure. Together with native app control wrappers, Legerity provides the best experience for building maintainable UI automation with speed.

## Support Legerity ♥

As many developers know, projects like Legerity are built and maintained in spare time. If you find this project useful, please **Star** the repo and if possible, sponsor the project development on GitHub. 

## Build Status

| Build | Status | Current Version |
| ------ | ------ | ------ |
| GitHub Actions | [![CI](https://github.com/MADE-Apps/legerity/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/MADE-Apps/legerity/actions/workflows/ci.yml) | [![Nuget](https://img.shields.io/nuget/v/Legerity.svg)](https://www.nuget.org/packages/Legerity/) |

## Installation 💾

Legerity is publicly available via NuGet. Each available package is detailed below. 

For non-core platform controls, for example, WinUI or the Windows Community Toolkit, we're providing additional extension packages for you to take advantage of within your test projects.

| Package | Current | Preview |
| ------ | ------ | ------ |
| Legerity | [![Nuget](https://img.shields.io/nuget/v/Legerity.svg)](https://www.nuget.org/packages/Legerity/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.svg)](https://www.nuget.org/packages/Legerity/) |
| Legerity.Core | [![Nuget](https://img.shields.io/nuget/v/Legerity.Core.svg)](https://www.nuget.org/packages/Legerity.Core/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Core.svg)](https://www.nuget.org/packages/Legerity.Core/) |
| Legerity.Windows | [![Nuget](https://img.shields.io/nuget/v/Legerity.Windows.svg)](https://www.nuget.org/packages/Legerity.Windows/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Windows.svg)](https://www.nuget.org/packages/Legerity.Windows/) |
| Legerity.Android | [![Nuget](https://img.shields.io/nuget/v/Legerity.Android.svg)](https://www.nuget.org/packages/Legerity.Android/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Android.svg)](https://www.nuget.org/packages/Legerity.Android/) |
| Legerity.IOS | [![Nuget](https://img.shields.io/nuget/v/Legerity.IOS.svg)](https://www.nuget.org/packages/Legerity.IOS/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.IOS.svg)](https://www.nuget.org/packages/Legerity.IOS/) |
| Legerity.Web | [![Nuget](https://img.shields.io/nuget/v/Legerity.Web.svg)](https://www.nuget.org/packages/Legerity.Web/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Web.svg)](https://www.nuget.org/packages/Legerity.Web/) |
| Legerity.MADE | [![Nuget](https://img.shields.io/nuget/v/Legerity.MADE.svg)](https://www.nuget.org/packages/Legerity.MADE/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.MADE.svg)](https://www.nuget.org/packages/Legerity.MADE/) |
| Legerity.Telerik.Uwp | [![Nuget](https://img.shields.io/nuget/v/Legerity.Telerik.Uwp.svg)](https://www.nuget.org/packages/Legerity.Telerik.Uwp/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.Telerik.Uwp.svg)](https://www.nuget.org/packages/Legerity.Telerik.Uwp/) |
| Legerity.WCT | [![Nuget](https://img.shields.io/nuget/v/Legerity.WCT.svg)](https://www.nuget.org/packages/Legerity.WCT/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.WCT.svg)](https://www.nuget.org/packages/Legerity.WCT/) |
| Legerity.WinUI | [![Nuget](https://img.shields.io/nuget/v/Legerity.WinUI.svg)](https://www.nuget.org/packages/Legerity.WinUI/) | [![Nuget](https://img.shields.io/nuget/vpre/Legerity.WinUI.svg)](https://www.nuget.org/packages/Legerity.WinUI/) |

## Documentation 📃

If you want to deep dive into the Legerity framework with details on how to use the features, you can browse the [documentation](docs/README.md) for help getting up and running!

## Contributing 🚀

Looking to help build Legerity? Take a look through our [contribution guidelines](CONTRIBUTING.md). We actively encourage you to jump in and help with any issues!

## Building Legerity

Legerity is built using .NET Standard, taking advantage of the new SDK-style projects.

You can build the solution using Visual Studio with the following workloads installed:

- .NET desktop development
- .NET Core cross-platform development

## Got controls? 🤔

Do you have a collection of custom controls that you'd like to see added to the Legerity framework? Feel free to drop a feature request into our [work tracker](https://github.com/MADE-Apps/legerity/issues)!

Even better, why not help build out your custom control wrapper elements within the framework and help out the community!

### UI Automation tooling

When contributing to new element wrappers, we recommended using the [Accessibility Insights tool](https://accessibilityinsights.io/en/). The tool is capable of inspecting and providing property values for Android, Web, and Windows applications.

Alternatively, you can use the [Inspect.exe tool](https://docs.microsoft.com/en-us/windows/win32/winauto/inspect-objects) for Windows applications installed with the Windows SDKs. This is not recommended as the tool is considered legacy and can often cause oddities in UI when using. 

## License

Legerity is made available under the terms and conditions of the [MIT license](LICENSE).
