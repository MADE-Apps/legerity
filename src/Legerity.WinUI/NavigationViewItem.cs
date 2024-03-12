namespace Legerity.Windows.Elements.WinUI;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Legerity.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the WinUI NavigationViewItem control.
/// </summary>
public class NavigationViewItem : WindowsElementWrapper
{
    private readonly By navigationViewItemLocator = By.ClassName("Microsoft.UI.Xaml.Controls.NavigationViewItem");

    private readonly WeakReference parentNavigationViewReference;

    private readonly WeakReference parentItemReference;

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationViewItem"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public NavigationViewItem(WebElement element)
        : this(null, null, element)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationViewItem"/> class.
    /// </summary>
    /// <param name="parentNavigationView">
    /// The parent <see cref="NavigationView"/>.
    /// </param>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public NavigationViewItem(NavigationView parentNavigationView, WebElement element)
        : this(parentNavigationView, null, element)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationViewItem"/> class.
    /// </summary>
    /// <param name="parentItem">
    /// The parent <see cref="NavigationViewItem"/>.
    /// </param>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public NavigationViewItem(NavigationViewItem parentItem, WebElement element)
        : this(null, parentItem, element)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationViewItem"/> class.
    /// </summary>
    /// <param name="parentNavigationView">
    /// The parent <see cref="NavigationView"/>.
    /// </param>
    /// <param name="parentItem">
    /// The parent <see cref="NavigationViewItem"/>.
    /// </param>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public NavigationViewItem(
        NavigationView parentNavigationView,
        NavigationViewItem parentItem,
        WebElement element)
        : base(element)
    {
        if (parentNavigationView != null)
        {
            parentNavigationViewReference = new WeakReference(parentNavigationView);
        }

        if (parentItem != null)
        {
            parentItemReference = new WeakReference(parentItem);
        }
    }

    /// <summary>Gets the original parent <see cref="NavigationView"/> reference object.</summary>
    public NavigationView ParentNavigationView =>
        parentNavigationViewReference is { IsAlive: true }
            ? parentNavigationViewReference.Target as NavigationView
            : null;

    /// <summary>Gets the original parent <see cref="NavigationViewItem"/> reference object.</summary>
    public NavigationViewItem ParentItem =>
        parentItemReference is { IsAlive: true }
            ? parentItemReference.Target as NavigationViewItem
            : null;

    /// <summary>
    /// Gets the UI components associated with the child menu items.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual IEnumerable<NavigationViewItem> ChildMenuItems => GetChildMenuItems();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="NavigationViewItem"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="NavigationViewItem"/>.
    /// </returns>
    public static implicit operator NavigationViewItem(WebElement element)
    {
        return new NavigationViewItem(element);
    }
    
    /// <summary>
    /// Clicks on a child menu option with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to click.
    /// </param>
    /// <returns>
    /// The clicked <see cref="NavigationViewItem"/>.
    /// </returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual NavigationViewItem ClickChildOption(string name)
    {
        NavigationViewItem item = ChildMenuItems.FirstOrDefault(
            element => element.GetName()
                .Equals(name, StringComparison.CurrentCultureIgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
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
    /// The clicked <see cref="NavigationViewItem"/>.
    /// </returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual NavigationViewItem ClickChildOptionByPartialName(string name)
    {
        NavigationViewItem item = ChildMenuItems.FirstOrDefault(
            element => element.GetName()
                .Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
        }

        item.Click();
        return item;
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private IEnumerable<NavigationViewItem> GetChildMenuItems()
    {
        if (ParentNavigationView == null || ParentNavigationView.IsPaneOpen)
        {
            return Element.FindElements(navigationViewItemLocator).Select(
                element => new NavigationViewItem(ParentNavigationView, this, element as WebElement));
        }

        return Driver.FindElement(WindowsByExtras.AutomationId("ChildrenFlyout"))
            .FindElements(navigationViewItemLocator).Select(
                element => new NavigationViewItem(ParentNavigationView, this, element));
    }
}