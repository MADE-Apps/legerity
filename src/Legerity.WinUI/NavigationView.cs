namespace Legerity.Windows.Elements.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Extensions;
    using Legerity.Extensions;
    using Legerity.Windows.Elements.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the WinUI NavigationView control.
    /// </summary>
    public class NavigationView : WindowsElementWrapper
    {
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
        public virtual AppiumWebElement MenuItemsView =>
            this.Element.FindElement(WindowsByExtras.AutomationId("MenuItemsHost"));

        /// <summary>
        /// Gets the UI components associated with the menu items.
        /// </summary>
        public virtual IEnumerable<NavigationViewItem> MenuItems =>
            this.MenuItemsView.FindElements(By.ClassName("Microsoft.UI.Xaml.Controls.NavigationViewItem"))
                .Select(element => new NavigationViewItem(this, element as WindowsElement));

        /// <summary>
        /// Gets the currently selected menu item.
        /// </summary>
        public virtual NavigationViewItem SelectedMenuItem =>
            this.MenuItems.FirstOrDefault(item => item.IsSelected());

        /// <summary>
        /// Gets the UI component associated with the settings menu item.
        /// </summary>
        public virtual AppiumWebElement SettingsMenuItem =>
            this.Element.FindElement(WindowsByExtras.AutomationId("SettingsItem"));

        /// <summary>
        /// Gets the UI component associated with the navigation pane toggle button.
        /// </summary>
        public virtual Button ToggleNavigationPaneButton =>
            this.Element.FindElement(WindowsByExtras.AutomationId("TogglePaneButton"));

        /// <summary>
        /// Gets the UI component associated with the navigation back button.
        /// </summary>
        public virtual Button BackButton =>
            this.Element.FindElement(WindowsByExtras.AutomationId("NavigationViewBackButton"));

        /// <summary>
        /// Gets a value indicating whether the pane is currently open.
        /// </summary>
        public virtual bool IsPaneOpen => this.VerifyPaneOpen(this.ExpectedCompactPaneWidth);

        /// <summary>
        /// Gets or sets the expected compact pane width used to determine the pane open state.
        /// </summary>
        public virtual int ExpectedCompactPaneWidth { get; set; } = 72;

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
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="NavigationView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="NavigationView"/>.
        /// </returns>
        public static implicit operator NavigationView(RemoteWebElement element)
        {
            return new NavigationView(element as WindowsElement);
        }

        /// <summary>
        /// Opens the navigation pane.
        /// </summary>
        public virtual void OpenNavigationPane()
        {
            if (this.IsPaneOpen)
            {
                return;
            }

            this.ToggleNavigationPaneButton.Click();
        }

        /// <summary>
        /// Collapses the navigation pane.
        /// </summary>
        public virtual void CloseNavigationPane()
        {
            if (!this.IsPaneOpen)
            {
                return;
            }

            this.ToggleNavigationPaneButton.Click();
        }

        /// <summary>
        /// Navigates the view back.
        /// </summary>
        public virtual void GoBack()
        {
            if (this.BackButton.IsEnabled)
            {
                this.BackButton.Click();
            }
        }

        /// <summary>
        /// Clicks on a menu option in the navigation view with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        /// <returns>
        /// The clicked <see cref="NavigationViewItem"/>.
        /// </returns>
        public virtual NavigationViewItem ClickMenuOption(string name)
        {
            NavigationViewItem item = this.MenuItems.FirstOrDefault(
                element => element.GetName().Equals(name, StringComparison.CurrentCultureIgnoreCase));
            item.Click();
            return item;
        }

        /// <summary>
        /// Clicks on a menu option in the navigation view with the specified partial item name.
        /// </summary>
        /// <param name="name">
        /// The partial name of the item to click.
        /// </param>
        /// <returns>
        /// The clicked <see cref="NavigationViewItem"/>.
        /// </returns>
        public virtual NavigationViewItem ClickMenuOptionByPartialName(string name)
        {
            NavigationViewItem item = this.MenuItems.FirstOrDefault(
                element => element.GetName().Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));
            item.Click();
            return item;
        }

        /// <summary>
        /// Opens the settings option.
        /// </summary>
        public virtual void OpenSettings()
        {
            this.SettingsMenuItem.Click();
        }

        /// <summary>
        /// Determines whether the navigation pane is open based on the specified compact pane width.
        /// </summary>
        /// <param name="expectedCompactPaneWidth">The expected compact pane width when closed.</param>
        /// <returns>True if the pane is open; otherwise, false.</returns>
        public virtual bool VerifyPaneOpen(int expectedCompactPaneWidth)
        {
            AppiumWebElement pane = this.Element.FindElement(WindowsByExtras.AutomationId("PaneRoot"));
            int paneWidth = pane.Rect.Width;
            return paneWidth > expectedCompactPaneWidth;
        }
    }
}