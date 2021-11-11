namespace Legerity.Windows.Elements.Telerik
{
    using System;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Telerik UWP RadAutoCompleteBox control.
    /// </summary>
    public class RadAutoCompleteBox : WindowsElementWrapper
    {
        private readonly By textBoxQuery = By.ClassName("TextBox");

        private readonly By listBoxQuery = ByExtensions.AutomationId("PART_SuggestionsControl");

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
        public TextBox TextBox => this.Element.FindElement(this.textBoxQuery);

        /// <summary>
        /// Gets the value of the auto-suggest box.
        /// </summary>
        public string Text => this.TextBox.Text;

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

            this.VerifyElementShown(this.listBoxQuery, TimeSpan.FromSeconds(2));

            ListBox suggestionList = this.Element.FindElement(this.listBoxQuery);
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