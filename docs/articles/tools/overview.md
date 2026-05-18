---
uid: tools-overview
title: Tools
---

# Tools

Legerity ships three developer tools that complement the test framework. These are separate NuGet-distributed packages that you install globally or as project-level tools.

| Tool | Package | Command | Description |
|------|---------|---------|-------------|
| Project templates | `Legerity.Templates` | `dotnet new legerity-*` | Scaffold test projects for each platform. | 
| Page object generator | `Legerity.PageObjectGenerator` | `legerity-pop` | Generate page object classes from layout files (XAML, AXML, Storyboard/XIB, HTML). |
| Windows Driver | `Legerity.WindowsDriver` | `Legerity.WindowsDriver.exe` | W3C WebDriver server for Windows UI Automation. |

## Guides

- [Project templates](xref:tools-templates) - Install and use the `dotnet new` templates.
- [Page object generator](xref:tools-page-object-generator) - Auto-generate page objects from your app's layout files.
- [Windows Driver](xref:tools-windows-driver) - Set up and run the Legerity Windows Driver server.
