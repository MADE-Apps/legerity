namespace Legerity.Windows.Elements.Core
{
    using System;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP CalendarDatePicker control.
    /// </summary>
    public class CalendarDatePicker : WindowsElementWrapper
    {
        private readonly By calendarPopupLocator = By.XPath(".//*[@ClassName='Popup'][@Name='Popup']");

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarDatePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public CalendarDatePicker(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the calendar flyout.
        /// </summary>
        public virtual CalendarView CalendarViewFlyout =>
            this.Driver.FindElement(this.calendarPopupLocator).FindElement(WindowsByExtras.AutomationId("CalendarView"));

        /// <summary>
        /// Gets the value of the calendar date picker.
        /// </summary>
        public virtual string Value => this.GetValue();

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="CalendarDatePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CalendarDatePicker"/>.
        /// </returns>
        public static implicit operator CalendarDatePicker(WindowsElement element)
        {
            return new CalendarDatePicker(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="CalendarDatePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CalendarDatePicker"/>.
        /// </returns>
        public static implicit operator CalendarDatePicker(AppiumWebElement element)
        {
            return new CalendarDatePicker(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="CalendarDatePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CalendarDatePicker"/>.
        /// </returns>
        public static implicit operator CalendarDatePicker(RemoteWebElement element)
        {
            return new CalendarDatePicker(element as WindowsElement);
        }

        /// <summary>
        /// Sets the selected date of the calendar view.
        /// </summary>
        /// <param name="date">The date to set to.</param>
        public virtual void SetDate(DateTime date)
        {
            this.Click();

            this.VerifyDriverElementShown(this.calendarPopupLocator, TimeSpan.FromSeconds(2));

            this.CalendarViewFlyout.SetDate(date);
        }
    }
}