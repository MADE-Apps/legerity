namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Legerity.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

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
        public IEnumerable<MenuFlyoutItem> ChildMenuItems => this.GetChildMenuItems();

        /// <summary>
        /// Gets the UI components associated with the child menu sub-items.
        /// </summary>
        public IEnumerable<MenuFlyoutSubItem> ChildMenuSubItems => this.GetChildMenuSubItems();

        /// <summary>
        /// Clicks the item.
        /// </summary>
        public void Click()
        {
            this.Element.Click();
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
        public MenuFlyoutItem ClickChildOption(string name)
        {
            MenuFlyoutItem item = this.ChildMenuItems.FirstOrDefault(
                element => element.GetName()
                    .Equals(name, StringComparison.CurrentCultureIgnoreCase));

            item.Click();
            return item;
        }

        /// <summary>
        /// Clicks on a child menu sub option with the specified item name.
        /// </summary>
        /// <param name="name">The name of the sub-item to click.</param>
        /// <returns>The clicked <see cref="MenuFlyoutSubItem"/>.</returns>
        public MenuFlyoutSubItem ClickChildSubOption(string name)
        {
            MenuFlyoutSubItem item = this.ChildMenuSubItems.FirstOrDefault(
                element => element.GetName()
                    .Equals(name, StringComparison.CurrentCultureIgnoreCase));
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