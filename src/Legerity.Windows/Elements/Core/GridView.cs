namespace Legerity.Windows.Elements.Core;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Legerity.Exceptions;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP GridView control.
/// </summary>
public class GridView : WindowsElementWrapper
{
    private readonly By gridViewItemLocator = By.ClassName("GridViewItem");

    /// <summary>
    /// Initializes a new instance of the <see cref="GridView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public GridView(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the grid view.
    /// </summary>
    public virtual ReadOnlyCollection<WebElement> Items =>
        Element.FindElements(gridViewItemLocator).Cast<WebElement>().ToList().AsReadOnly();

    /// <summary>
    /// Gets the element associated with the currently selected item.
    /// </summary>
    public virtual WebElement SelectedItem => Items.FirstOrDefault(i => i.IsSelected());

    /// <summary>
    /// Gets the currently selected item index.
    /// </summary>
    public virtual int SelectedIndex => Items.IndexOf(SelectedItem);

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="GridView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="GridView"/>.
    /// </returns>
    public static implicit operator GridView(WebElement element)
    {
        return new GridView(element);
    }
    
    /// <summary>
    /// Clicks on an item in the list view with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to click.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void ClickItem(string name)
    {
        VerifyElementsShown(gridViewItemLocator, TimeSpan.FromSeconds(2));

        WebElement item = Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find item {name}.");
        }

        item.Click();
    }

    /// <summary>
    /// Clicks on an item in the list view with the specified partial item name.
    /// </summary>
    /// <param name="partialName">
    /// The partial name of the item to click.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClickItemByPartialName(string partialName)
    {
        VerifyElementsShown(gridViewItemLocator, TimeSpan.FromSeconds(2));

        WebElement item =
            Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(partialName));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find item {partialName}.");
        }

        item.Click();
    }

    /// <summary>
    /// Clicks on an item in the list view with the specified item index.
    /// </summary>
    /// <param name="index">
    /// The index of the item to click.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClickItemByIndex(int index)
    {
        VerifyElementsShown(gridViewItemLocator, TimeSpan.FromSeconds(2));

        WebElement item = Items[index];

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find item at index {index}.");
        }

        item.Click();
    }
}