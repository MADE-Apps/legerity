namespace Legerity.Windows.Elements.Core
{
    using System;

    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP TimePicker control.
    /// </summary>
    public class TimePicker : WindowsElementWrapper
    {
        private readonly By flyoutQuery = ByExtensions.AutomationId("TimePickerFlyoutPresenter");

        private readonly By hourSelectorQuery = ByExtensions.AutomationId("HourLoopingSelector");

        private readonly By minuteSelectorQuery = ByExtensions.AutomationId("MinuteLoopingSelector");

        private readonly By acceptButtonQuery = ByExtensions.AutomationId("AcceptButton");

        private readonly By dismissButtonQuery = ByExtensions.AutomationId("DismissButton");

        /// <summary>
        /// Initializes a new instance of the <see cref="TimePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public TimePicker(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="TimePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TimePicker"/>.
        /// </returns>
        public static implicit operator TimePicker(WindowsElement element)
        {
            return new TimePicker(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TimePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TimePicker"/>.
        /// </returns>
        public static implicit operator TimePicker(AppiumWebElement element)
        {
            return new TimePicker(element as WindowsElement);
        }

        /// <summary>
        /// Sets the time to the specified time.
        /// </summary>
        /// <param name="time">
        /// The time to set.
        /// </param>
        public void SetTime(TimeSpan time)
        {
            // Taps the time picker to show the popup.
            this.Element.Click();

            // Finds the popup and changes the time.
            WindowsElement popup = this.Driver.FindElement(this.flyoutQuery);
            popup.FindElement(this.hourSelectorQuery).FindElementByName(time.ToString("%h")).Click();
            popup.FindElement(this.minuteSelectorQuery).FindElementByName(time.ToString("mm")).Click();
            popup.FindElement(this.acceptButtonQuery).Click();
        }
    }
}