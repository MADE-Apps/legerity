namespace Legerity.Windows.Elements.Core;

using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP AppBarToggleButton control.
/// </summary>
public class AppBarToggleButton : AppBarButton
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppBarToggleButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public AppBarToggleButton(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the toggle button is in the on position.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsOn => this.GetToggleState() == ToggleState.Checked;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="AppBarToggleButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="AppBarToggleButton"/>.
    /// </returns>
    public static implicit operator AppBarToggleButton(WebElement element)
    {
        return new AppBarToggleButton(element);
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