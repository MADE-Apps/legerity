namespace Legerity.Web.Elements.Core;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web TextArea control.
/// </summary>
public class TextArea : TextInput
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextArea"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public TextArea(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextArea"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public TextArea(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the number of visible text lines.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual int Rows => int.Parse(GetAttribute("rows"));

    /// <summary>
    /// Gets the visible width.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual int Cols => int.Parse(GetAttribute("cols"));

    /// <summary>
    /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="TextArea"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextArea"/>.
    /// </returns>
    public static implicit operator TextArea(WebElement element)
    {
        return new TextArea(element);
    }
}