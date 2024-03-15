namespace Legerity.Windows.Elements.MADE;

using Legerity.Exceptions;
using Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the MADE.NET UWP DropDownList control.
/// </summary>
public class DropDownList : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DropDownList"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public DropDownList(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the <see cref="ListView"/> element associated with the drop down content.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ListView DropDown => FindElement(WindowsByExtras.AutomationId("DropDownContent"));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="DropDownList"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DropDownList"/>.
    /// </returns>
    public static implicit operator DropDownList(WebElement element)
    {
        return new DropDownList(element);
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
        OpenDropDown();
        DropDown.ClickItem(name);
    }

    /// <summary>
    /// Selects an item in the combo-box with the specified partial item name.
    /// </summary>
    /// <param name="partialName">The partial name match for the item to select.</param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SelectItemByPartialName(string partialName)
    {
        OpenDropDown();
        DropDown.ClickItemByPartialName(partialName);
    }

    /// <summary>
    /// Opens the drop down if it is not already open.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void OpenDropDown()
    {
        if (!IsDropDownOpen())
        {
            Click();
        }
    }

    /// <summary>
    /// Determines whether the drop down is open.
    /// </summary>
    /// <returns>True if the drop down is open; otherwise, false.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsDropDownOpen()
    {
        bool isVisible;

        try
        {
            isVisible = DropDown.IsVisible;
        }
        catch (WebDriverException wde) when (wde.Message.Contains("element could not be located"))
        {
            isVisible = false;
        }
        catch (ElementNotShownException)
        {
            isVisible = false;
        }

        return isVisible;
    }
}
