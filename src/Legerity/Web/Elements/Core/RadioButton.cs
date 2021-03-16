namespace Legerity.Web.Elements.Core
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="IWebElement"/> wrapper for the core web Input radio control.
    /// </summary>
    public class RadioButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadioButton"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public RadioButton(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the radio button is selected.
        /// </summary>
        public bool IsSelected => this.Element.Selected;

        /// <summary>
        /// Gets the name of the group for the radio button.
        /// </summary>
        public string Group => this.Element.GetAttribute("name");

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="RadioButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadioButton"/>.
        /// </returns>
        public static implicit operator RadioButton(RemoteWebElement element)
        {
            return new RadioButton(element);
        }
    }
}