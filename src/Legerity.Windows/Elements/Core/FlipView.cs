// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using System.Globalization;
using Legerity.Extensions;
using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core UWP FlipView control.
/// </summary>
public class FlipView : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FlipView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public FlipView(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the flip view.
    /// </summary>
    public virtual ReadOnlyCollection<AppiumElement> Items => this.Element.FindElements(By.ClassName("FlipViewItem"));

    /// <summary>
    /// Gets the element associated with the next item button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button NextButton => this.FindElement(WindowsByExtras.AutomationId("NextButtonHorizontal"));

    /// <summary>
    /// Gets the element associated with the previous item button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button PreviousButton => this.FindElement(WindowsByExtras.AutomationId("PreviousButtonHorizontal"));

    /// <summary>
    /// Gets the currently selected item.
    /// </summary>
    public virtual AppiumElement SelectedItem
    {
        get
        {
            var items = this.Items;
            var idx = GetSelectedIndexFromItems(items);
            return idx >= 0 && idx < items.Count ? items[idx] : items.FirstOrDefault();
        }
    }

    /// <summary>
    /// Gets the currently selected item index.
    /// </summary>
    public virtual int SelectedIndex => GetSelectedIndexFromItems(this.Items);

    private int GetSelectedIndexFromItems(ReadOnlyCollection<AppiumElement> items)
    {
        // WinUI FlipView has a bug where all items report SelectionItem.IsSelected = true.
        // Use the FlipView's own Selection.Selection attribute which correctly reports
        // the selected item name.
        var selectedName = this.Element.GetAttribute("Selection.Selection");
        if (!string.IsNullOrEmpty(selectedName))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (selectedName.Equals(items[i].GetAttribute("Name"), StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
        }

        return 0;
    }

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
        return new FlipView(element as AppiumElement);
    }

    /// <summary>
    /// Selects an item in the flip view by the specified name.
    /// </summary>
    /// <param name="name">
    /// The name of the item.
    /// </param>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    public virtual void SelectItem(string name)
    {
        var expectedItemIdx = this.Items.IndexOf(this.Items.FirstOrDefault(x =>
            x.Text.Contains(name, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase)));
        this.SelectItemByIndex(expectedItemIdx);
    }

    /// <summary>
    /// Selects an items in the flip view by index.
    /// </summary>
    /// <param name="index">The index of the item to select.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectItemByIndex(int index)
    {
        var currentItemIdx = this.SelectedIndex;
        var diff = index - currentItemIdx;
        var shifts = Math.Abs(diff);

        for (var i = 0; i < shifts; i++)
        {
            if (diff > 0)
            {
                this.SelectNext();
            }
            else
            {
                this.SelectPrevious();
            }
        }
    }

    /// <summary>
    /// Selects the next item in the flip view.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectNext()
    {
        this.Element.SendKeys(Keys.ArrowRight);
    }

    /// <summary>
    /// Selects the previous item in the flip view.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectPrevious()
    {
        this.Element.SendKeys(Keys.ArrowLeft);
    }
}