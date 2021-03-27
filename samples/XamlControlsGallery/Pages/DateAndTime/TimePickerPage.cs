namespace XamlControlsGallery.Pages.DateAndTime
{
    using System;

    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines the TimePicker page of the XAML Controls Gallery application.
    /// </summary>
    public class TimePickerPage : BasePage
    {
        private readonly By simpleTimePicker;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimePickerPage"/> class.
        /// </summary>
        public TimePickerPage()
        {
            this.simpleTimePicker = By.Name("time picker");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='TimePicker'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the simple time picker's time with the specified time.
        /// </summary>
        /// <param name="time">
        /// The time to set.
        /// </param>
        /// <returns>
        /// The <see cref="TimePickerPage"/>.
        /// </returns>
        public TimePickerPage SetSimpleTimePickerTime(TimeSpan time)
        {
            TimePicker timePicker = this.WindowsApp.FindElement(this.simpleTimePicker);
            timePicker.SetTime(time);
            return this;
        }

        /// <summary>
        /// Verifies that the simple time picker time has been updated.
        /// </summary>
        /// <param name="time">
        /// The time of the time picker to verify updated.
        /// </param>
        public void VerifySimpleTimePickerTime(TimeSpan time)
        {
            string timeString = time.ToString(@"hh\:mm");

            WindowsElement updatedTimePicker = this.WindowsApp.FindElement(By.XPath($".//*[contains(@Name,\"{timeString}\")]"));
            Assert.IsNotNull(updatedTimePicker);
        }
    }
}