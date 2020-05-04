namespace XamlControlsGallery.Pages
{
    using System;

    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines the DatePicker page of the XAML Controls Gallery application.
    /// </summary>
    public class DatePickerPage : BasePage
    {
        private readonly By simpleDatePicker;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatePickerPage"/> class.
        /// </summary>
        public DatePickerPage()
        {
            this.simpleDatePicker = By.XPath(".//*[@ClassName='DatePicker'][@Name='Pick a date']");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='DatePicker'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the simple date picker's date with the specified date.
        /// </summary>
        /// <param name="date">
        /// The date to set.
        /// </param>
        /// <returns>
        /// The <see cref="DatePickerPage"/>.
        /// </returns>
        public DatePickerPage SetSimpleDatePickerDate(DateTime date)
        {
            DatePicker datePicker = this.WindowsApp.FindElement(this.simpleDatePicker);
            datePicker.SetDate(date);
            return this;
        }

        /// <summary>
        /// Verifies that the simple date picker date has been updated.
        /// </summary>
        /// <param name="date">
        /// The date of the date picker to verify updated.
        /// </param>
        public void VerifySimpleTimePickerTime(DateTime date)
        {
            string dateString = date.ToString("dd MMMM yyyy");

            WindowsElement updatedTimePicker = this.WindowsApp.FindElement(By.Name($"Pick a date‎ {dateString} date picker"));
            Assert.IsNotNull(updatedTimePicker);
        }
    }
}