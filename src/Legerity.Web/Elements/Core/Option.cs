namespace Legerity.Web.Elements.Core
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using Web.Elements;

    /// <summary>
    /// Defines a <see cref="IWebElement"/> wrapper for the core web Option control.
    /// </summary>
    public class Option : WebElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Option"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public Option(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Option"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public Option(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the value of the option.
        /// </summary>
        public string Value => this.Element.GetAttribute("value");

        /// <summary>
        /// Gets the display value of the option.
        /// </summary>
        public string DisplayValue => this.Element.Text;

        /// <summary>
        /// Gets a value indicating whether the option is selected.
        /// </summary>
        public bool IsSelected => this.Element.Selected;

        /// <summary>
        /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="Option"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Option"/>.
        /// </returns>
        public static implicit operator Option(RemoteWebElement element)
        {
            return new Option(element);
        }

        /// <summary>
        /// Selects the option.
        /// </summary>
        public void Select()
        {
            this.Element.Click();
        }
    }
}