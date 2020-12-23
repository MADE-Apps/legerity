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
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP Pivot control.
    /// </summary>
    public class Pivot : WindowsElementWrapper
    {
        private readonly By pivotItemQuery = By.ClassName("PivotItem");

        /// <summary>
        /// Initializes a new instance of the <see cref="Pivot"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public Pivot(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the collection of items associated with the pivot.
        /// </summary>
        public ReadOnlyCollection<AppiumWebElement> Items => this.Element.FindElements(this.pivotItemQuery);

        /// <summary>
        /// Gets the currently selected item.
        /// </summary>
        public AppiumWebElement SelectedItem =>
            this.Items.FirstOrDefault(
                i => i.GetAttribute("SelectionItem.IsSelected").Equals(
                    "True",
                    StringComparison.CurrentCultureIgnoreCase));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="Pivot"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Pivot"/>.
        /// </returns>
        public static implicit operator Pivot(WindowsElement element)
        {
            return new Pivot(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Pivot"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Pivot"/>.
        /// </returns>
        public static implicit operator Pivot(AppiumWebElement element)
        {
            return new Pivot(element as WindowsElement);
        }

        /// <summary>
        /// Clicks on an item in the pivot with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        public void ClickItem(string name)
        {
            this.VerifyElementsShown(this.pivotItemQuery, TimeSpan.FromSeconds(2));

            AppiumWebElement item = this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));
            
            item.Click();
        }
    }
}