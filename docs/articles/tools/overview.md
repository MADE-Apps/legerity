---
uid: tools-overview
title: Tools
---

# Tools

Legerity ships three developer tools that complement the test framework:

| Tool | Install | Description |
|------|---------|-------------|
| Project templates | `dotnet new install Legerity.Templates` | Scaffold test projects for each platform. | 
| Page object generator | `dotnet tool install -g Legerity.PageObjectGenerator` | Generate page object classes from layout files (XAML, AXML, Storyboard/XIB, HTML). |
| Windows Driver | [GitHub Releases](https://github.com/MADE-Apps/legerity/releases) | W3C WebDriver server for Windows UI Automation. Self-contained executable. |

## Guides

- [Project templates](xref:tools-templates) - Install and use the `dotnet new` templates.
- [Page object generator](xref:tools-page-object-generator) - Auto-generate page objects from your app's layout files.
- [Windows Driver](xref:tools-windows-driver) - Set up and run the Legerity Windows Driver server.
