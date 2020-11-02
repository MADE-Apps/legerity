namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.WinUI;
    using Legerity.Windows.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    using XamlControlsGallery.Pages.BasicInput;
    using XamlControlsGallery.Pages.Collections;
    using XamlControlsGallery.Pages.DateAndTime;
    using XamlControlsGallery.Pages.Media;
    using XamlControlsGallery.Pages.MenusAndToolbars;
    using XamlControlsGallery.Pages.Navigation;
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
        /// Navigates to the calendar date picker control page.
        /// </summary>
        /// <returns>The <see cref="CalendarDatePickerPage"/>.</returns>
        public CalendarDatePickerPage GoToCalendarDatePickerPage()
        {
            this.SearchForControl("CalendarDatePicker");
            return new CalendarDatePickerPage();
        }

        /// <summary>
        /// Navigates to the calendar view control page.
        /// </summary>
        /// <returns>The <see cref="CalendarViewPage"/>.</returns>
        public CalendarViewPage GoToCalendarViewPage()
        {
            this.SearchForControl("CalendarView");
            return new CalendarViewPage();
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
        /// Navigates to the command bar page.
        /// </summary>
        /// <returns>The <see cref="CommandBarPage"/>.</returns>
        public CommandBarPage GoToCommandBarPage()
        {
            this.SearchForControl("CommandBar");
            return new CommandBarPage();
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
        /// Navigates to the flip view control page.
        /// </summary>
        /// <returns>
        /// The <see cref="FlipViewPage"/>.
        /// </returns>
        public FlipViewPage GoToFlipViewPage()
        {
            this.SearchForControl("FlipView");
            return new FlipViewPage();
        }

        /// <summary>
        /// Navigates to the ink toolbar control page.
        /// </summary>
        /// <returns>
        /// The <see cref="InkToolbarPage"/>.
        /// </returns>
        public InkToolbarPage GoToInkToolbarPage()
        {
            this.SearchForControl("InkToolbar");
            return new InkToolbarPage();
        }

        public MenuBarPage GoToMenuBarPage()
        {
            this.SearchForControl("MenuBar");
            return new MenuBarPage();
        }

        /// <summary>
        /// Navigates to the number box control page.
        /// </summary>
        /// <returns>The <see cref="NumberBoxPage"/>.</returns>
        public NumberBoxPage GoToNumberBoxPage()
        {
            this.SearchForControl("NumberBox");
            return new NumberBoxPage();
        }

        /// <summary>
        /// Navigates to the settings page.
        /// </summary>
        /// <returns>The <see cref="SettingsPage"/>.</returns>
        public SettingsPage GoToSettingsPage()
        {
            NavigationView navigationView = this.WindowsApp.FindElement(this.Trait);
            navigationView.OpenSettings();
            return new SettingsPage();
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
        /// Navigates to the tab view control page.
        /// </summary>
        /// <returns>The <see cref="TabViewPage"/>.</returns>
        public TabViewPage GoToTabViewPage()
        {
            this.SearchForControl("TabView");
            return new TabViewPage();
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

        /// <summary>
        /// Toggles the navigation pane.
        /// </summary>
        /// <param name="open">
        /// A value indicating whether to toggle open.
        /// </param>
        /// <returns>
        /// The <see cref="NavigationMenu"/>.
        /// </returns>
        public NavigationMenu ToggleNavigationPane(bool open)
        {
            NavigationView navigationView = this.WindowsApp.FindElement(this.Trait);

            if (open)
            {
                navigationView.OpenNavigationPane();
            }
            else
            {
                navigationView.CloseNavigationPane();
            }

            return this;
        }

        /// <summary>
        /// Verifies that the navigation pane has been updated.
        /// </summary>
        /// <param name="open">
        /// A value indicating whether the pane should be open.
        /// </param>
        /// <returns>
        /// The <see cref="NavigationMenu"/>.
        /// </returns>
        public NavigationMenu VerifyToggleNavigationPane(bool open)
        {
            NavigationView navigationView = this.WindowsApp.FindElement(this.Trait);
            Assert.AreEqual(open, navigationView.IsPaneOpen);
            return this;
        }

        /// <summary>
        /// Selects a control option from the menu.
        /// </summary>
        /// <param name="expectedGroupOption">
        /// The expected group option.
        /// </param>
        /// <param name="expectedOption">
        /// The expected option.
        /// </param>
        /// <returns>
        /// The <see cref="NavigationMenu"/>.
        /// </returns>
        public NavigationMenu SelectControlOption(string expectedGroupOption, string expectedOption)
        {
            NavigationView navigationView = this.WindowsApp.FindElement(this.Trait);
            navigationView.ClickMenuOption(expectedGroupOption).ClickChildOption(expectedOption);
            return this;
        }

        private void SearchForControl(string control)
        {
            NavigationView navigationView = this.WindowsApp.FindElement(this.Trait);
            AutoSuggestBox controlsSearchBox = navigationView.Element.FindElement(this.controlsSearchBoxQuery);
            controlsSearchBox.SelectSuggestion(control);
        }
    }
}