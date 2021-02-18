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
        private readonly By closableBarWithOptsQuery = ByExtensions.AutomationId("TestInfoBar1");

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='InfoBar'][@AutomationId='TitleTextBlock']");

        public InfoBarPage CloseClosableBarWithOptions()
        {
            InfoBar closeableBarWithOpts = this.WindowsApp.FindElement(this.closableBarWithOptsQuery);
            closeableBarWithOpts.Close();
            return this;
        }
    }
}