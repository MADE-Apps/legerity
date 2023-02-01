namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the UWP MenuFlyoutItem control.
    /// </summary>
    public class MenuFlyoutItem : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuFlyoutItem"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public MenuFlyoutItem(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="MenuFlyoutItem"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="MenuFlyoutItem"/>.
        /// </returns>
        public static implicit operator MenuFlyoutItem(WindowsElement element)
        {
            return new MenuFlyoutItem(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="MenuFlyoutItem"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="MenuFlyoutItem"/>.
        /// </returns>
        public static implicit operator MenuFlyoutItem(AppiumWebElement element)
        {
            return new MenuFlyoutItem(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="MenuFlyoutItem"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="MenuFlyoutItem"/>.
        /// </returns>
        public static implicit operator MenuFlyoutItem(RemoteWebElement element)
        {
            return new MenuFlyoutItem(element as WindowsElement);
        }
    }
}