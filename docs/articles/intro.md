---
uid: intro
title: Introduction
---

<img src="../images/ProjectBanner.png" alt="Legerity project banner" />

# Legerity

_Legerity_ is a C# testing framework built on [Selenium](https://www.selenium.dev/) for building maintainable automated UI tests for Windows, Android, iOS, and Web applications. The framework is agnostic of unit testing framework so you can use your flavor of choice; we do however recommend and use [NUnit](https://nunit.org/) for our tests and samples.

The purpose of Legerity is to simplify the development of UI tests by providing easy-to-use element wrappers for native platform controls. This allows you to interact with the user interface as a user would: typing text into an input, toggling switches, and gestures - such as swiping through carousels.

The platform element wrappers are designed so that all of the heavy lifting of querying the right UI elements is done for you. This allows you to speed up the development of your UI tests.

Legerity also provides best practice components for writing UI tests, such as the page object pattern. This allows you to build maintainable, future-proof UI tests without requiring changes across your test suite when your application UI changes.

Together with platform element wrappers, Legerity provides the best experience for you to build maintainable UI automation with speed.

## FAQ

### Why should I use Legerity?

Do you find it difficult to get started with UI tests? Think that they take too long to build and become unmaintainable?

So did I!

That's where Legerity started, a toolkit on top of Selenium that makes my own UI test development fast and easy. This allows me to spend more time building my applications with confidence that my clients get the best, most tested experience.

### Can you write tests for cross-platform applications built with Xamarin or Uno Platform?

You sure can. Frameworks such as Xamarin and Uno Platform compile an application down to the native platform they are built for such as iOS and Android.

Using the UI automation tooling for those platforms, you can easily identify the UI elements and use our platform elements wrappers to interact with them.

We are also working on a specific [Legerity for Uno Platform](https://made-apps.github.io/legerity-uno/index.html) project that will make it simpler to build a single suite of UI tests that just work across all your app platforms.

### What tools can I use to inspect my applications UI automation tree?

There are many tools that are available to help you understand the layout of your application's UI.

Here are helpful links to each platform where you can find more information on the right tooling for the app's you're testing.

- [Windows](xref:quick_starts_windows)
- [Android](xref:quick_starts_android)
- [iOS](xref:quick_starts_ios)
- [Web](xref:quick_starts_web)

### How do you keep Legerity going?

Use of Legerity is free of charge to any one under an MIT license. The development of the project is supported by community contributions and [small sponsorships and donations](https://github.com/sponsors/jamesmcroft) where possible.

### I have a specific question, where can I ask?

If you have a query about UI testing with Legerity, please [open a discussion in our GitHub project](https://github.com/MADE-Apps/legerity/discussions).
