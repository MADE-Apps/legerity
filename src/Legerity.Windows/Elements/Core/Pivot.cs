// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using Legerity.Exceptions;
using Legerity.Windows.Extensions;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core UWP Pivot control.
/// </summary>
public class Pivot : WindowsElementWrapper
{
    private readonly By pivotItemLocator = By.ClassName("PivotItem");

    /// <summary>
    /// Initializes a new instance of the <see cref="Pivot"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public Pivot(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the pivot.
    /// </summary>
    public virtual ReadOnlyCollection<AppiumElement> Items => this.Element.FindElements(this.pivotItemLocator);

    /// <summary>
    /// Gets the currently selected item.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual AppiumElement SelectedItem => this.Items.FirstOrDefault(i => i.IsSelected());

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Pivot"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Pivot"/>.
    /// </returns>
    public static implicit operator Pivot(WebElement element)
    {
        return new Pivot(element as AppiumElement);
    }

    /// <summary>
    /// Clicks on an item in the pivot with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to click.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClickItem(string name)
    {
        this.VerifyElementsShown(this.pivotItemLocator, TimeSpan.FromSeconds(2));

        AppiumElement item = this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name)) ?? throw new NoSuchElementException($"Unable to find element using {name}");
        item.Click();
    }

    /// <summary>
    /// Clicks on an item in the pivot with the specified partial item name.
    /// </summary>
    /// <param name="name">
    /// The partial name of the item to click.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClickItemByPartialName(string name)
    {
        this.VerifyElementsShown(this.pivotItemLocator, TimeSpan.FromSeconds(2));

        AppiumElement item = this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdContains(name)) ?? throw new NoSuchElementException($"Unable to find element using {name}");
        item.Click();
    }
}