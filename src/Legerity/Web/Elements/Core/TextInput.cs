namespace Legerity.Web.Elements.Core
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using Web.Elements;

    /// <summary>
    /// Defines a <see cref="IWebElement"/> wrapper for the core web Input text control.
    /// </summary>
    public class TextInput : WebElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextInput"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public TextInput(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the text value of the text input.
        /// </summary>
        public string Text => this.Element.Text;

        /// <summary>
        /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="TextInput"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TextInput"/>.
        /// </returns>
        public static implicit operator TextInput(RemoteWebElement element)
        {
            return new TextInput(element);
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