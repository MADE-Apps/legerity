namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP ProgressRing control.
    /// </summary>
    public class ProgressRing : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressRing"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public ProgressRing(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="ProgressRing"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ProgressRing"/>.
        /// </returns>
        public static implicit operator ProgressRing(WindowsElement element)
        {
            return new ProgressRing(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ProgressRing"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ProgressRing"/>.
        /// </returns>
        public static implicit operator ProgressRing(AppiumWebElement element)
        {
            return new ProgressRing(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ProgressRing"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ProgressRing"/>.
        /// </returns>
        public static implicit operator ProgressRing(RemoteWebElement element)
        {
            return new ProgressRing(element as WindowsElement);
        }
    }
}