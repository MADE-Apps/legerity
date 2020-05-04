namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the Date and Time page of the XAML Controls Gallery application.
    /// </summary>
    public class DateAndTimePage : BasePage
    {
        private readonly By controlList;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateAndTimePage"/> class.
        /// </summary>
        public DateAndTimePage()
        {
            this.controlList = By.Name("Items In Group");
        }

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
            GridView gridView = this.WindowsApp.FindElement(this.controlList);
            gridView.ClickItem("TimePicker");
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
            GridView gridView = this.WindowsApp.FindElement(this.controlList);
            gridView.ClickItem("DatePicker");
            return new DatePickerPage();
        }
    }
}