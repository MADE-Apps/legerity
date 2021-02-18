namespace XamlControlsGallery.Pages.DateAndTime
{
    using System;

    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the CalendarView page of the XAML Controls Gallery application.
    /// </summary>
    public class CalendarViewPage : BasePage
    {
        private readonly By calendarViewQuery = By.ClassName("CalendarView");

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='CalendarView'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the calendar view's date with the specified date.
        /// </summary>
        /// <param name="date">
        /// The date to set.
        /// </param>
        /// <returns>
        /// The <see cref="CalendarViewPage"/>.
        /// </returns>
        public CalendarViewPage SetCalendarViewDate(DateTime date)
        {
            CalendarView calendarView = this.WindowsApp.FindElement(this.calendarViewQuery);
            calendarView.SetDate(date);
            return this;
        }

        /// <summary>
        /// Verifies that the calendar view date has been updated.
        /// </summary>
        /// <param name="date">
        /// The date of the calendar view to verify updated.
        /// </param>
        public void VerifyCalendarViewDate(DateTime date)
        {
            string day = date.ToString("%d");
            string month = date.ToString("MMMM");
            string year = date.ToString("yyyy");

            CalendarView calendarView = this.WindowsApp.FindElement(this.calendarViewQuery);
            string actual = calendarView.Value;

            Assert.IsTrue(
                actual.Contains(day, StringComparison.CurrentCultureIgnoreCase)
                && actual.Contains(month, StringComparison.CurrentCultureIgnoreCase) && actual.Contains(
                    year,
                    StringComparison.CurrentCultureIgnoreCase));
        }
    }
}