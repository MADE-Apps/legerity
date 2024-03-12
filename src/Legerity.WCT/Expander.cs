namespace Legerity.Windows.Elements.WCT;

using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Windows Community Toolkit Expander control.
/// </summary>
public class Expander : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Expander"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Expander(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the expander has the content expanded (visible).
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsExpanded => this.GetToggleState() == ToggleState.Checked;

    /// <summary>
    /// Gets the <see cref="ToggleButton"/> associated with the expander.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ToggleButton ToggleButton => FindElement(WindowsByExtras.AutomationId("PART_ExpanderToggleButton"));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Expander"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Expander"/>.
    /// </returns>
    public static implicit operator Expander(WebElement element)
    {
        return new Expander(element);
    }

    /// <summary>
    /// Expands the content of the expander.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Expand()
    {
        if (IsExpanded)
        {
            return;
        }

        ToggleButton.Click();
    }

    /// <summary>
    /// Collapses the content of the expander.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Collapse()
    {
        if (!IsExpanded)
        {
            return;
        }

        ToggleButton.Click();
    }
}