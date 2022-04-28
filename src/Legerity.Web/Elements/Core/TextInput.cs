namespace Legerity.Web.Elements.Core
{
    using Legerity.Web.Elements;
    using Legerity.Web.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

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
        public TextInput(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextInput"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public TextInput(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the text value of the text input.
        /// </summary>
        public virtual string Text => this.GetValue();

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
        public virtual void SetText(string text)
        {
            this.ClearText();
            this.AppendText(text);
        }

        /// <summary>
        /// Appends the specified text to the text box.
        /// </summary>
        /// <param name="text">The text to append.</param>
        public virtual void AppendText(string text)
        {
            this.Click();
            this.Element.SendKeys(text);
        }

        /// <summary>
        /// Clears the text from the text box.
        /// </summary>
        public virtual void ClearText()
        {
            this.Click();
            this.Element.Clear();
        }
    }
}