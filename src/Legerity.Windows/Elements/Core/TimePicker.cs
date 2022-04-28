namespace Legerity.Windows.Elements.Core
{
    using System;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP TimePicker control.
    /// </summary>
    public class TimePicker : WindowsElementWrapper
    {
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
        public virtual void SetTime(TimeSpan time)
        {
            // Taps the time picker to show the popup.
            this.Click();

            // Finds the popup and changes the time.
            WindowsElement popup = this.Driver.FindElement(WindowsByExtras.AutomationId("TimePickerFlyoutPresenter"));
            popup.FindElement(WindowsByExtras.AutomationId("HourLoopingSelector")).FindElementByName(time.ToString("%h")).Click();
            popup.FindElement(WindowsByExtras.AutomationId("MinuteLoopingSelector")).FindElementByName(time.ToString("mm")).Click();
            popup.FindElement(WindowsByExtras.AutomationId("AcceptButton")).Click();
        }
    }
}