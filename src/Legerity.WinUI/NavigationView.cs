namespace Legerity.Windows.Elements.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the WinUI NavigationView control.
    /// </summary>
    public class NavigationView : WindowsElementWrapper
    {
        private readonly By menuItemsHostQuery = ByExtensions.AutomationId("MenuItemsHost");

        private readonly By navigationViewItemQuery = By.ClassName("Microsoft.UI.Xaml.Controls.NavigationViewItem");

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationView"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public NavigationView(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the UI component associated with displaying the menu items.
        /// </summary>
        public AppiumWebElement MenuItemsView => this.Element.FindElement(this.menuItemsHostQuery);

        /// <summary>
        /// Gets the UI components associated with the menu items.
        /// </summary>
        public IEnumerable<AppiumWebElement> MenuItems => this.MenuItemsView.FindElements(this.navigationViewItemQuery);

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="NavigationView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="NavigationView"/>.
        /// </returns>
        public static implicit operator NavigationView(WindowsElement element)
        {
            return new NavigationView(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="NavigationView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="NavigationView"/>.
        /// </returns>
        public static implicit operator NavigationView(AppiumWebElement element)
        {
            return new NavigationView(element as WindowsElement);
        }

        /// <summary>
        /// Clicks on a menu option in the navigation view with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        public void ClickMenuOption(string name)
        {
            AppiumWebElement item = this.MenuItems.FirstOrDefault(
                element => element.GetAttribute("Name").Equals(name, StringComparison.CurrentCultureIgnoreCase));

            item.Click();
        }
    }
}