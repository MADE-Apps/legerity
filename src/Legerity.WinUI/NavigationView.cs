namespace Legerity.Windows.Elements.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Legerity.Extensions;
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
        public AppiumWebElement MenuItemsView => this.Element.FindElement(ByExtensions.AutomationId("MenuItemsHost"));

        /// <summary>
        /// Gets the UI components associated with the menu items.
        /// </summary>
        public IEnumerable<NavigationViewItem> MenuItems =>
            this.MenuItemsView.FindElements(By.ClassName("Microsoft.UI.Xaml.Controls.NavigationViewItem"))
                .Select(element => new NavigationViewItem(this, element as WindowsElement));

        /// <summary>
        /// Gets the UI component associated with the settings menu item.
        /// </summary>
        public AppiumWebElement SettingsMenuItem => this.Element.FindElement(ByExtensions.AutomationId("SettingsItem"));

        /// <summary>
        /// Gets the UI component associated with the navigation pane toggle button.
        /// </summary>
        public Button ToggleNavigationPaneButton => this.Element.FindElement(ByExtensions.AutomationId("TogglePaneButton"));

        /// <summary>
        /// Gets the UI component associated with the navigation back button.
        /// </summary>
        public Button BackButton => this.Element.FindElement(ByExtensions.AutomationId("NavigationViewBackButton"));

        /// <summary>
        /// Gets a value indicating whether the pane is currently open.
        /// </summary>
        public bool IsPaneOpen => this.VerifyPaneOpen(this.ExpectedCompactPaneWidth);

        /// <summary>
        /// Gets or sets the expected compact pane width used to determine the pane open state.
        /// </summary>
        public int ExpectedCompactPaneWidth { get; set; } = 72;

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
        /// Opens the navigation pane.
        /// </summary>
        public void OpenNavigationPane()
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
        public void CloseNavigationPane()
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
        public void GoBack()
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
        public NavigationViewItem ClickMenuOption(string name)
        {
            NavigationViewItem item = this.MenuItems.FirstOrDefault(
                element => element.GetName().Equals(name, StringComparison.CurrentCultureIgnoreCase));
            item.Click();
            return item;
        }

        /// <summary>
        /// Opens the settings option.
        /// </summary>
        public void OpenSettings()
        {
            this.SettingsMenuItem.Click();
        }

        /// <summary>
        /// Determines whether the navigation pane is open based on the specified compact pane width.
        /// </summary>
        /// <param name="expectedCompactPaneWidth">The expected compact pane width when closed.</param>
        /// <returns>True if the pane is open; otherwise, false.</returns>
        public bool VerifyPaneOpen(int expectedCompactPaneWidth)
        {
            AppiumWebElement pane = this.Element.FindElement(ByExtensions.AutomationId("PaneRoot"));
            int paneWidth = pane.Rect.Width;
            return paneWidth > expectedCompactPaneWidth;
        }
    }
}