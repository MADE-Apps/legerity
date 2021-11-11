namespace Legerity.Web.Elements.Core
{
    using Legerity.Web.Elements;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="IWebElement"/> wrapper for the core web Image control.
    /// </summary>
    public class Image : WebElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public Image(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public Image(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the source URI of the image.
        /// </summary>
        public string Source => this.Element.GetAttribute("src");

        /// <summary>
        /// Gets the alt text of the image.
        /// </summary>
        public string AltText => this.Element.GetAttribute("alt");

        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        public double Width => double.Parse(this.Element.GetAttribute("width"));

        /// <summary>
        /// Gets the height of the image.
        /// </summary>
        public double Height => double.Parse(this.Element.GetAttribute("height"));

        /// <summary>
        /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="Image"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Image"/>.
        /// </returns>
        public static implicit operator Image(RemoteWebElement element)
        {
            return new Image(element);
        }
    }
}