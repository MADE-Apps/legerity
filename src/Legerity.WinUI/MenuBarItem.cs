namespace Legerity.Windows.Elements.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Legerity.Extensions;
    using Legerity.Windows.Elements.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the WinUI MenuBarItem control.
    /// </summary>
    public class MenuBarItem : WindowsElementWrapper
    {
        private readonly WeakReference parentMenuBarReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuBarItem"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public MenuBarItem(WindowsElement element)
            : this(null, element)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuBarItem"/> class.
        /// </summary>
        /// <param name="parentMenuBar">
        /// The parent <see cref="MenuBar"/>.
        /// </param>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public MenuBarItem(
            MenuBar parentMenuBar,
            WindowsElement element)
            : base(element)
        {
            if (parentMenuBar != null)
            {
                this.parentMenuBarReference = new WeakReference(parentMenuBar);
            }
        }

        /// <summary>Gets the original parent <see cref="MenuBar"/> reference object.</summary>
        public MenuBar ParentMenuBar =>
            this.parentMenuBarReference != null && this.parentMenuBarReference.IsAlive
                ? this.parentMenuBarReference.Target as MenuBar
                : null;

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