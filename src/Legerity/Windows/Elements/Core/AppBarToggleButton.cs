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
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP AppBarToggleButton control.
    /// </summary>
    public class AppBarToggleButton : AppBarButton
    {
        private const string ToggleOnValue = "1";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppBarToggleButton"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public AppBarToggleButton(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the toggle button is in the on position.
        /// </summary>
        public bool IsOn => this.Element.GetAttribute("Toggle.ToggleState") == ToggleOnValue;

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="AppBarToggleButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AppBarToggleButton"/>.
        /// </returns>
        public static implicit operator AppBarToggleButton(WindowsElement element)
        {
            return new AppBarToggleButton(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="AppBarToggleButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AppBarToggleButton"/>.
        /// </returns>
        public static implicit operator AppBarToggleButton(AppiumWebElement element)
        {
            return new AppBarToggleButton(element as WindowsElement);
        }

        /// <summary>
        /// Toggles the button on.
        /// </summary>
        public void ToggleOn()
        {
            if (this.IsOn)
            {
                return;
            }

            this.Click();
        }

        /// <summary>
        /// Toggles the button off.
        /// </summary>
        public void ToggleOff()
        {
            if (!this.IsOn)
            {
                return;
            }

            this.Click();
        }
    }
}