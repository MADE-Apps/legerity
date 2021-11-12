namespace Legerity.Windows.Elements.Core
{
    using System;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

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
        public CalendarView CalendarViewFlyout =>
            this.Driver.FindElement(this.calendarPopupLocator).FindElement(ByExtensions.AutomationId("CalendarView"));

        /// <summary>
        /// Gets the value of the calendar date picker.
        /// </summary>
        public string Value => this.Element.GetAttribute("Value.Value");

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
        /// Sets the selected date of the calendar view.
        /// </summary>
        /// <param name="date">The date to set to.</param>
        public void SetDate(DateTime date)
        {
            this.Element.Click();

            this.VerifyDriverElementShown(this.calendarPopupLocator, TimeSpan.FromSeconds(2));

            this.CalendarViewFlyout.SetDate(date);
        }
    }
}