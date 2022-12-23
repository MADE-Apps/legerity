---
uid: using_legerity_installation
title: Installation
---

# Installation

Legerity is available as both individual NuGet packages you can install for Windows, Android, iOS, and Web, or as a single package that includes all of the Legerity packages.

We also include project templates that you can use to quickly get up and running with writing UI tests with Legerity pre-installed.

## UI test project templates

Legerity includes project templates to simplify the creation of new UI test projects. To install the templates, run the following command:

```powershell
dotnet new -i Legerity.Templates
```

Once installed, typing `dotnet new list Legerity` will list all of the available Legerity templates including:

- Legerity UI Test project for Android (`legerity-android`)
- Legerity UI Test project for Cross Platform apps (`legerity-xplat`)
- Legerity UI Test project for iOS (`legerity-ios`)
- Legerity UI Test project for Web (`legerity-web`)
- Legerity UI Test project for Windows (`legerity-windows`)

You can then create a new project by running the following command:

```powershell
dotnet new <template-name>
```

When creating a project, the template will automatically add to an existing solution file if it can locate one, otherwise you will have to add it manually.

For more information on how to use these, check out our [quick starts](xref:getting_started_quick_starts).

## Legerity packages

To install any of the Legerity packages outlined below, you can use the following command:

```powershell
dotnet add package <package-name>
```

Or you can install the package via the NuGet package manager in your IDE of choice.

### Core packages

The following core platform NuGet packages are available:

- [Legerity](https://www.nuget.org/packages/Legerity/) - The meta-package for  Legerity that includes all of the platform-specific packages
- [Legerity.Core](https://www.nuget.org/packages/Legerity.Core/) - The core package for Legerity containing the core functionality for managing apps, pages, and elements required for all platforms
- [Legerity.Android](https://www.nuget.org/packages/Legerity.Android/) - The Android platform package for Legerity containing Android specific element wrappers, extensions, and helpers
- [Legerity.IOS](https://www.nuget.org/packages/Legerity.IOS/) - The iOS platform package for Legerity containing iOS specific element wrappers, extensions, and helpers
- [Legerity.Web](https://www.nuget.org/packages/Legerity.Web/) - The Web platform package for Legerity containing Web specific element wrappers, extensions, and helpers
- [Legerity.Windows](https://www.nuget.org/packages/Legerity.Windows/) - The Windows platform package for Legerity containing Windows specific element wrappers, extensions, and helpers
- [Legerity.WinUI](https://www.nuget.org/packages/Legerity.WinUI/) - The WinUI extension package for Legerity for Windows containing WinUI specific element wrappers

### Additional packages

Legerity also offers a number of additional packages that can be used to extend the functionality of platforms and available features including:

- [Legerity.MADE](https://www.nuget.org/packages/Legerity.MADE/) - The [MADE.NET UI](https://github.com/MADE-Apps/MADE.NET-UI) extension package for Legerity for Windows containing MADE specific element wrappers
- [Legerity.Telerik.Uwp](https://www.nuget.org/packages/Legerity.Telerik.Uwp/) - The [Telerik UI for UWP](https://www.telerik.com/universal-windows-platform-ui) extension package for Legerity for Windows containing Telerik specific element wrappers
- [Legerity.WCT](https://www.nuget.org/packages/Legerity.WCT/) - The [Windows Community Toolkit](https://github.com/CommunityToolkit/WindowsCommunityToolkit) extension package for Legerity for Windows containing Windows Community Toolkit specific element wrappers
- [Legerity.Web.Authentication](https://www.nuget.org/packages/Legerity.Web.Authentication/) - The Web Authentication extension package for Legerity for Web containing page objects for authenticating with identity providers such as Azure AD, Google, and Facebook

## Page object generation tool

Legerity also offers a [page object generation tool](https://github.com/MADE-Apps/legerity/tree/main/tools/Legerity.PageObjectGenerator) that can be used to generate page objects for your apps. This tool works by pointing it at your application source pages and it will generate the page objects for you based on the elements it finds.

To install the templates, run the following command:

```powershell
dotnet tool install -g Legerity.PageObjectGenerator
```

You can find more detail on how to use the tool in the [page object generation](xref:using_legerity_page_objects#the-page-object-generator) section.
