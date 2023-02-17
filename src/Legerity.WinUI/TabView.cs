namespace Legerity.Windows.Elements.WinUI;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Legerity.Exceptions;
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the WinUI TabView control.
/// </summary>
public class TabView : WindowsElementWrapper
{
    private readonly By tabListViewLocator = WindowsByExtras.AutomationId("TabListView");

    /// <summary>
    /// Initializes a new instance of the <see cref="TabView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public TabView(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the add tab button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button AddTabButton => this.FindElement(WindowsByExtras.AutomationId("AddButton"));

    /// <summary>
    /// Gets the collection of items associated with the pivot.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ReadOnlyCollection<AppiumWebElement> Tabs => this.TabsListView.Items;

    /// <summary>
    /// Gets the element associated with the currently selected item.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual AppiumWebElement SelectedItem => this.TabsListView.SelectedItem;

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private ListView TabsListView => this.FindElement(this.tabListViewLocator);

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="TabView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TabView"/>.
    /// </returns>
    public static implicit operator TabView(WindowsElement element)
    {
        return new TabView(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TabView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TabView"/>.
    /// </returns>
    public static implicit operator TabView(AppiumWebElement element)
    {
        return new TabView(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="TabView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TabView"/>.
    /// </returns>
    public static implicit operator TabView(RemoteWebElement element)
    {
        return new TabView(element as WindowsElement);
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
        this.VerifyElementShown(this.tabListViewLocator, TimeSpan.FromSeconds(2));
        this.AddTabButton.Click();
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
        this.VerifyElementShown(this.tabListViewLocator, TimeSpan.FromSeconds(2));
        AppiumWebElement item = this.Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));

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
        this.VerifyElementShown(this.tabListViewLocator, TimeSpan.FromSeconds(2));
        AppiumWebElement item = this.Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(name));

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
        this.VerifyElementShown(this.tabListViewLocator, TimeSpan.FromSeconds(2));
        AppiumWebElement item = this.Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
        }

        Button closeButton = item.FindElement(WindowsByExtras.AutomationId("CloseButton"));
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
        this.VerifyElementShown(this.tabListViewLocator, TimeSpan.FromSeconds(2));
        AppiumWebElement item = this.Tabs.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
        }

        Button closeButton = item.FindElement(WindowsByExtras.AutomationId("CloseButton"));
        closeButton.Click();
    }
}