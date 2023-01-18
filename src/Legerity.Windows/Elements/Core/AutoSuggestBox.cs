namespace Legerity.Windows.Elements.Core
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP AutoSuggestBox control.
    /// </summary>
    public class AutoSuggestBox : WindowsElementWrapper
    {
        private readonly By suggestionsPopupLocator = WindowsByExtras.AutomationId("SuggestionsPopup");

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
        public virtual AppiumWebElement SuggestionsPopup => this.Element.FindElement(this.suggestionsPopupLocator);

        /// <summary>
        /// Gets the element associated with the suggestion list when the <see cref="SuggestionsPopup"/> is shown.
        /// </summary>
        public virtual ListView SuggestionList => this.SuggestionsPopup.FindElement(WindowsByExtras.AutomationId("SuggestionsList"));

        /// <summary>
        /// Gets the element associated with the text box.
        /// </summary>
        public virtual TextBox TextBox => this.Element.FindElement(WindowsByExtras.AutomationId("TextBox"));

        /// <summary>
        /// Gets the value of the auto-suggest box.
        /// </summary>
        public virtual string Text => this.TextBox.Text;

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
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="AutoSuggestBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AutoSuggestBox"/>.
        /// </returns>
        public static implicit operator AutoSuggestBox(RemoteWebElement element)
        {
            return new AutoSuggestBox(element as WindowsElement);
        }

        /// <summary>
        /// Selects a suggestion from the auto-suggest box.
        /// </summary>
        /// <param name="suggestion">The suggestion to select.</param>
        public virtual void SelectSuggestion(string suggestion)
        {
            this.SelectSuggestion(suggestion, suggestion);
        }

        /// <summary>
        /// Selects a suggestion from the auto-suggest box.
        /// </summary>
        /// <param name="value">The initial value to set.</param>
        /// <param name="suggestion">The suggestion to select.</param>
        public virtual void SelectSuggestion(string value, string suggestion)
        {
            this.SetText(value);

            this.VerifyElementShown(this.suggestionsPopupLocator, TimeSpan.FromSeconds(2));

            this.SuggestionList.ClickItem(suggestion);
        }

        /// <summary>
        /// Selects a suggestion from the auto-suggest box.
        /// </summary>
        /// <param name="value">The initial value to set.</param>
        /// <param name="partialSuggestion">The partial suggestion match to select.</param>
        public virtual void SelectSuggestionByPartialSuggestion(string value, string partialSuggestion)
        {
            this.SetText(value);

            this.VerifyElementShown(this.suggestionsPopupLocator, TimeSpan.FromSeconds(2));

            this.SuggestionList.ClickItemByPartialName(partialSuggestion);
        }

        /// <summary>
        /// Sets the value of the auto-suggest box.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public virtual void SetText(string value)
        {
            this.TextBox.SetText(value);
        }
    }
}