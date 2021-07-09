---
uid: building-platform-wrappers
title: Building platform element wrappers
---

# Building platform element wrappers

The goal of the platform element wrappers is to provide an easy set of components that surface up properties and actions of the actual controls within the UI to make it easier for you to write tests that interact with them.

## Using the platform element wrappers

Using an element wrapper in your UI tests is super simple.

Where you want to find an element in the Appium driver that would usually return an `AppiumWebElement` or platform alternative, simply replace the `var` or Type with the intended element wrapper. See our example below.

```csharp
Slider slider = this.Driver.FindElement(ByExtensions.AutomationId("MySlider"));
```

From there, you can access all of the additional actions and properties that are exposed by the element wrapper.

## Creating your own platform element wrappers

While out-of-the-box, Legerity provides a collection of core element wrappers for Windows, Android, iOS, and the Web, we expose the parts of the framework that allow you to create elements for your own custom controls!

### Example

In this example, the application under test has a custom time picker control.

It's recommended that when creating your own element wrappers, you provide the [implicit operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators) that will allow you to use your wrapper when finding an element without direct casting.

```csharp
namespace WindowsAlarmsAndClock.Elements
{
    using System;

    using Legerity.Windows.Elements;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    public class CustomTimePicker : WindowsElementWrapper
    {
        private readonly By hourSelectorQuery = ByExtensions.AutomationId("HourLoopingSelector");

        private readonly By minuteSelectorQuery = ByExtensions.AutomationId("MinuteLoopingSelector");

        public CustomTimePicker(WindowsElement element)
            : base(element)
        {
        }

        public static implicit operator CustomTimePicker(WindowsElement element)
        {
            return new CustomTimePicker(element);
        }

        public static implicit operator CustomTimePicker(AppiumWebElement element)
        {
            return new CustomTimePicker(element as WindowsElement);
        }

        public void SetTime(TimeSpan time)
        {
            this.Element.FindElement(this.hourSelectorQuery).FindElementByName(time.ToString("%h")).Click();
            this.Element.FindElement(this.minuteSelectorQuery).FindElementByName(time.ToString("mm")).Click();
        }
    }
}
```

### Understanding the platform specifics

Each of the platform-specific element wrappers exposes not just the wrapper element but the associated UI test driver for that application type to allow you to access more information around your control.

For example, a control may contain a popup or flyout that is displayed in a different UI tree to the current element, such as the [Windows InkToolbar](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Windows/Elements/Core/InkToolbar.cs).

If you want to create a platform-specific wrapper, you can start by implementing one of the following platform base wrappers.

- [WindowsElementWrapper](https://github.com/MADE-Apps/legerity/blob/main/src/Legerit.Windows/Elements/WindowsElementWrapper.cs)
- [AndroidElementWrapper](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Android/Elements/AndroidElementWrapper.cs)
- [IOSElementWrapper](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.IOS/Elements/IOSElementWrapper.cs)
- [WebElementWrapper](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Web/Elements/WebElementWrapper.cs)

## Using Windows element wrappers

The Windows element wrappers are designed to be used with applications built for the Windows platform.

[Discover the Windows element wrappers](features/windows.md)

## Using Android element wrappers

The Android element wrappers are designed to be used with applications built for the Android platform.

[Discover the Android element wrappers](features/android.md)

## Using iOS element wrappers

The iOS element wrappers are designed to be used with applications built for the iOS platform.

[Discover the iOS element wrappers](features/ios.md)

## Using Web element wrappers

The Web element wrappers are designed to be used with applications built for the Web.

[Discover the Web element wrappers](features/web.md)
