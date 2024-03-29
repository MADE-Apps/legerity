namespace Legerity.Windows.Elements.Core;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Legerity.Exceptions;
using Legerity.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP ComboBox control.
/// </summary>
public class ComboBox : WindowsElementWrapper
{
    private readonly By comboBoxItemLocator = By.ClassName("ComboBoxItem");

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
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string SelectedItem => this.GetSelectedItem();

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
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ComboBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ComboBox"/>.
    /// </returns>
    public static implicit operator ComboBox(RemoteWebElement element)
    {
        return new ComboBox(element as WindowsElement);
    }

    /// <summary>
    /// Selects an item in the combo-box with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to select.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SelectItem(string name)
    {
        IEnumerable<AppiumWebElement> listElements = this.GetItemsToSelect();

        AppiumWebElement item = listElements.FirstOrDefault(
            element => element.GetName().Equals(name, StringComparison.CurrentCultureIgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find {name} in the combo box.");
        }

        item.Click();
    }

    /// <summary>
    /// Selects an item in the combo-box with the specified partial item name.
    /// </summary>
    /// <param name="name">
    /// The partial name of the item to select.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SelectItemByPartialName(string name)
    {
        IEnumerable<AppiumWebElement> listElements = this.GetItemsToSelect();

        AppiumWebElement item = listElements.FirstOrDefault(
            element => element.GetName().Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find {name} in the combo box.");
        }

        item.Click();
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string GetSelectedItem()
    {
        ReadOnlyCollection<AppiumWebElement> listElements = this.Element.FindElements(this.comboBoxItemLocator);
        return listElements.Count == 1 ? listElements.FirstOrDefault().GetName() : null;
    }

    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private IEnumerable<AppiumWebElement> GetItemsToSelect()
    {
        this.Click();
        this.VerifyElementsShown(this.comboBoxItemLocator, TimeSpan.FromSeconds(2));
        ReadOnlyCollection<AppiumWebElement> listElements = this.Element.FindElements(this.comboBoxItemLocator);
        return listElements;
    }
}