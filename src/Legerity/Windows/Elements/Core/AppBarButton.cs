namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP AppBarButton control.
    /// </summary>
    public class AppBarButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppBarButton"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public AppBarButton(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="AppBarButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AppBarButton"/>.
        /// </returns>
        public static implicit operator AppBarButton(WindowsElement element)
        {
            return new AppBarButton(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="AppBarButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AppBarButton"/>.
        /// </returns>
        public static implicit operator AppBarButton(AppiumWebElement element)
        {
            return new AppBarButton(element as WindowsElement);
        }
    }
}