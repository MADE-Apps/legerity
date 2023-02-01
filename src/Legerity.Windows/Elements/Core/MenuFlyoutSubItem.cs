namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Legerity.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the UWP MenuFlyoutSubItem control.
    /// </summary>
    public class MenuFlyoutSubItem : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuFlyoutSubItem"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public MenuFlyoutSubItem(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the UI components associated with the child menu items.
        /// </summary>
        public virtual IEnumerable<MenuFlyoutItem> ChildMenuItems => this.GetChildMenuItems();

        /// <summary>
        /// Gets the UI components associated with the child menu sub-items.
        /// </summary>
        public virtual IEnumerable<MenuFlyoutSubItem> ChildMenuSubItems => this.GetChildMenuSubItems();

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="MenuFlyoutSubItem"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="MenuFlyoutSubItem"/>.
        /// </returns>
        public static implicit operator MenuFlyoutSubItem(WindowsElement element)
        {
            return new MenuFlyoutSubItem(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="MenuFlyoutSubItem"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="MenuFlyoutSubItem"/>.
        /// </returns>
        public static implicit operator MenuFlyoutSubItem(AppiumWebElement element)
        {
            return new MenuFlyoutSubItem(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="MenuFlyoutSubItem"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="MenuFlyoutSubItem"/>.
        /// </returns>
        public static implicit operator MenuFlyoutSubItem(RemoteWebElement element)
        {
            return new MenuFlyoutSubItem(element as WindowsElement);
        }

        /// <summary>
        /// Clicks on a child menu option with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        /// <returns>
        /// The clicked <see cref="MenuFlyoutItem"/>.
        /// </returns>
        public virtual MenuFlyoutItem ClickChildOption(string name)
        {
            MenuFlyoutItem item = this.ChildMenuItems.FirstOrDefault(
                element => element.GetName()
                    .Equals(name, StringComparison.CurrentCultureIgnoreCase));

            item.Click();
            return item;
        }

        /// <summary>
        /// Clicks on a child menu option with the specified partial item name.
        /// </summary>
        /// <param name="name">
        /// The partial name of the item to click.
        /// </param>
        /// <returns>
        /// The clicked <see cref="MenuFlyoutItem"/>.
        /// </returns>
        public virtual MenuFlyoutItem ClickChildOptionByPartialName(string name)
        {
            MenuFlyoutItem item = this.ChildMenuItems.FirstOrDefault(
                element => element.GetName()
                    .Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));

            item.Click();
            return item;
        }

        /// <summary>
        /// Clicks on a child menu sub option with the specified item name.
        /// </summary>
        /// <param name="name">The name of the sub-item to click.</param>
        /// <returns>The clicked <see cref="MenuFlyoutSubItem"/>.</returns>
        public virtual MenuFlyoutSubItem ClickChildSubOption(string name)
        {
            MenuFlyoutSubItem item = this.ChildMenuSubItems.FirstOrDefault(
                element => element.GetName()
                    .Equals(name, StringComparison.CurrentCultureIgnoreCase));
            item.Click();
            return item;
        }

        /// <summary>
        /// Clicks on a child menu sub option with the specified partial item name.
        /// </summary>
        /// <param name="name">The name of the sub-item to click.</param>
        /// <returns>The clicked <see cref="MenuFlyoutSubItem"/>.</returns>
        public virtual MenuFlyoutSubItem ClickChildSubOptionByPartialName(string name)
        {
            MenuFlyoutSubItem item = this.ChildMenuSubItems.FirstOrDefault(
                element => element.GetName()
                    .Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));

            item.Click();
            return item;
        }

        private IEnumerable<MenuFlyoutItem> GetChildMenuItems()
        {
            return this.Driver.FindElement(By.ClassName("MenuFlyout"))
                .FindElements(By.ClassName(nameof(MenuFlyoutItem))).Select(
                    element => new MenuFlyoutItem(element as WindowsElement));
        }

        private IEnumerable<MenuFlyoutSubItem> GetChildMenuSubItems()
        {
            return this.Driver.FindElement(By.ClassName("MenuFlyout"))
                .FindElements(By.ClassName(nameof(MenuFlyoutSubItem))).Select(
                    element => new MenuFlyoutSubItem(element as WindowsElement));
        }
    }
}