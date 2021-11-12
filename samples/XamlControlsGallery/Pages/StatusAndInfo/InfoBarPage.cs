namespace XamlControlsGallery.Pages.StatusAndInfo
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.WinUI;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the InfoBar page of the XAML Controls Gallery application.
    /// </summary>
    public class InfoBarPage : BasePage
    {
        public InfoBar CloseableBarWithOpts => this.WindowsApp.FindElement(ByExtensions.AutomationId("TestInfoBar1"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='InfoBar'][@AutomationId='TitleTextBlock']");

        public InfoBarPage CloseClosableBarWithOptions()
        {
            this.CloseableBarWithOpts.Close();
            return this;
        }
    }
}