namespace Legerity.IOS.Elements.Core;

using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core iOS Label control.
/// </summary>
public class Label : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Label"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Label(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the label.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.GetLabel();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Label"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Label"/>.
    /// </returns>
    public static implicit operator Label(WebElement element)
    {
        return new Label(element);
    }
}
