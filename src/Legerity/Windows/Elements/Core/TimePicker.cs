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
        /// <summary>
        /// Initializes a new instance of the <see cref="TimePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference..
        /// </param>
        public TimePicker(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the query for the popup displayed for the time picker when invoking the control.
        /// </summary>
        public By Flyout => ByExtensions.AutomationId("TimePickerFlyoutPresenter");

        /// <summary>
        /// Gets the query for the hour looping selector.
        /// </summary>
        public By HourSelector => ByExtensions.AutomationId("HourLoopingSelector");

        /// <summary>
        /// Gets the query for the minute looping selector.
        /// </summary>
        public By MinuteSelector => ByExtensions.AutomationId("MinuteLoopingSelector");

        /// <summary>
        /// Gets the query for the accept button.
        /// </summary>
        public By AcceptButton => ByExtensions.AutomationId("AcceptButton");

        /// <summary>
        /// Gets the query for the dismiss button.
        /// </summary>
        public By DismissButton => ByExtensions.AutomationId("DismissButton");

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
            WindowsElement popup = this.Driver.FindElement(this.Flyout);
            popup.FindElement(this.HourSelector).FindElementByName(time.ToString("%h")).Click();
            popup.FindElement(this.MinuteSelector).FindElementByName(time.ToString("mm")).Click();
            popup.FindElement(this.AcceptButton).Click();
        }
    }
}