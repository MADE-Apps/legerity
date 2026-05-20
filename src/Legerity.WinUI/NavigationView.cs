// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using Legerity.Extensions;
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.WinUI;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the WinUI NavigationView control.
/// </summary>
public class NavigationView : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public NavigationView(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the UI component associated with displaying the menu items.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual AppiumElement MenuItemsView =>
        this.FindElement(WindowsByExtras.AutomationId("MenuItemsHost"));

    /// <summary>
    /// Gets the UI components associated with the menu items.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual IEnumerable<NavigationViewItem> MenuItems =>
        this.MenuItemsView.FindElements(By.ClassName("Microsoft.UI.Xaml.Controls.NavigationViewItem"))
            .Select(element => new NavigationViewItem(this, element as AppiumElement));

    /// <summary>
    /// Gets the currently selected menu item.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual NavigationViewItem SelectedMenuItem =>
        this.MenuItems.FirstOrDefault(item => item.IsSelected());

    /// <summary>
    /// Gets the UI component associated with the settings menu item.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual AppiumElement SettingsMenuItem =>
        this.FindElement(WindowsByExtras.AutomationId("SettingsItem"));

    /// <summary>
    /// Gets the UI component associated with the navigation pane toggle button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button ToggleNavigationPaneButton =>
        this.FindElement(WindowsByExtras.AutomationId("TogglePaneButton"));

    /// <summary>
    /// Gets the UI component associated with the navigation back button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button BackButton =>
        this.FindElement(WindowsByExtras.AutomationId("NavigationViewBackButton"));

    /// <summary>
    /// Gets a value indicating whether the pane is currently open.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual bool IsPaneOpen => this.VerifyPaneOpen(this.ExpectedCompactPaneWidth);

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
        return new NavigationView(element as AppiumElement);
    }

    /// <summary>
    /// Opens the navigation pane.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void OpenNavigationPane()
    {
        if (this.IsPaneOpen)
        {
            return;
        }

        this.ToggleNavigationPaneButton.Click();
    }

    /// <summary>
    /// Collapses the navigation pane.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CloseNavigationPane()
    {
        if (!this.IsPaneOpen)
        {
            return;
        }

        this.ToggleNavigationPaneButton.Click();
    }

    /// <summary>
    /// Navigates the view back.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void GoBack()
    {
        if (this.BackButton.IsEnabled)
        {
            this.BackButton.Click();
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
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual NavigationViewItem ClickMenuOption(string name)
    {
        NavigationViewItem item = this.MenuItems.FirstOrDefault(
            element => element.GetName().Equals(name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new NoSuchElementException($"Unable to locate element by {name}");
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
    public virtual NavigationViewItem ClickMenuOptionByPartialName(string name)
    {
        NavigationViewItem item = this.MenuItems.FirstOrDefault(
            element => element.GetName().Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase)) ?? throw new NoSuchElementException($"Unable to locate element by {name}");
        item.Click();
        return item;
    }

    /// <summary>
    /// Opens the settings option.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void OpenSettings()
    {
        this.SettingsMenuItem.Click();
    }

    /// <summary>
    /// Determines whether the navigation pane is open based on the specified compact pane width.
    /// </summary>
    /// <param name="expectedCompactPaneWidth">The expected compact pane width when closed.</param>
    /// <returns>True if the pane is open; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual bool VerifyPaneOpen(int expectedCompactPaneWidth)
    {
        AppiumElement pane = this.FindElement(WindowsByExtras.AutomationId("PaneRoot"));
        var paneWidth = pane.Rect.Width;
        return paneWidth > expectedCompactPaneWidth;
    }
}