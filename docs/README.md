# Overview

The Legerity framework for speeding up development with .NET & Selenium or Appium is separated into multiple areas covering:

- [Writing tests with AppManager](../src/Legerity/AppManager.cs)
  - The framework is designed to provide an easy experience for writing your .NET Selenium or Appium UI tests. Using the `AppManager`, you can get going with your tests with a base test class that starts and stops your application.

- [Page Object Pattern (POP)](../src/Legerity/Pages/BasePage.cs)
  - The goal of the page object pattern is to use page objects to extract page interactions from your tests. Ideally, they will store all your selectors to find UI elements and their interactions for a page. 

- Platform control wrappers
  - The goal of the platform control wrappers is to provide a set of elements that surface up properties and actions of the actual UI controls. This makes it easier for you to write tests that interact with them. 

## Writing tests with AppManager

Writing UI tests should be simple and easy to get going. 

Legerity exposes an AppManager` that is a lightweight wrapper for the application driver that allows you to start your applications using a configuration object.

[Read more about testing with AppManager](WritingTests.md)

## Page Object Pattern (POP)

The page object pattern has been implemented simply and easily to start utilizing in your UI test projects. 

The Windows Alarms And Clock sample project provides an easy-to-understand example of how to implement a page within your tests. Take a look at the [EditAlarmPage](../samples/WindowsAlarmsAndClock/Pages/EditAlarmPage.cs) to get started.

[Read more about implementing POP](POP.md).

## Platform control wrappers

Platform control wrappers are as simple as they sound. They are a wrapper around the associated element (AppiumWebElement, WindowsElement, AndroidElement, etc.) which provides better actions for interaction and exposed properties to give you an easier development experience with UI tests. 

Currently, the project supports Windows, Android, and iOS elements with a plan to expand to web-specific components.

These are built in a way that also allows you to extend the base wrapper to create wrappers for your custom controls! 

[Read more about using control wrappers](ControlWrappers.md)