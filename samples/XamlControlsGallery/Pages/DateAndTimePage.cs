namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the Date and Time page of the XAML Controls Gallery application.
    /// </summary>
    public class DateAndTimePage : GroupBasePage
    {
        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='Date and Time'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Navigates to the time picker page.
        /// </summary>
        /// <returns>
        /// The <see cref="TimePickerPage"/>.
        /// </returns>
        public TimePickerPage GoToTimePicker()
        {
            this.NavigateTo("TimePicker");
            return new TimePickerPage();
        }

        /// <summary>
        /// Navigates to the date picker page.
        /// </summary>
        /// <returns>
        /// The <see cref="DatePickerPage"/>.
        /// </returns>
        public DatePickerPage GoToDatePicker()
        {
            this.NavigateTo("DatePicker");
            return new DatePickerPage();
        }
    }
}