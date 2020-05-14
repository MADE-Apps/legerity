namespace Legerity.Windows.Elements.Core
{
    using System;

    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP AutoSuggestBox control.
    /// </summary>
    public class AutoSuggestBox : WindowsElementWrapper
    {
        private readonly By suggestionsPopupQuery = ByExtensions.AutomationId("SuggestionsPopup");

        private readonly By textBoxQuery = ByExtensions.AutomationId("TextBox");

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoSuggestBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public AutoSuggestBox(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the suggestions popup.
        /// </summary>
        public AppiumWebElement SuggestionsPopup => this.Element.FindElement(this.suggestionsPopupQuery);

        /// <summary>
        /// Gets the element associated with the text box.
        /// </summary>
        public TextBox TextBox => this.Element.FindElement(this.textBoxQuery);

        /// <summary>
        /// Gets the value of the auto-suggest box.
        /// </summary>
        public string Text => this.TextBox.Text;

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="AutoSuggestBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AutoSuggestBox"/>.
        /// </returns>
        public static implicit operator AutoSuggestBox(WindowsElement element)
        {
            return new AutoSuggestBox(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="AutoSuggestBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AutoSuggestBox"/>.
        /// </returns>
        public static implicit operator AutoSuggestBox(AppiumWebElement element)
        {
            return new AutoSuggestBox(element as WindowsElement);
        }

        /// <summary>
        /// Selects a suggestion from the auto-suggest box.
        /// </summary>
        /// <param name="suggestion">The suggestion to select.</param>
        public void SelectSuggestion(string suggestion)
        {
            this.SelectSuggestion(suggestion, suggestion);
        }

        /// <summary>
        /// Selects a suggestion from the auto-suggest box.
        /// </summary>
        /// <param name="value">The initial value to set.</param>
        /// <param name="suggestion">The suggestion to select.</param>
        public void SelectSuggestion(string value, string suggestion)
        {
            this.SetText(value);

            this.VerifyElementShown(this.suggestionsPopupQuery, TimeSpan.FromSeconds(2));

            ListView suggestionList = this.SuggestionsPopup.FindElement(ByExtensions.AutomationId("SuggestionsList"));
            suggestionList.ClickItem(suggestion);
        }

        /// <summary>
        /// Sets the value of the auto-suggest box.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetText(string value)
        {
            this.TextBox.SetText(value);
        }
    }
}