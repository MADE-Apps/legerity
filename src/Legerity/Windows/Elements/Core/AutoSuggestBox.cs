namespace Legerity.Windows.Elements.Core
{
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP AutoSuggestBox control.
    /// </summary>
    public class AutoSuggestBox : WindowsElementWrapper
    {
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
        /// Gets the query for the popup displayed for the auto-suggest box when invoking the control.
        /// </summary>
        public By SuggestionsPopup => ByExtensions.AutomationId("SuggestionsPopup");

        /// <summary>
        /// Gets the query for the text box of the auto-suggest box.
        /// </summary>
        public By TextBox => ByExtensions.AutomationId("TextBox");

        /// <summary>
        /// Gets the value of the auto-suggest box.
        /// </summary>
        public string Value => this.Element.GetAttribute("Value.Value");

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
            this.Element.Click();

            WindowsElement popup = this.Driver.FindElement(this.SuggestionsPopup);
            ListView suggestionList = popup.FindElement(ByExtensions.AutomationId("SuggestionsList"));
            suggestionList.ClickItem(suggestion);
        }

        /// <summary>
        /// Sets the value of the auto-suggest box.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetValue(string value)
        {
            this.Element.Click();
            this.Element.SendKeys(value);
        }
    }
}