namespace Legerity.IOS.Elements.Core
{
    using Legerity.IOS.Extensions;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.iOS;

    /// <summary>
    /// Defines a <see cref="IOSElement"/> wrapper for the core iOS Label control.
    /// </summary>
    public class Label : IOSElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IOSElement"/> reference.
        /// </param>
        public Label(IOSElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the text value of the label.
        /// </summary>
        public virtual string Text => this.Element.GetLabel();

        /// <summary>
        /// Allows conversion of a <see cref="IOSElement"/> to the <see cref="Label"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IOSElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Label"/>.
        /// </returns>
        public static implicit operator Label(IOSElement element)
        {
            return new Label(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Label"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Label"/>.
        /// </returns>
        public static implicit operator Label(AppiumWebElement element)
        {
            return new Label(element as IOSElement);
        }
    }
}