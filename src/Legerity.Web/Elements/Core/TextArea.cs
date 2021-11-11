namespace Legerity.Web.Elements.Core
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="IWebElement"/> wrapper for the core web TextArea control.
    /// </summary>
    public class TextArea : TextInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextArea"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public TextArea(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextArea"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public TextArea(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the number of visible text lines.
        /// </summary>
        public int Rows => int.Parse(this.Element.GetAttribute("rows"));

        /// <summary>
        /// Gets the visible width.
        /// </summary>
        public int Cols => int.Parse(this.Element.GetAttribute("cols"));

        /// <summary>
        /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="TextArea"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TextArea"/>.
        /// </returns>
        public static implicit operator TextArea(RemoteWebElement element)
        {
            return new TextArea(element);
        }
    }
}
