namespace Legerity.Windows.Elements.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using Legerity.Exceptions;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP CommandBar control.
/// </summary>
public class CommandBar : WindowsElementWrapper
{
    private readonly By moreButtonLocator = WindowsByExtras.AutomationId("MoreButton");

    private readonly By overflowPopupLocator = WindowsByExtras.AutomationId("OverflowPopup");

    private readonly By appBarButtonLocator = By.ClassName(nameof(AppBarButton));

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandBar"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public CommandBar(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of primary buttons.
    /// </summary>
    public virtual IEnumerable<AppBarButton> PrimaryButtons =>
        Element.FindElements(appBarButtonLocator)
            .Select<IWebElement, AppBarButton>(element => element as WebElement);

    /// <summary>
    /// Gets the <see cref="AppBarButton"/> for opening the secondary button menu.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual AppBarButton SecondaryMenuButton => FindElement(moreButtonLocator);

    /// <summary>
    /// Gets the collection of secondary buttons.
    /// <para>
    /// Note, this property will only return a result when the secondary buttons are shown in the flyout.
    /// </para>
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual IEnumerable<AppBarButton> SecondaryButtons =>
        Driver.FindElement(overflowPopupLocator).FindElements(appBarButtonLocator)
            .Select<WebElement, AppBarButton>(element => element);

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="CommandBar"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CommandBar"/>.
    /// </returns>
    public static implicit operator CommandBar(WebElement element)
    {
        return new CommandBar(element);
    }

    /// <summary>
    /// Clicks a primary button in the command bar with the specified button name or Automation ID.
    /// </summary>
    /// <param name="name">
    /// The name of the button to click.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClickPrimaryButton(string name)
    {
        var item = PrimaryButtons.FirstOrDefault(
            element => element.Element.VerifyNameOrAutomationIdEquals(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find primary button {name}.");
        }

        item.Click();
    }

    /// <summary>
    /// Clicks a primary button in the command bar with the specified partial button name or Automation ID.
    /// </summary>
    /// <param name="partialName">
    /// The partial name of the button to click.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClickPrimaryButtonByPartialName(string partialName)
    {
        var item = PrimaryButtons.FirstOrDefault(
            element => element.Element.VerifyNameOrAutomationIdContains(partialName));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find primary button {partialName}.");
        }

        item.Click();
    }

    /// <summary>
    /// Clicks a secondary button in the command bar with the specified button name.
    /// </summary>
    /// <param name="name">
    /// The name of the button to click.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotShownException">Thrown when the more button is not shown.</exception>
    public virtual void ClickSecondaryButton(string name)
    {
        OpenSecondaryButtonMenu();

        var secondaryButton = SecondaryButtons.FirstOrDefault(
            button => button.Element.VerifyNameOrAutomationIdEquals(name));

        if (secondaryButton == null)
        {
            throw new NoSuchElementException($"Unable to find secondary button {name}.");
        }

        secondaryButton.Click();
    }

    /// <summary>
    /// Clicks a secondary button in the command bar with the specified partial button name.
    /// </summary>
    /// <param name="partialName">
    /// The partial name of the button to click.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotShownException">Thrown when the more button is not shown.</exception>
    public virtual void ClickSecondaryButtonByPartialName(string partialName)
    {
        OpenSecondaryButtonMenu();

        var secondaryButton = SecondaryButtons.FirstOrDefault(
            button => button.Element.VerifyNameOrAutomationIdContains(partialName));

        if (secondaryButton == null)
        {
            throw new NoSuchElementException($"Unable to find secondary button {partialName}.");
        }

        secondaryButton.Click();
    }

    /// <summary>
    /// Opens the menu associated with the secondary button options.
    /// </summary>
    /// <exception cref="ElementNotShownException">Thrown when the more button is not shown.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void OpenSecondaryButtonMenu()
    {
        VerifyElementShown(moreButtonLocator, TimeSpan.FromSeconds(2));
        SecondaryMenuButton.Click();
        VerifyDriverElementShown(overflowPopupLocator, TimeSpan.FromSeconds(2));
    }
}
