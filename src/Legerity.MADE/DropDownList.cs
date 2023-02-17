namespace Legerity.Windows.Elements.MADE;

using Legerity.Exceptions;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the MADE.NET UWP DropDownList control.
/// </summary>
public class DropDownList : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DropDownList"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public DropDownList(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the <see cref="ListView"/> element associated with the drop down content.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ListView DropDown => this.FindElement(WindowsByExtras.AutomationId("DropDownContent"));

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="DropDownList"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DropDownList"/>.
    /// </returns>
    public static implicit operator DropDownList(WindowsElement element)
    {
        return new DropDownList(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="DropDownList"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DropDownList"/>.
    /// </returns>
    public static implicit operator DropDownList(AppiumWebElement element)
    {
        return new DropDownList(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="DropDownList"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DropDownList"/>.
    /// </returns>
    public static implicit operator DropDownList(RemoteWebElement element)
    {
        return new DropDownList(element as WindowsElement);
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
        this.OpenDropDown();
        this.DropDown.ClickItem(name);
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
        this.OpenDropDown();
        this.DropDown.ClickItemByPartialName(partialName);
    }

    /// <summary>
    /// Opens the drop down if it is not already open.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void OpenDropDown()
    {
        if (!this.IsDropDownOpen())
        {
            this.Click();
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
            isVisible = this.DropDown.IsVisible;
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