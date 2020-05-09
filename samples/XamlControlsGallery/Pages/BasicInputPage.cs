namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using OpenQA.Selenium;

    using XamlControlsGallery.Pages.BasicInput;

    /// <summary>
    /// Defines the Basic Input page of the XAML Controls Gallery application.
    /// </summary>
    public class BasicInputPage : GroupBasePage
    {
        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='Basic Input'][@AutomationId='TitleTextBlock']");

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
    }
}