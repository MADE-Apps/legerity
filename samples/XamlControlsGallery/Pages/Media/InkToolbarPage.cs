namespace XamlControlsGallery.Pages.Media
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the InkToolbar page of the XAML Controls Gallery application.
    /// </summary>
    public class InkToolbarPage : BasePage
    {
        public InkToolbar InkToolbar => this.WindowsApp.FindElement(ByExtensions.AutomationId("inkToolbar"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='InkToolbar'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Selects the ballpoint pen option with the specified color.
        /// </summary>
        /// <param name="color">
        /// The color.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbarPage"/>.
        /// </returns>
        public InkToolbarPage SelectBallpointPenColor(string color)
        {
            this.InkToolbar.SetBallpointPenColor(color);
            return this;
        }

        /// <summary>
        /// Selects the pencil option with the specified color.
        /// </summary>
        /// <param name="color">
        /// The color.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbarPage"/>.
        /// </returns>
        public InkToolbarPage SelectPencilColor(string color)
        {
            this.InkToolbar.SetBallpointPenColor(color);
            return this;
        }

        /// <summary>
        /// Selects the highlighter option with the specified color.
        /// </summary>
        /// <param name="color">
        /// The color.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbarPage"/>.
        /// </returns>
        public InkToolbarPage SelectHighlighterColor(string color)
        {
            this.InkToolbar.SetHighlighterColor(color);
            return this;
        }
    }
}
