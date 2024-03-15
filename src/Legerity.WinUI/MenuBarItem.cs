namespace Legerity.Windows.Elements.WinUI;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Legerity.Extensions;
using Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the WinUI MenuBarItem control.
/// </summary>
public class MenuBarItem : WindowsElementWrapper
{
    private readonly WeakReference _parentMenuBarReference;

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuBarItem"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public MenuBarItem(WebElement element)
        : this(null, element)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuBarItem"/> class.
    /// </summary>
    /// <param name="parentMenuBar">
    /// The parent <see cref="MenuBar"/>.
    /// </param>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public MenuBarItem(
        MenuBar parentMenuBar,
        WebElement element)
        : base(element)
    {
        if (parentMenuBar != null)
        {
            _parentMenuBarReference = new WeakReference(parentMenuBar);
        }
    }

    /// <summary>Gets the original parent <see cref="MenuBar"/> reference object.</summary>
    public virtual MenuBar ParentMenuBar =>
        _parentMenuBarReference is { IsAlive: true }
            ? _parentMenuBarReference.Target as MenuBar
            : null;

    /// <summary>
    /// Gets the UI components associated with the child menu items.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual IEnumerable<MenuFlyoutItem> ChildMenuItems => GetChildMenuItems();

    /// <summary>
    /// Gets the UI components associated with the child menu sub-items.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual IEnumerable<MenuFlyoutSubItem> ChildMenuSubItems => GetChildMenuSubItems();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="MenuBarItem"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="MenuBarItem"/>.
    /// </returns>
    public static implicit operator MenuBarItem(WebElement element)
    {
        return new MenuBarItem(element);
    }
    
    /// <summary>
    /// Clicks on a child menu option with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to click.
    /// </param>
    /// <returns>
    /// The clicked <see cref="MenuFlyoutItem"/>.
    /// </returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual MenuFlyoutItem ClickChildOption(string name)
    {
        var item = ChildMenuItems.FirstOrDefault(
            element => element.GetName()
                .Equals(name, StringComparison.CurrentCultureIgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find element by {name}");
        }

        item.Click();
        return item;
    }

    /// <summary>
    /// Clicks on a child menu option with the specified partial item name.
    /// </summary>
    /// <param name="name">
    /// The partial name of the item to click.
    /// </param>
    /// <returns>
    /// The clicked <see cref="MenuFlyoutItem"/>.
    /// </returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual MenuFlyoutItem ClickChildOptionByPartialName(string name)
    {
        var item = ChildMenuItems.FirstOrDefault(
            element => element.GetName()
                .Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find element by {name}");
        }

        item.Click();
        return item;
    }

    /// <summary>
    /// Clicks on a child menu sub option with the specified item name.
    /// </summary>
    /// <param name="name">The name of the sub-item to click.</param>
    /// <returns>The clicked <see cref="MenuFlyoutSubItem"/>.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual MenuFlyoutSubItem ClickChildSubOption(string name)
    {
        var item = ChildMenuSubItems.FirstOrDefault(
            element => element.GetName()
                .Equals(name, StringComparison.CurrentCultureIgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find element by {name}");
        }

        item.Click();
        return item;
    }

    /// <summary>
    /// Clicks on a child menu sub option with the specified partial item name.
    /// </summary>
    /// <param name="name">The partial name of the sub-item to click.</param>
    /// <returns>The clicked <see cref="MenuFlyoutSubItem"/>.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual MenuFlyoutSubItem ClickChildSubOptionByPartialName(string name)
    {
        var item = ChildMenuSubItems.FirstOrDefault(
            element => element.GetName()
                .Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find element by {name}");
        }

        item.Click();
        return item;
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private IEnumerable<MenuFlyoutItem> GetChildMenuItems()
    {
        return Driver.FindElement(By.ClassName("MenuFlyout"))
            .FindElements(By.ClassName(nameof(MenuFlyoutItem))).Select(
                element => new MenuFlyoutItem(element));
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private IEnumerable<MenuFlyoutSubItem> GetChildMenuSubItems()
    {
        return Driver.FindElement(By.ClassName("MenuFlyout"))
            .FindElements(By.ClassName(nameof(MenuFlyoutSubItem))).Select(
                element => new MenuFlyoutSubItem(element));
    }
}
