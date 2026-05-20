# Legerity for Web Authentication

[![NuGet](https://img.shields.io/nuget/v/Legerity.Web.Authentication.svg)](https://www.nuget.org/packages/Legerity.Web.Authentication/)

Web authentication extension for the Legerity UI testing framework. Provides pre-built page objects for common identity provider login flows.

## Installation

```bash
dotnet add package Legerity.Web.Authentication
```

## What's included

- **`AzureAdLoginPage`** - Page object for Microsoft Entra ID (Azure AD) login
- **`FacebookLoginPage`** - Page object for Facebook login
- **`GoogleLoginPage`** - Page object for Google login

## Quick start

```csharp
using Legerity.Web.Authentication.Pages;

// Navigate to your app's login, which redirects to the identity provider
var loginPage = new AzureAdLoginPage();
loginPage.Login("user@example.com", "password");
```

## Documentation

Full documentation is available at [made-apps.github.io/legerity](https://made-apps.github.io/legerity/).

## License

This project is made available under the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).
