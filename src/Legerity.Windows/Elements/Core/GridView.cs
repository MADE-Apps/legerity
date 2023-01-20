namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
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
        private readonly By gridViewItemLocator = By.ClassName("GridViewItem");

        /// <summary>
        /// Initializes a new instance of the <see cref="GridView"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public GridView(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the collection of items associated with the grid view.
        /// </summary>
        public virtual ReadOnlyCollection<AppiumWebElement> Items =>
            this.Element.FindElements(this.gridViewItemLocator);

        /// <summary>
        /// Gets the element associated with the currently selected item.
        /// </summary>
        public virtual AppiumWebElement SelectedItem => this.Items.FirstOrDefault(i => i.IsSelected());

        /// <summary>
        /// Gets the currently selected item index.
        /// </summary>
        public virtual int SelectedIndex => this.Items.IndexOf(this.SelectedItem);

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
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="GridView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="GridView"/>.
        /// </returns>
        public static implicit operator GridView(AppiumWebElement element)
        {
            return new GridView(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="GridView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="GridView"/>.
        /// </returns>
        public static implicit operator GridView(RemoteWebElement element)
        {
            return new GridView(element as WindowsElement);
        }

        /// <summary>
        /// Clicks on an item in the list view with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        public virtual void ClickItem(string name)
        {
            this.VerifyElementsShown(this.gridViewItemLocator, TimeSpan.FromSeconds(2));

            AppiumWebElement item = this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));

            item.Click();
        }

        /// <summary>
        /// Clicks on an item in the list view with the specified partial item name.
        /// </summary>
        /// <param name="partialName">
        /// The partial name of the item to click.
        /// </param>
        public virtual void ClickItemByPartialName(string partialName)
        {
            this.VerifyElementsShown(this.gridViewItemLocator, TimeSpan.FromSeconds(2));

            AppiumWebElement item =
                this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(partialName));

            item.Click();
        }

        /// <summary>
        /// Clicks on an item in the list view with the specified item index.
        /// </summary>
        /// <param name="index">
        /// The index of the item to click.
        /// </param>
        public virtual void ClickItemByIndex(int index)
        {
            this.VerifyElementsShown(this.gridViewItemLocator, TimeSpan.FromSeconds(2));

            AppiumWebElement item = this.Items[index];

            item.Click();
        }
    }
}