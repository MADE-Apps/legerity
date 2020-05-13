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
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP HyperlinkButton control.
    /// </summary>
    public class HyperlinkButton : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public HyperlinkButton(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="HyperlinkButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="HyperlinkButton"/>.
        /// </returns>
        public static implicit operator HyperlinkButton(WindowsElement element)
        {
            return new HyperlinkButton(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="HyperlinkButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="HyperlinkButton"/>.
        /// </returns>
        public static implicit operator HyperlinkButton(AppiumWebElement element)
        {
            return new HyperlinkButton(element as WindowsElement);
        }

        /// <summary>
        /// Clicks the hyperlink button.
        /// </summary>
        public void Click()
        {
            this.Element.Click();
        }
    }
}