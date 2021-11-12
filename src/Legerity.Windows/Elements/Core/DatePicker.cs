namespace Legerity.Windows.Elements.Core
{
    using System;

    using Legerity.Windows.Extensions;
    using OpenQA.Selenium.Appium;
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
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="DatePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="DatePicker"/>.
        /// </returns>
        public static implicit operator DatePicker(AppiumWebElement element)
        {
            return new DatePicker(element as WindowsElement);
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
            WindowsElement popup = this.Driver.FindElement(ByExtensions.AutomationId("DatePickerFlyoutPresenter"));
            popup.FindElement(ByExtensions.AutomationId("DayLoopingSelector")).FindElementByName(date.ToString("%d")).Click();
            popup.FindElement(ByExtensions.AutomationId("MonthLoopingSelector")).FindElementByName(date.ToString("MMMM")).Click();
            popup.FindElement(ByExtensions.AutomationId("YearLoopingSelector")).FindElementByName(date.ToString("yyyy")).Click();
            popup.FindElement(ByExtensions.AutomationId("AcceptButton")).Click();
        }
    }
}
