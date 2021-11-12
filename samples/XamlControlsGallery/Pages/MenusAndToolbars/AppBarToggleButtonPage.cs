namespace XamlControlsGallery.Pages.MenusAndToolbars
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the AppBarToggleButton page of the XAML Controls Gallery application.
    /// </summary>
    public class AppBarToggleButtonPage : BasePage
    {
        public AppBarToggleButton ToggleButton => this.WindowsApp.FindElement(By.Name("SymbolIcon"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='AppBarToggleButton'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Toggles the symbol icon button.
        /// </summary>
        /// <param name="on">
        /// A value indicating whether to toggle on.
        /// </param>
        /// <returns>
        /// The <see cref="AppBarToggleButtonPage"/>.
        /// </returns>
        public AppBarToggleButtonPage ToggleSymbolIconButton(bool on)
        {
            if (on)
            {
                this.ToggleButton.ToggleOn();
            }
            else
            {
                this.ToggleButton.ToggleOff();
            }

            return this;
        }

        /// <summary>
        /// Verifies that the symbol icon button state has been updated.
        /// </summary>
        /// <param name="on">
        /// A value indicating whether the toggle should be on.
        /// </param>
        public void VerifySymbolIconButton(bool on)
        {
            Assert.AreEqual(on, this.ToggleButton.IsOn);
        }
    }
}
