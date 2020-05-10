namespace XamlControlsGallery.Pages
{
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;

    using XamlControlsGallery.Pages.BasicInput;
    using XamlControlsGallery.Pages.DateAndTime;
    using XamlControlsGallery.Pages.Text;

    /// <summary>
    /// Defines the All controls page of the XAML Controls Gallery application.
    /// </summary>
    public class AllControlsPage : GroupBasePage
    {
        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => ByExtensions.AutomationId("headerImage");

        /// <summary>
        /// Navigates to the auto-suggest box page.
        /// </summary>
        /// <returns>
        /// The <see cref="AutoSuggestBoxPage"/>.
        /// </returns>
        public AutoSuggestBoxPage GoToAutoSuggestBox()
        {
            this.NavigateTo("AutoSuggestBox");
            return new AutoSuggestBoxPage();
        }

        /// <summary>
        /// Navigates to the combo-box page.
        /// </summary>
        /// <returns>
        /// The <see cref="ComboBoxPage"/>.
        /// </returns>
        public ComboBoxPage GoToComboBox()
        {
            this.NavigateTo("ComboBox");
            return new ComboBoxPage();
        }

        /// <summary>
        /// Navigates to the slider page.
        /// </summary>
        /// <returns>
        /// The <see cref="ComboBoxPage"/>.
        /// </returns>
        public SliderPage GoToSlider()
        {
            this.NavigateTo("Slider");
            return new SliderPage();
        }

        /// <summary>
        /// Navigates to the toggle switch page.
        /// </summary>
        /// <returns>The <see cref="ToggleSwitchPage"/>.</returns>
        public ToggleSwitchPage GoToToggleSwitch()
        {
            this.NavigateTo("ToggleSwitch");
            return new ToggleSwitchPage();
        }

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
