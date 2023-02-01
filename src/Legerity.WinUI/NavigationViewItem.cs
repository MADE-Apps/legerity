namespace Legerity.Windows.Elements.WinUI
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
    /// Defines a <see cref="WindowsElement"/> wrapper for the WinUI NavigationViewItem control.
    /// </summary>
    public class NavigationViewItem : WindowsElementWrapper
    {
        private readonly By navigationViewItemLocator = By.ClassName("Microsoft.UI.Xaml.Controls.NavigationViewItem");

        private readonly WeakReference parentNavigationViewReference;

        private readonly WeakReference parentItemReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationViewItem"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public NavigationViewItem(WindowsElement element)
            : this(null, null, element)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationViewItem"/> class.
        /// </summary>
        /// <param name="parentNavigationView">
        /// The parent <see cref="NavigationView"/>.
        /// </param>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public NavigationViewItem(NavigationView parentNavigationView, WindowsElement element)
            : this(parentNavigationView, null, element)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationViewItem"/> class.
        /// </summary>
        /// <param name="parentItem">
        /// The parent <see cref="NavigationViewItem"/>.
        /// </param>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public NavigationViewItem(NavigationViewItem parentItem, WindowsElement element)
            : this(null, parentItem, element)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationViewItem"/> class.
        /// </summary>
        /// <param name="parentNavigationView">
        /// The parent <see cref="NavigationView"/>.
        /// </param>
        /// <param name="parentItem">
        /// The parent <see cref="NavigationViewItem"/>.
        /// </param>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public NavigationViewItem(
            NavigationView parentNavigationView,
            NavigationViewItem parentItem,
            WindowsElement element)
            : base(element)
        {
            if (parentNavigationView != null)
            {
                this.parentNavigationViewReference = new WeakReference(parentNavigationView);
            }

            if (parentItem != null)
            {
                this.parentItemReference = new WeakReference(parentItem);
            }
        }

        /// <summary>Gets the original parent <see cref="NavigationView"/> reference object.</summary>
        public NavigationView ParentNavigationView =>
            this.parentNavigationViewReference is { IsAlive: true }
                ? this.parentNavigationViewReference.Target as NavigationView
                : null;

        /// <summary>Gets the original parent <see cref="NavigationViewItem"/> reference object.</summary>
        public NavigationViewItem ParentItem =>
            this.parentItemReference is { IsAlive: true }
                ? this.parentItemReference.Target as NavigationViewItem
                : null;

        /// <summary>
        /// Gets the UI components associated with the child menu items.
        /// </summary>
        public virtual IEnumerable<NavigationViewItem> ChildMenuItems => this.GetChildMenuItems();

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="NavigationViewItem"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="NavigationViewItem"/>.
        /// </returns>
        public static implicit operator NavigationViewItem(WindowsElement element)
        {
            return new NavigationViewItem(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="NavigationViewItem"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="NavigationViewItem"/>.
        /// </returns>
        public static implicit operator NavigationViewItem(AppiumWebElement element)
        {
            return new NavigationViewItem(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="NavigationViewItem"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="NavigationViewItem"/>.
        /// </returns>
        public static implicit operator NavigationViewItem(RemoteWebElement element)
        {
            return new NavigationViewItem(element as WindowsElement);
        }

        /// <summary>
        /// Clicks on a child menu option with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        /// <returns>
        /// The clicked <see cref="NavigationViewItem"/>.
        /// </returns>
        public virtual NavigationViewItem ClickChildOption(string name)
        {
            NavigationViewItem item = this.ChildMenuItems.FirstOrDefault(
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
        /// The clicked <see cref="NavigationViewItem"/>.
        /// </returns>
        public virtual NavigationViewItem ClickChildOptionByPartialName(string name)
        {
            NavigationViewItem item = this.ChildMenuItems.FirstOrDefault(
                element => element.GetName()
                    .Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));
            item.Click();
            return item;
        }

        private IEnumerable<NavigationViewItem> GetChildMenuItems()
        {
            if (this.ParentNavigationView == null || this.ParentNavigationView.IsPaneOpen)
            {
                return this.Element.FindElements(this.navigationViewItemLocator).Select(
                    element => new NavigationViewItem(this.ParentNavigationView, this, element as WindowsElement));
            }

            return this.Driver.FindElement(WindowsByExtras.AutomationId("ChildrenFlyout"))
                .FindElements(this.navigationViewItemLocator).Select(
                    element => new NavigationViewItem(this.ParentNavigationView, this, element as WindowsElement));
        }
    }
}