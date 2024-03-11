namespace Legerity.Windows.Elements.Core;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Legerity.Exceptions;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP Pivot control.
/// </summary>
public class Pivot : WindowsElementWrapper
{
    private readonly By pivotItemLocator = By.ClassName("PivotItem");

    /// <summary>
    /// Initializes a new instance of the <see cref="Pivot"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Pivot(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the pivot.
    /// </summary>
    public virtual ReadOnlyCollection<WebElement> Items => this.Element.FindElements(this.pivotItemLocator).Cast<WebElement>().ToList().AsReadOnly();

    /// <summary>
    /// Gets the currently selected item.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual WebElement SelectedItem => this.Items.FirstOrDefault(i => i.IsSelected());

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Pivot"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Pivot"/>.
    /// </returns>
    public static implicit operator Pivot(WebElement element)
    {
        return new Pivot(element);
    }
    
    /// <summary>
    /// Clicks on an item in the pivot with the specified item name.
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
        this.VerifyElementsShown(this.pivotItemLocator, TimeSpan.FromSeconds(2));

        WebElement item = this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find element using {name}");
        }

        item.Click();
    }

    /// <summary>
    /// Clicks on an item in the pivot with the specified partial item name.
    /// </summary>
    /// <param name="name">
    /// The partial name of the item to click.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void ClickItemByPartialName(string name)
    {
        this.VerifyElementsShown(this.pivotItemLocator, TimeSpan.FromSeconds(2));

        WebElement item = this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find element using {name}");
        }

        item.Click();
    }
}