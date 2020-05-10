namespace Legerity.Windows.Elements.Core
{
    using System;

    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

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