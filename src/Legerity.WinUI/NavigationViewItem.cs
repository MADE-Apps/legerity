// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using Legerity.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.WinUI;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the WinUI NavigationViewItem control.
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
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public NavigationViewItem(AppiumElement element)
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
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public NavigationViewItem(NavigationView parentNavigationView, AppiumElement element)
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
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public NavigationViewItem(NavigationViewItem parentItem, AppiumElement element)
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
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public NavigationViewItem(
        NavigationView parentNavigationView,
        NavigationViewItem parentItem,
        AppiumElement element)
        : base(element)
    {
        if (parentNavigationView != null)
        {
            this.parentNavigationViewReference = new WeakReference(parentNavigationView);
        }

        if (parentItem != null)
        {
            this.parentItemReference = new WeakReference(parentItem);
        }
    }

    /// <summary>Gets the original parent <see cref="NavigationView"/> reference object.</summary>
    public NavigationView ParentNavigationView =>
        this.parentNavigationViewReference is { IsAlive: true }
            ? this.parentNavigationViewReference.Target as NavigationView
            : null;

    /// <summary>Gets the original parent <see cref="NavigationViewItem"/> reference object.</summary>
    public NavigationViewItem ParentItem =>
        this.parentItemReference is { IsAlive: true }
            ? this.parentItemReference.Target as NavigationViewItem
            : null;

    /// <summary>
    /// Gets the UI components associated with the child menu items.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual IEnumerable<NavigationViewItem> ChildMenuItems => this.GetChildMenuItems();

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
        return new NavigationViewItem(element as AppiumElement);
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
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual NavigationViewItem ClickChildOption(string name)
    {
        NavigationViewItem item = this.ChildMenuItems.FirstOrDefault(
            element => element.GetName()
                .Equals(name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new NoSuchElementException($"Unable to locate element by {name}");
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
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual NavigationViewItem ClickChildOptionByPartialName(string name)
    {
        NavigationViewItem item = this.ChildMenuItems.FirstOrDefault(
            element => element.GetName()
                .Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase)) ?? throw new NoSuchElementException($"Unable to locate element by {name}");
        item.Click();
        return item;
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private IEnumerable<NavigationViewItem> GetChildMenuItems()
    {
        if (this.ParentNavigationView == null || this.ParentNavigationView.IsPaneOpen)
        {
            return this.Element.FindElements(this.navigationViewItemLocator).Select(
                element => new NavigationViewItem(this.ParentNavigationView, this, element as AppiumElement));
        }

        return this.Driver.FindElement(WindowsByExtras.AutomationId("ChildrenFlyout"))
            .FindElements(this.navigationViewItemLocator).Select(
                element => new NavigationViewItem(this.ParentNavigationView, this, element as AppiumElement));
    }
}