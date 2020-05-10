namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.WinUI;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    using XamlControlsGallery.Pages.BasicInput;
    using XamlControlsGallery.Pages.DateAndTime;
    using XamlControlsGallery.Pages.MenusAndToolbars;
    using XamlControlsGallery.Pages.Text;

    /// <summary>
    /// Defines a helper for navigating the application's menu.
    /// </summary>
    public class NavigationMenu : BasePage
    {
        private readonly By controlsSearchBoxQuery = ByExtensions.AutomationId("controlsSearchBox");

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationMenu"/> class.
        /// </summary>
        public NavigationMenu()
        {
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => ByExtensions.AutomationId("NavigationViewControl");

        /// <summary>
        /// Navigates to the app bar toggle button control page.
        /// </summary>
        /// <returns>
        /// The <see cref="AppBarToggleButtonPage"/>.
        /// </returns>
        public AppBarToggleButtonPage GoToAppBarToggleButton()
        {
            this.SearchForControl("AppBarToggleButton");
            return new AppBarToggleButtonPage();
        }

        /// <summary>
        /// Navigates to the auto-suggest box control page.
        /// </summary>
        /// <returns>
        /// The <see cref="AutoSuggestBoxPage"/>.
        /// </returns>
        public AutoSuggestBoxPage GoToAutoSuggestBox()
        {
            this.SearchForControl("AutoSuggestBox");
            return new AutoSuggestBoxPage();
        }

        /// <summary>
        /// Navigates to the combo box control page.
        /// </summary>
        /// <returns>
        /// The <see cref="ComboBoxPage"/>.
        /// </returns>
        public ComboBoxPage GoToComboBox()
        {
            this.SearchForControl("ComboBox");
            return new ComboBoxPage();
        }

        /// <summary>
        /// Navigates to the date picker control page.
        /// </summary>
        /// <returns>
        /// The <see cref="DatePickerPage"/>.
        /// </returns>
        public DatePickerPage GoToDatePicker()
        {
            this.SearchForControl("DatePicker");
            return new DatePickerPage();
        }

        /// <summary>
        /// Navigates to the slider control page.
        /// </summary>
        /// <returns>
        /// The <see cref="SliderPage"/>.
        /// </returns>
        public SliderPage GoToSlider()
        {
            this.SearchForControl("Slider");
            return new SliderPage();
        }
        
        /// <summary>
        /// Navigates to the time picker control page.
        /// </summary>
        /// <returns>
        /// The <see cref="TimePickerPage"/>.
        /// </returns>
        public TimePickerPage GoToTimePicker()
        {
            this.SearchForControl("TimePicker");
            return new TimePickerPage();
        }

        /// <summary>
        /// Navigates to the toggle switch control page.
        /// </summary>
        /// <returns>
        /// The <see cref="ToggleSwitchPage"/>.
        /// </returns>
        public ToggleSwitchPage GoToToggleSwitch()
        {
            this.SearchForControl("ToggleSwitch");
            return new ToggleSwitchPage();
        }

        private void SearchForControl(string control)
        {
            NavigationView navigationView = this.WindowsApp.FindElement(this.Trait);
            AutoSuggestBox controlsSearchBox = navigationView.Element.FindElement(this.controlsSearchBoxQuery);
            controlsSearchBox.SelectSuggestion(control);
        }
    }
}