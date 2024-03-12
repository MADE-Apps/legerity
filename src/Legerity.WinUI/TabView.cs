namespace Legerity.Windows.Elements.WinUI;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Legerity.Exceptions;
using Core;
using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the WinUI TabView control.
/// </summary>
public class TabView : WindowsElementWrapper
{
    private readonly By tabListViewLocator = WindowsByExtras.AutomationId("TabListView");

    /// <summary>
    /// Initializes a new instance of the <see cref="TabView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public TabView(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the add tab button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button AddTabButton => FindElement(WindowsByExtras.AutomationId("AddButton"));

    /// <summary>
    /// Gets the collection of items associated with the pivot.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ReadOnlyCollection<WebElement> Tabs => TabsListView.Items;

    /// <summary>
    /// Gets the element associated with the currently selected item.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual WebElement SelectedItem => TabsListView.SelectedItem;

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private ListView TabsListView => FindElement(tabListViewLocator);

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="TabView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TabView"/>.
    /// </returns>
    public static implicit operator TabView(WebElement element)
    {
        return new TabView(element);
    }

    /// <summary>
    /// Adds a new tab to the tab view.
    /// </summary>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CreateTab()
    {
        VerifyElementShown(tabListViewLocator, TimeSpan.FromSeconds(2));
        AddTabButton.Click();
    }

    /// <summary>
    /// Clicks on a tab in the view with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to click.
    /// </param>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectTab(string name)
    {
        VerifyElementShown(tabListViewLocator, TimeSpan.FromSeconds(2));
        var item = Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
        }

        item.Click();
    }

    /// <summary>
    /// Clicks on a tab in the view with the specified partial item name.
    /// </summary>
    /// <param name="name">
    /// The partial name of the item to click.
    /// </param>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void SelectTabByPartialName(string name)
    {
        VerifyElementShown(tabListViewLocator, TimeSpan.FromSeconds(2));
        var item = Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
        }

        item.Click();
    }

    /// <summary>
    /// Closes a tab in the view with the specified item name.
    /// </summary>
    /// <param name="name">The name of the item to close.</param>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void CloseTab(string name)
    {
        VerifyElementShown(tabListViewLocator, TimeSpan.FromSeconds(2));
        var item = Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
        }

        Button closeButton = item.FindElement(WindowsByExtras.AutomationId("CloseButton")) as WebElement;
        closeButton.Click();
    }

    /// <summary>
    /// Closes a tab in the view with the specified partial item name.
    /// </summary>
    /// <param name="name">The partial name of the item to close.</param>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CloseTabByPartialName(string name)
    {
        VerifyElementShown(tabListViewLocator, TimeSpan.FromSeconds(2));
        var item = Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
        }

        Button closeButton = item.FindElement(WindowsByExtras.AutomationId("CloseButton")) as WebElement;
        closeButton.Click();
    }
}
