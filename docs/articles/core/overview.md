---
uid: core-overview
title: Legerity.Core
---

# Legerity.Core

`Legerity.Core` is the foundation package that every other Legerity package depends on. It provides the driver lifecycle management, base types for page objects and element wrappers, locator utilities, wait conditions, and extension methods that make up the framework's core API.

```powershell
dotnet add package Legerity.Core
```

> [!NOTE]
> You typically don't install `Legerity.Core` directly. The platform-specific packages (`Legerity.Web`, `Legerity.Windows`, `Legerity.Android`, `Legerity.IOS`) reference it as a dependency. Install Core directly only if you're building custom integrations or platform support.

## What's included

| Feature | Description | Guide |
|---------|-------------|-------|
| App manager | Start, stop, and manage application drivers across platforms. Thread-safe parallel execution. | [App manager](xref:core-app-manager) |
| Test classes | Base test class that handles driver lifecycle in your test setup and teardown. | [Test classes](xref:core-test-classes) |
| Page objects | `BasePage` abstraction for modeling application pages with trait-based validation. | [Page objects](xref:core-page-objects) |
| Element wrappers | `ElementWrapper<T>` base type for wrapping native controls with rich interaction APIs. | [Element wrappers](xref:core-element-wrappers) |
| Locators | `ByAll`, `ByNested`, `ByExtras`, fluent chaining API, and platform-specific locator extensions. | [Locators](xref:core-locators) |
| Wait conditions | `WaitUntil`, `TryWaitUntil`, and pre-built condition functions for drivers, pages, and elements. | [Wait conditions](xref:core-wait-conditions) |

## When to use this package

- You're writing UI tests for any platform that Legerity supports.
- You're building custom element wrappers for a control library not covered by the built-in packages.
- You're creating a new platform integration (e.g., a custom Appium driver target).
- You want the locator utilities and wait conditions without any platform-specific wrappers.
