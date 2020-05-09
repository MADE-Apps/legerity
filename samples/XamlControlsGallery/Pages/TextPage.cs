namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the Text page of the XAML Controls Gallery application.
    /// </summary>
    public class TextPage : GroupBasePage
    {
        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='Text'][@AutomationId='TitleTextBlock']");
    }
}