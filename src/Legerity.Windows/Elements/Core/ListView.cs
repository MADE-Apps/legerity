namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP ListView control.
    /// </summary>
    public class ListView : WindowsElementWrapper
    {
        private readonly By listViewItemLocator = By.ClassName("ListViewItem");

        /// <summary>
        /// Initializes a new instance of the <see cref="ListView"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public ListView(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the collection of items associated with the list view.
        /// </summary>
        public virtual ReadOnlyCollection<AppiumWebElement> Items => this.Element.FindElements(this.listViewItemLocator);

        /// <summary>
        /// Gets the element associated with the currently selected item.
        /// </summary>
        public virtual AppiumWebElement SelectedItem => this.Items.FirstOrDefault(i => i.IsSelected());

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="ListView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ListView"/>.
        /// </returns>
        public static implicit operator ListView(WindowsElement element)
        {
            return new ListView(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ListView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ListView"/>.
        /// </returns>
        public static implicit operator ListView(AppiumWebElement element)
        {
            return new ListView(element as WindowsElement);
        }

        /// <summary>
        /// Clicks on an item in the list view with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        public virtual void ClickItem(string name)
        {
            this.VerifyElementsShown(this.listViewItemLocator, TimeSpan.FromSeconds(2));
            AppiumWebElement item = this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));
            item.Click();
        }

        /// <summary>
        /// Clicks on an item in the list view with the specified partial item name.
        /// </summary>
        /// <param name="partialName">The partial name match for the item to click.</param>
        public virtual void ClickItemByPartialName(string partialName)
        {
            this.VerifyElementsShown(this.listViewItemLocator, TimeSpan.FromSeconds(2));
            AppiumWebElement item =
                this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(partialName));
            item.Click();
        }
    }
}