namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP Button control.
    /// </summary>
    public class Button : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public Button(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="Button"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Button"/>.
        /// </returns>
        public static implicit operator Button(WindowsElement element)
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
            return new Button(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="Button"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Button"/>.
        /// </returns>
        public static implicit operator Button(RemoteWebElement element)
        {
            return new Button(element as WindowsElement);
        }
    }
}