namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Legerity.Extensions;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP TextBox control.
    /// </summary>
    public class TextBox : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public TextBox(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the text value of the text box.
        /// </summary>
        public string Text => this.Element.GetAttribute("Value.Value");

        /// <summary>
        /// Gets a value indicating whether the text box is in a readonly state.
        /// </summary>
        public bool IsReadonly =>
            this.Element.GetAttribute("Value.IsReadonly").Equals("True", StringComparison.CurrentCultureIgnoreCase);

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="TextBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TextBox"/>.
        /// </returns>
        public static implicit operator TextBox(WindowsElement element)
        {
            return new TextBox(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TextBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TextBox"/>.
        /// </returns>
        public static implicit operator TextBox(AppiumWebElement element)
        {
            return new TextBox(element as WindowsElement);
        }

        /// <summary>
        /// Sets the text of the text box to the specified text.
        /// </summary>
        /// <param name="text">The text to display.</param>
        public void SetText(string text)
        {
            this.ClearText();
            this.AppendText(text);
        }

        /// <summary>
        /// Appends the specified text to the text box.
        /// </summary>
        /// <param name="text">The text to append.</param>
        public void AppendText(string text)
        {
            this.Element.Click();
            this.Element.SendKeys(text);
        }

        /// <summary>
        /// Clears the text from the text box.
        /// </summary>
        public void ClearText()
        {
            this.Element.Click();
            this.Element.Clear();
        }
    }
}