namespace XamlControlsGallery.Pages.Text
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the AutoSuggestBox page of the XAML Controls Gallery application.
    /// </summary>
    public class AutoSuggestBoxPage : BasePage
    {
        private readonly By basicAutoSuggestBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoSuggestBoxPage"/> class.
        /// </summary>
        public AutoSuggestBoxPage()
        {
            this.basicAutoSuggestBox = By.Name("Basic AutoSuggestBox");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='AutoSuggestBox'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the auto-suggest box text to the specified text.
        /// </summary>
        /// <param name="expectedText">
        /// The expected text.
        /// </param>
        /// <returns>
        /// The <see cref="AutoSuggestBoxPage"/>.
        /// </returns>
        public AutoSuggestBoxPage SetBasicAutoSuggestBoxText(string expectedText)
        {
            AutoSuggestBox autoSuggestBox = this.WindowsApp.FindElement(this.basicAutoSuggestBox);
            autoSuggestBox.SetText(expectedText);
            return this;
        }

        /// <summary>
        /// Sets the auto-suggest box text to the specified suggestion.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expectedSuggestion">
        ///     The expected suggestion.
        /// </param>
        /// <returns>
        /// The <see cref="AutoSuggestBoxPage"/>.
        /// </returns>
        public AutoSuggestBoxPage SelectBasicAutoSuggestBoxSuggestion(string value, string expectedSuggestion)
        {
            AutoSuggestBox autoSuggestBox = this.WindowsApp.FindElement(this.basicAutoSuggestBox);
            autoSuggestBox.SelectSuggestion(value, expectedSuggestion);
            return this;
        }

        /// <summary>
        /// Verifies that the basic auto-suggest box has been updated.
        /// </summary>
        /// <param name="expectedText">
        /// The text of the auto-suggest box to verify updated.
        /// </param>
        public void VerifyBasicAutoSuggestBoxValue(string expectedText)
        {
            AutoSuggestBox autoSuggestBox = this.WindowsApp.FindElement(this.basicAutoSuggestBox);
            Assert.AreEqual(expectedText, autoSuggestBox.Text);
        }
    }
}
