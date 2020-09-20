namespace Legerity.Windows.Elements.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the WinUI NavigationViewItem control.
    /// </summary>
    public class NavigationViewItem : WindowsElementWrapper
    {
        private readonly By navigationViewItemQuery = By.ClassName("Microsoft.UI.Xaml.Controls.NavigationViewItem");

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
            this.parentNavigationViewReference != null && this.parentNavigationViewReference.IsAlive
                ? this.parentNavigationViewReference.Target as NavigationView
                : null;

        /// <summary>Gets the original parent <see cref="NavigationViewItem"/> reference object.</summary>
        public NavigationViewItem ParentItem =>
            this.parentItemReference != null && this.parentItemReference.IsAlive
                ? this.parentItemReference.Target as NavigationViewItem
                : null;

        /// <summary>
        /// Gets the UI components associated with the child menu items.
        /// </summary>
        public IEnumerable<NavigationViewItem> ChildMenuItems => this.GetChildMenuItems();

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
        /// The clicked <see cref="NavigationViewItem"/>.
        /// </returns>
        public NavigationViewItem ClickChildOption(string name)
        {
            NavigationViewItem item = this.ChildMenuItems.FirstOrDefault(
                element => element.Element.GetAttribute("Name")
                    .Equals(name, StringComparison.CurrentCultureIgnoreCase));
            item.Click();
            return item;
        }

        private IEnumerable<NavigationViewItem> GetChildMenuItems()
        {
            if (this.ParentNavigationView == null || this.ParentNavigationView.IsPaneOpen)
            {
                return this.Element.FindElements(this.navigationViewItemQuery).Select(
                    element => new NavigationViewItem(this.ParentNavigationView, this, element as WindowsElement));
            }
            else
            {
                return this.Driver.FindElement(ByExtensions.AutomationId("ChildrenFlyout"))
                    .FindElements(this.navigationViewItemQuery).Select(
                        element => new NavigationViewItem(this.ParentNavigationView, this, element as WindowsElement));
            }
        }
    }
}