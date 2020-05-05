namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the Basic Input page of the XAML Controls Gallery application.
    /// </summary>
    public class BasicInputPage : BasePage
    {
        private readonly By controlList;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicInputPage"/> class.
        /// </summary>
        public BasicInputPage()
        {
            this.controlList = By.Name("Items In Group");
        }

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

        private void NavigateTo(string page)
        {
            GridView gridView = this.WindowsApp.FindElement(this.controlList);
            gridView.ClickItem(page);
        }
    }
}