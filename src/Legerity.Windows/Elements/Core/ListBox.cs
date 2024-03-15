namespace Legerity.Windows.Elements.Core;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Legerity.Exceptions;
using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP ListBox control.
/// </summary>
public class ListBox : WindowsElementWrapper
{
    private readonly By _listBoxItemLocator = By.ClassName("ListBoxItem");

    /// <summary>
    /// Initializes a new instance of the <see cref="ListBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public ListBox(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the list box.
    /// </summary>
    public virtual ReadOnlyCollection<WebElement> Items => Element.FindElements(_listBoxItemLocator).Cast<WebElement>().ToList().AsReadOnly();

    /// <summary>
    /// Gets the element associated with the currently selected item.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual WebElement SelectedItem => Items.FirstOrDefault(i => i.IsSelected());

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="ListBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ListBox"/>.
    /// </returns>
    public static implicit operator ListBox(WebElement element)
    {
        return new ListBox(element);
    }
    
    /// <summary>
    /// Clicks on an item in the list box with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to click.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClickItem(string name)
    {
        VerifyElementsShown(_listBoxItemLocator, TimeSpan.FromSeconds(2));
        var item = Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find element using {name}");
        }

        item.Click();
    }

    /// <summary>
    /// Clicks on an item in the list box with the specified partial item name.
    /// </summary>
    /// <param name="partialName">The partial name match for the item to click.</param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void ClickItemByPartialName(string partialName)
    {
        VerifyElementsShown(_listBoxItemLocator, TimeSpan.FromSeconds(2));
        var item =
            Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(partialName));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find element using {partialName}");
        }

        item.Click();
    }
}
