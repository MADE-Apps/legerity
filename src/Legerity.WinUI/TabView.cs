namespace Legerity.Windows.Elements.WinUI
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the WinUI TabView control.
    /// </summary>
    public class TabView : WindowsElementWrapper
    {
        private readonly By tabListViewLocator = WindowsByExtras.AutomationId("TabListView");

        /// <summary>
        /// Initializes a new instance of the <see cref="TabView"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public TabView(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the add tab button.
        /// </summary>
        public Button AddTabButton => this.Element.FindElement(WindowsByExtras.AutomationId("AddButton"));

        /// <summary>
        /// Gets the collection of items associated with the pivot.
        /// </summary>
        public ReadOnlyCollection<AppiumWebElement> Tabs => this.TabsListView.Items;

        /// <summary>
        /// Gets the element associated with the currently selected item.
        /// </summary>
        public AppiumWebElement SelectedItem => this.TabsListView.SelectedItem;

        private ListView TabsListView => this.Element.FindElement(this.tabListViewLocator);

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="TabView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TabView"/>.
        /// </returns>
        public static implicit operator TabView(WindowsElement element)
        {
            return new TabView(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TabView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TabView"/>.
        /// </returns>
        public static implicit operator TabView(AppiumWebElement element)
        {
            return new TabView(element as WindowsElement);
        }

        /// <summary>
        /// Adds a new tab to the tab view.
        /// </summary>
        public void CreateTab()
        {
            this.VerifyElementShown(this.tabListViewLocator, TimeSpan.FromSeconds(2));
            this.AddTabButton.Click();
        }

        /// <summary>
        /// Clicks on a tab in the view with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        public void SelectTab(string name)
        {
            this.VerifyElementShown(this.tabListViewLocator, TimeSpan.FromSeconds(2));
            AppiumWebElement item = this.Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));
            item.Click();
        }

        /// <summary>
        /// Closes a tab in the view with the specified item name.
        /// </summary>
        /// <param name="name">The name of the item to close.</param>
        public void CloseTab(string name)
        {
            this.VerifyElementShown(this.tabListViewLocator, TimeSpan.FromSeconds(2));
            AppiumWebElement item = this.Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));
            Button closeButton = item.FindElement(WindowsByExtras.AutomationId("CloseButton"));
            closeButton.Click();
        }
    }
}