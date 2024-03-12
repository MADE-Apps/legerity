namespace Legerity.Web.Elements.Core;

using Extensions;
using Legerity.Web.Elements;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Image control.
/// </summary>
public class Image : WebElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Image"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public Image(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Image"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Image(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the source URI of the image.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Source => GetAttribute("src");

    /// <summary>
    /// Gets the alt text of the image.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string AltText => GetAttribute("alt");

    /// <summary>
    /// Gets the width of the image.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Width => this.GetWidth();

    /// <summary>
    /// Gets the height of the image.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Height => this.GetHeight();

    /// <summary>
    /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="Image"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Image"/>.
    /// </returns>
    public static implicit operator Image(WebElement element)
    {
        return new Image(element);
    }
}