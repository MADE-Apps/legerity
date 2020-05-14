namespace XamlControlsGallery.Pages.Media
{
    using System.Threading;

    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the InkToolbar page of the XAML Controls Gallery application.
    /// </summary>
    public class InkToolbarPage : BasePage
    {
        private readonly By inkToolbarQuery = ByExtensions.AutomationId("inkToolbar");

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
            InkToolbar inkToolbar = this.WindowsApp.FindElement(this.inkToolbarQuery);
            inkToolbar.SetBallpointPenColor(color);
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
            InkToolbar inkToolbar = this.WindowsApp.FindElement(this.inkToolbarQuery);
            inkToolbar.SetBallpointPenColor(color);
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
            InkToolbar inkToolbar = this.WindowsApp.FindElement(this.inkToolbarQuery);
            inkToolbar.SetBallpointPenColor(color);
            return this;
        }
    }
}
