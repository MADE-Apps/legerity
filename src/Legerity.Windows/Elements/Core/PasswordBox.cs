namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP PasswordBox control.
    /// </summary>
    public class PasswordBox : TextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public PasswordBox(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the reveal password button.
        /// </summary>
        public virtual ToggleButton RevealButton => this.Element.FindElement(WindowsByExtras.AutomationId("RevealButton"));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="PasswordBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="PasswordBox"/>.
        /// </returns>
        public static implicit operator PasswordBox(WindowsElement element)
        {
            return new PasswordBox(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="PasswordBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="PasswordBox"/>.
        /// </returns>
        public static implicit operator PasswordBox(AppiumWebElement element)
        {
            return new PasswordBox(element as WindowsElement);
        }
    }
}