namespace Legerity.Windows.Elements.WCT;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Legerity.Exceptions;
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Windows Community Toolkit Carousel control.
/// </summary>
public class Carousel : WindowsElementWrapper
{
    private readonly By carouselItemLocator = By.ClassName("CarouselItem");

    /// <summary>
    /// Initializes a new instance of the <see cref="Carousel"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Carousel(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the carousel.
    /// </summary>
    public virtual ReadOnlyCollection<WebElement> Items =>
        Element.FindElements(carouselItemLocator).Cast<WebElement>().ToList().AsReadOnly();

    /// <summary>
    /// Gets the element associated with the currently selected item.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual WebElement SelectedItem => Items.FirstOrDefault(i => i.IsSelected());

    /// <summary>
    /// Gets the index of the element associated with the currently selected item.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual int SelectedIndex => Items.IndexOf(SelectedItem);

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="ListView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ListView"/>.
    /// </returns>
    public static implicit operator Carousel(WebElement element)
    {
        return new Carousel(element);
    }
    
    /// <summary>
    /// Clicks on an item in the carousel with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to click.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void SelectItem(string name)
    {
        VerifyElementsShown(carouselItemLocator, TimeSpan.FromSeconds(2));

        var index = Items.IndexOf(Items.FirstOrDefault(element =>
            element.VerifyNameOrAutomationIdEquals(name)));

        SelectItemAtIndex(index);
    }

    /// <summary>
    /// Clicks on an item in the carousel with the specified partial item name.
    /// </summary>
    /// <param name="partialName">
    /// The partial name of the item to click.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void SelectItemByPartialName(string partialName)
    {
        VerifyElementsShown(carouselItemLocator, TimeSpan.FromSeconds(2));

        var index = Items.IndexOf(Items.FirstOrDefault(element =>
            element.VerifyNameOrAutomationIdContains(partialName)));

        SelectItemAtIndex(index);
    }

    /// <summary>
    /// Clicks on an item in the carousel at the specified index.
    /// </summary>
    /// <param name="index">
    /// The index of the item to click.
    /// </param>
    /// <exception cref="IndexOutOfRangeException">Thrown when an element is selected that is outside the range of items available.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void SelectItem(int index)
    {
        VerifyElementsShown(carouselItemLocator, TimeSpan.FromSeconds(2));

        if (index > Items.Count - 1)
        {
            throw new IndexOutOfRangeException(
                "Cannot select an element that is outside the range of items available.");
        }

        SelectItemAtIndex(index);
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    private void SelectItemAtIndex(int index)
    {
        var selectedIndex = SelectedIndex;
        while (Math.Abs(index - selectedIndex) > double.Epsilon)
        {
            Element.SendKeys(selectedIndex < index ? Keys.ArrowRight : Keys.ArrowLeft);
            selectedIndex = SelectedIndex;
        }
    }
}
