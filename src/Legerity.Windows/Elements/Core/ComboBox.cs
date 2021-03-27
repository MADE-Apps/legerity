namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP ComboBox control.
    /// </summary>
    public class ComboBox : WindowsElementWrapper
    {
        private readonly By comboBoxItemQuery = By.ClassName("ComboBoxItem");

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public ComboBox(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the currently selected item.
        /// </summary>
        public string SelectedItem => this.GetSelectedItem();

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="ComboBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ComboBox"/>.
        /// </returns>
        public static implicit operator ComboBox(WindowsElement element)
        {
            return new ComboBox(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ComboBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ComboBox"/>.
        /// </returns>
        public static implicit operator ComboBox(AppiumWebElement element)
        {
            return new ComboBox(element as WindowsElement);
        }

        /// <summary>
        /// Selects an item in the combo-box with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to select.
        /// </param>
        public void SelectItem(string name)
        {
            this.Element.Click();

            this.VerifyElementsShown(this.comboBoxItemQuery, TimeSpan.FromSeconds(2));

            ReadOnlyCollection<AppiumWebElement> listElements = this.Element.FindElements(this.comboBoxItemQuery);

            AppiumWebElement item = listElements.FirstOrDefault(
                element => element.GetAttribute("Name").Equals(name, StringComparison.CurrentCultureIgnoreCase));

            item.Click();
        }

        private string GetSelectedItem()
        {
            ReadOnlyCollection<AppiumWebElement> listElements = this.Element.FindElements(this.comboBoxItemQuery);
            return listElements.Count == 1 ? listElements.FirstOrDefault().GetAttribute("Name") : null;
        }
    }
}