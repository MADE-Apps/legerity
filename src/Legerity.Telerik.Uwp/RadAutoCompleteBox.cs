namespace Legerity.Windows.Elements.Telerik
{
    using System;
    using Legerity.Windows.Elements.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Telerik UWP RadAutoCompleteBox control.
    /// </summary>
    public class RadAutoCompleteBox : WindowsElementWrapper
    {
        private readonly By suggestionsControlLocator = WindowsByExtras.AutomationId("PART_SuggestionsControl");

        /// <summary>
        /// Initializes a new instance of the <see cref="RadAutoCompleteBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public RadAutoCompleteBox(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the text box.
        /// </summary>
        public virtual TextBox TextBox => this.Element.FindElement(By.ClassName("TextBox"));

        /// <summary>
        /// Gets the value of the auto-suggest box.
        /// </summary>
        public virtual string Text => this.TextBox.Text;

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="RadAutoCompleteBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadAutoCompleteBox"/>.
        /// </returns>
        public static implicit operator RadAutoCompleteBox(WindowsElement element)
        {
            return new RadAutoCompleteBox(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="RadAutoCompleteBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadAutoCompleteBox"/>.
        /// </returns>
        public static implicit operator RadAutoCompleteBox(AppiumWebElement element)
        {
            return new RadAutoCompleteBox(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="RadAutoCompleteBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadAutoCompleteBox"/>.
        /// </returns>
        public static implicit operator RadAutoCompleteBox(RemoteWebElement element)
        {
            return new RadAutoCompleteBox(element as WindowsElement);
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

            this.VerifyElementShown(this.suggestionsControlLocator, TimeSpan.FromSeconds(2));

            ListBox suggestionList = this.Element.FindElement(this.suggestionsControlLocator);
            suggestionList.ClickItem(suggestion);
        }

        /// <summary>
        /// Selects a suggestion from the auto-suggest box.
        /// </summary>
        /// <param name="value">The initial value to set.</param>
        /// <param name="partialSuggestion">The partial suggestion match to select.</param>
        public virtual void SelectSuggestionByPartialSuggestion(string value, string partialSuggestion)
        {
            this.SetText(value);

            this.VerifyElementShown(this.suggestionsControlLocator, TimeSpan.FromSeconds(2));

            ListBox suggestionList = this.Element.FindElement(this.suggestionsControlLocator);
            suggestionList.ClickItemByPartialName(partialSuggestion);
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