# Control wrappers

The goal of the platform control wrappers is to provide an easy set of elements that surface up properties and actions of the actual controls within the UI to make it easier for you to write tests that interact with them.

## Usage

Using a control wrapper in your test application is super simple. 

Where you want to find an element in the Appium driver that would usually return an AppiumWebElement or platform alternative, simply replace the `var` or Type with the intended control.

```csharp
Slider slider = this.Driver.FindElement(ByExtensions.AutomationId("MySlider"));
```

From there, you can access all of the additional actions and properties that are exposed by the wrapper.

## Create your own

While out-of-the-box, Legerity attempts to provide a collection of core control wrappers for a platform, we expose the parts of the framework that allow you to create elements for your own custom controls!

### Example

In this example, the application associated has a custom time picker control implementation.

It's recommended that when creating your own control wrappers, you provide the [implicit operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators) which will allow you to use your wrapper when finding an element without direct casting.

```csharp
namespace WindowsAlarmsAndClock.Elements
{
    using System;

    using Legerity.Windows.Elements;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the custom TimePicker control.
    /// </summary>
    public class CustomTimePicker : WindowsElementWrapper
    {
        private readonly By hourSelectorQuery = ByExtensions.AutomationId("HourLoopingSelector");

        private readonly By minuteSelectorQuery = ByExtensions.AutomationId("MinuteLoopingSelector");

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTimePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public CustomTimePicker(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="CustomTimePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CustomTimePicker"/>.
        /// </returns>
        public static implicit operator CustomTimePicker(WindowsElement element)
        {
            return new CustomTimePicker(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="CustomTimePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CustomTimePicker"/>.
        /// </returns>
        public static implicit operator CustomTimePicker(AppiumWebElement element)
        {
            return new CustomTimePicker(element as WindowsElement);
        }

        /// <summary>
        /// Sets the time to the specified time.
        /// </summary>
        /// <param name="time">
        /// The time to set.
        /// </param>
        public void SetTime(TimeSpan time)
        {
            this.Element.FindElement(this.hourSelectorQuery).FindElementByName(time.ToString("%h")).Click();
            this.Element.FindElement(this.minuteSelectorQuery).FindElementByName(time.ToString("mm")).Click();
        }
    }
}
```

### Platform specifics

Each of the platform-specific wrappers exposes not just the wrapper element but the driver for that application type to allow you to access more information around your control.

For example, a control may contain a popup or flyout which is displayed in a different tree to the current element, such as the [UWP InkToolbar](../src/Legerity/Windows/Elements/Core/InkToolbar.cs).

If you want to create a platform-specific wrapper, you can start by implementing one of the following platform base wrappers.

- [WindowsElementWrapper](../src/Legerity/Windows/Elements/WindowsElementWrapper.cs)
- [AndroidElementWrapper](../src/Legerity/Android/Elements/AndroidElementWrapper.cs)
- [IOSElementWrapper](../src/Legerity/IOS/Elements/IOSElementWrapper.cs)
- [WebElementWrapper](../src/Legerity/Web/Elements/WebElementWrapper.cs)

## Windows

The Windows control wrappers are designed to be used with applications built for the Windows platform.

[Discover the Windows control wrappers](Windows/WindowsControlWrappers.md)

## Android

The Android control wrappers are designed to be used with applications built for the Android platform.

[Discover the Android control wrappers](Android/AndroidControlWrappers.md)

## iOS

The iOS control wrappers are designed to be used with applications built for the iOS platform.

[Discover the iOS control wrappers](IOS/IOSControlWrappers.md)

## Web

The Web control wrappers are designed to be used with applications built for the Web.

[Discover the Web control wrappers](Web/WebControlWrappers.md)
