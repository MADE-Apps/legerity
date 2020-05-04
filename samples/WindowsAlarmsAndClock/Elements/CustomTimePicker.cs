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
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTimePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference..
        /// </param>
        public CustomTimePicker(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the query for the hour looping selector.
        /// </summary>
        public By HourSelector => ByExtensions.AutomationId("HourLoopingSelector");

        /// <summary>
        /// Gets the query for the minute looping selector.
        /// </summary>
        public By MinuteSelector => ByExtensions.AutomationId("MinuteLoopingSelector");

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
        /// Sets the time to the specified time.
        /// </summary>
        /// <param name="time">
        /// The time to set.
        /// </param>
        public void SetTime(TimeSpan time)
        {
            this.Element.FindElement(this.HourSelector).FindElementByName(time.ToString("%h")).Click();
            this.Element.FindElement(this.MinuteSelector).FindElementByName(time.ToString("mm")).Click();
        }
    }
}