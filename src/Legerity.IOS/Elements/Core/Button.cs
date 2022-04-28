namespace Legerity.IOS.Elements.Core
{
    using Legerity.IOS.Extensions;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.iOS;

    /// <summary>
    /// Defines a <see cref="IOSElement"/> wrapper for the core iOS Button control.
    /// </summary>
    public class Button : IOSElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IOSElement"/> reference.
        /// </param>
        public Button(IOSElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the button's label content.
        /// </summary>
        public virtual string Label => this.Element.GetLabel();

        /// <summary>
        /// Allows conversion of a <see cref="IOSElement"/> to the <see cref="Button"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IOSElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Button"/>.
        /// </returns>
        public static implicit operator Button(IOSElement element)
        {
            return new Button(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Button"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Button"/>.
        /// </returns>
        public static implicit operator Button(AppiumWebElement element)
        {
            return new Button(element as IOSElement);
        }
    }
}