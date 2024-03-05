namespace Legerity.IOS.Elements.Core;

using Legerity.IOS.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core iOS Button control.
/// </summary>
public class Button : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Button"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Button(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the button's label content.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Label => this.GetLabel();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Button"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Button"/>.
    /// </returns>
    public static implicit operator Button(WebElement element)
    {
        return new Button(element);
    }
}