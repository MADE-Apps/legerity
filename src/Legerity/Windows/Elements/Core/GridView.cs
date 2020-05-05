namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;

    using Legerity.Extensions;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP GridView control.
    /// </summary>
    public class GridView : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridView"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference..
        /// </param>
        public GridView(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="GridView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="GridView"/>.
        /// </returns>
        public static implicit operator GridView(WindowsElement element)
        {
            return new GridView(element);
        }

        /// <summary>
        /// Clicks on an item in the list view with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        public void ClickItem(string name)
        {
            ReadOnlyCollection<AppiumWebElement> listElements = this.Element.FindElements(By.ClassName("GridViewItem"));

            AppiumWebElement item = listElements.FirstOrDefault(
                element => element.GetAttribute("Name").Equals(name, StringComparison.CurrentCultureIgnoreCase));

            item.Click();
        }
    }
}