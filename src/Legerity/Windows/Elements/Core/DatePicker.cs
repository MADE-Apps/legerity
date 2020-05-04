namespace Legerity.Windows.Elements.Core
{
    using System;

    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP DatePicker control.
    /// </summary>
    public class DatePicker : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public DatePicker(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the query for the popup displayed for the date picker when invoking the control.
        /// </summary>
        public By Flyout => ByExtensions.AutomationId("DatePickerFlyoutPresenter");

        /// <summary>
        /// Gets the query for the day looping selector.
        /// </summary>
        public By DaySelector => ByExtensions.AutomationId("DayLoopingSelector");

        /// <summary>
        /// Gets the query for the month looping selector.
        /// </summary>
        public By MonthSelector => ByExtensions.AutomationId("MonthLoopingSelector");

        /// <summary>
        /// Gets the query for the year looping selector.
        /// </summary>
        public By YearSelector => ByExtensions.AutomationId("YearLoopingSelector");

        /// <summary>
        /// Gets the query for the accept button.
        /// </summary>
        public By AcceptButton => ByExtensions.AutomationId("AcceptButton");

        /// <summary>
        /// Gets the query for the dismiss button.
        /// </summary>
        public By DismissButton => ByExtensions.AutomationId("DismissButton");

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="DatePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="DatePicker"/>.
        /// </returns>
        public static implicit operator DatePicker(WindowsElement element)
        {
            return new DatePicker(element);
        }

        /// <summary>
        /// Sets the date to the specified date.
        /// </summary>
        /// <param name="date">The date to set.</param>
        public void SetDate(DateTime date)
        {
            // Taps the time picker to show the popup.
            this.Element.Click();

            // Finds the popup and changes the time.
            WindowsElement popup = this.Driver.FindElement(this.Flyout);
            popup.FindElement(this.DaySelector).FindElementByName(date.ToString("%d")).Click();
            popup.FindElement(this.MonthSelector).FindElementByName(date.ToString("MMMM")).Click();
            popup.FindElement(this.YearSelector).FindElementByName(date.ToString("yyyy")).Click();
            popup.FindElement(this.AcceptButton).Click();
        }
    }
}
