namespace Legerity.Windows.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP TextBlock control.
/// </summary>
public class TextBlock : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextBlock"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public TextBlock(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text block.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.Element.Text;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="TextBlock"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextBlock"/>.
    /// </returns>
    public static implicit operator TextBlock(WebElement element)
    {
        return new TextBlock(element);
    }
}