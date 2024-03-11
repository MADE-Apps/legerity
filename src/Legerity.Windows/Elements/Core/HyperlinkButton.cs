namespace Legerity.Windows.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP HyperlinkButton control.
/// </summary>
public class HyperlinkButton : Button
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HyperlinkButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public HyperlinkButton(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="HyperlinkButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="HyperlinkButton"/>.
    /// </returns>
    public static implicit operator HyperlinkButton(WebElement element)
    {
        return new HyperlinkButton(element);
    }
}