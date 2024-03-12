namespace Legerity.Windows.Elements.Core;

using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP ToggleButton control.
/// </summary>
public class ToggleButton : Button
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToggleButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public ToggleButton(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the toggle button is in the on position.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsOn => this.GetToggleState() == ToggleState.Checked;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="ToggleButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ToggleButton"/>.
    /// </returns>
    public static implicit operator ToggleButton(WebElement element)
    {
        return new ToggleButton(element);
    }
    
    /// <summary>
    /// Toggles the button on.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ToggleOn()
    {
        if (IsOn)
        {
            return;
        }

        Click();
    }

    /// <summary>
    /// Toggles the button off.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ToggleOff()
    {
        if (!IsOn)
        {
            return;
        }

        Click();
    }
}
