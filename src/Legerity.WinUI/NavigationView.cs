namespace Legerity.Windows.Elements.WinUI;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Extensions;
using Legerity.Extensions;
using Legerity.Windows.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the WinUI NavigationView control.
/// </summary>
public class NavigationView : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public NavigationView(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the UI component associated with displaying the menu items.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual WebElement MenuItemsView =>
        FindElement(WindowsByExtras.AutomationId("MenuItemsHost"));

    /// <summary>
    /// Gets the UI components associated with the menu items.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual IEnumerable<NavigationViewItem> MenuItems =>
        MenuItemsView.FindElements(By.ClassName("Microsoft.UI.Xaml.Controls.NavigationViewItem"))
            .Select(element => new NavigationViewItem(this, element as WebElement));

    /// <summary>
    /// Gets the currently selected menu item.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual NavigationViewItem SelectedMenuItem =>
        MenuItems.FirstOrDefault(item => item.IsSelected());

    /// <summary>
    /// Gets the UI component associated with the settings menu item.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual WebElement SettingsMenuItem =>
        FindElement(WindowsByExtras.AutomationId("SettingsItem"));

    /// <summary>
    /// Gets the UI component associated with the navigation pane toggle button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button ToggleNavigationPaneButton =>
        FindElement(WindowsByExtras.AutomationId("TogglePaneButton"));

    /// <summary>
    /// Gets the UI component associated with the navigation back button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button BackButton =>
        FindElement(WindowsByExtras.AutomationId("NavigationViewBackButton"));

    /// <summary>
    /// Gets a value indicating whether the pane is currently open.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual bool IsPaneOpen => VerifyPaneOpen(ExpectedCompactPaneWidth);

    /// <summary>
    /// Gets or sets the expected compact pane width used to determine the pane open state.
    /// </summary>
    public virtual int ExpectedCompactPaneWidth { get; set; } = 72;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="NavigationView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="NavigationView"/>.
    /// </returns>
    public static implicit operator NavigationView(WebElement element)
    {
        return new NavigationView(element);
    }

    /// <summary>
    /// Opens the navigation pane.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void OpenNavigationPane()
    {
        if (IsPaneOpen)
        {
            return;
        }

        ToggleNavigationPaneButton.Click();
    }

    /// <summary>
    /// Collapses the navigation pane.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CloseNavigationPane()
    {
        if (!IsPaneOpen)
        {
            return;
        }

        ToggleNavigationPaneButton.Click();
    }

    /// <summary>
    /// Navigates the view back.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void GoBack()
    {
        if (BackButton.IsEnabled)
        {
            BackButton.Click();
        }
    }

    /// <summary>
    /// Clicks on a menu option in the navigation view with the specified item name.
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
    public virtual NavigationViewItem ClickMenuOption(string name)
    {
        NavigationViewItem item = MenuItems.FirstOrDefault(
            element => element.GetName().Equals(name, StringComparison.CurrentCultureIgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
        }

        item.Click();
        return item;
    }

    /// <summary>
    /// Clicks on a menu option in the navigation view with the specified partial item name.
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
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual NavigationViewItem ClickMenuOptionByPartialName(string name)
    {
        NavigationViewItem item = MenuItems.FirstOrDefault(
            element => element.GetName().Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to locate element by {name}");
        }

        item.Click();
        return item;
    }

    /// <summary>
    /// Opens the settings option.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void OpenSettings()
    {
        SettingsMenuItem.Click();
    }

    /// <summary>
    /// Determines whether the navigation pane is open based on the specified compact pane width.
    /// </summary>
    /// <param name="expectedCompactPaneWidth">The expected compact pane width when closed.</param>
    /// <returns>True if the pane is open; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual bool VerifyPaneOpen(int expectedCompactPaneWidth)
    {
        WebElement pane = FindElement(WindowsByExtras.AutomationId("PaneRoot"));
        int paneWidth = pane.GetBoundingRect().Width;
        return paneWidth > expectedCompactPaneWidth;
    }
}