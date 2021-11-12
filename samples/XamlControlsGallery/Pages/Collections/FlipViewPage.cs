namespace XamlControlsGallery.Pages.Collections
{
    using System.Linq;

    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the FlipView page of the XAML Controls Gallery application.
    /// </summary>
    public class FlipViewPage : BasePage
    {
        private readonly By flipViewLocator = By.ClassName(nameof(FlipView));

        public FlipView XamlFlipView => this.WindowsApp.FindElements(this.flipViewLocator).LastOrDefault();

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='FlipView'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Selects a flip view item of the XAML flip view.
        /// </summary>
        /// <param name="name">The name of the item to select.</param>
        /// <returns>The <see cref="FlipViewPage"/>.</returns>
        public FlipViewPage SelectXamlFlipViewItem(string name)
        {
            this.XamlFlipView.SelectItem(name);
            return this;
        }

        /// <summary>
        /// Verifies the XAML flip view item.
        /// </summary>
        /// <param name="expectedItem">
        /// The expected item.
        /// </param>
        public void VerifyXamlFlipViewItem(string expectedItem)
        {
            Assert.AreEqual(expectedItem, this.XamlFlipView.SelectedItem.Text);
        }
    }
}