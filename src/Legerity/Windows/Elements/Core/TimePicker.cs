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
    public class TimePicker
    {
        private readonly WeakReference elementReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference..
        /// </param>
        public TimePicker(WindowsElement element)
        {
            this.elementReference = new WeakReference(element);
        }

        /// <summary>Gets the original <see cref="WindowsElement"/> reference object.</summary>
        public WindowsElement Element =>
            this.elementReference != null && this.elementReference.IsAlive
                ? this.elementReference.Target as WindowsElement
                : null;

        /// <summary>
        /// Gets the query for the hour looping selector.
        /// </summary>
        public By Hour => ByExtensions.AutomationId("HourLoopingSelector");

        /// <summary>
        /// Gets the query for the minute looping selector.
        /// </summary>
        public By Minute => ByExtensions.AutomationId("MinuteLoopingSelector");

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
            this.Element.FindElement(this.Hour).FindElementByName(time.ToString("%h")).Click();
            this.Element.FindElement(this.Minute).FindElementByName(time.ToString("mm")).Click();
        }
    }
}