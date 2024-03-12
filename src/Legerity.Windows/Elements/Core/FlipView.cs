namespace Legerity.Windows.Elements.Core;

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Legerity.Extensions;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP FlipView control.
/// </summary>
public class FlipView : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FlipView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public FlipView(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the flip view.
    /// </summary>
    public virtual ReadOnlyCollection<WebElement> Items => Element.FindElements(By.ClassName("FlipViewItem")).Cast<WebElement>().ToList().AsReadOnly();

    /// <summary>
    /// Gets the element associated with the next item button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button NextButton => FindElement(WindowsByExtras.AutomationId("NextButtonHorizontal"));

    /// <summary>
    /// Gets the element associated with the previous item button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button PreviousButton => FindElement(WindowsByExtras.AutomationId("PreviousButtonHorizontal"));

    /// <summary>
    /// Gets the currently selected item.
    /// </summary>
    public virtual WebElement SelectedItem => Items.FirstOrDefault(i => i.IsSelected());

    /// <summary>
    /// Gets the currently selected item index.
    /// </summary>
    public virtual int SelectedIndex => Items.IndexOf(SelectedItem);

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="FlipView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="FlipView"/>.
    /// </returns>
    public static implicit operator FlipView(WebElement element)
    {
        return new FlipView(element);
    }
    
    /// <summary>
    /// Selects an item in the flip view by the specified name.
    /// </summary>
    /// <param name="name">
    /// The name of the item.
    /// </param>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void SelectItem(string name)
    {
        int expectedItemIdx = Items.IndexOf(Items.FirstOrDefault(x =>
            x.Text.Contains(name, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase)));
        SelectItemByIndex(expectedItemIdx);
    }

    /// <summary>
    /// Selects an items in the flip view by index.
    /// </summary>
    /// <param name="index">The index of the item to select.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectItemByIndex(int index)
    {
        int currentItemIdx = SelectedIndex;
        int diff = index - currentItemIdx;
        int shifts = Math.Abs(diff);

        for (int i = 0; i < shifts; i++)
        {
            if (diff > 0)
            {
                SelectNext();
            }
            else
            {
                SelectPrevious();
            }
        }
    }

    /// <summary>
    /// Selects the next item in the flip view.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectNext()
    {
        Click();
        Element.SendKeys(Keys.ArrowRight);
    }

    /// <summary>
    /// Selects the previous item in the flip view.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectPrevious()
    {
        Click();
        Element.SendKeys(Keys.ArrowLeft);
    }
}