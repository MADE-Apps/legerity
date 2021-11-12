namespace XamlControlsGallery.Pages.DateAndTime
{
    using System;
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the CalendarDatePickerPage page of the XAML Controls Gallery application.
    /// </summary>
    public class CalendarDatePickerPage : BasePage
    {
        public CalendarDatePicker CalendarDatePicker => this.WindowsApp.FindElement(By.ClassName(nameof(this.CalendarDatePicker)));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='CalendarDatePicker'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the calendar view's date with the specified date.
        /// </summary>
        /// <param name="date">
        /// The date to set.
        /// </param>
        /// <returns>
        /// The <see cref="CalendarViewPage"/>.
        /// </returns>
        public CalendarDatePickerPage SetCalendarDatePickerDate(DateTime date)
        {
            this.CalendarDatePicker.SetDate(date);
            return this;
        }

        /// <summary>
        /// Verifies that the calendar view date has been updated.
        /// </summary>
        /// <param name="date">
        /// The date of the calendar view to verify updated.
        /// </param>
        public void VerifyCalendarDatePickerDate(DateTime date)
        {
            string expectedValue = date.ToString("dd/MM/yyyy");

            string actual = this.CalendarDatePicker.Value;

            Assert.IsTrue(expectedValue.Equals(actual, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}