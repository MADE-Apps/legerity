namespace Legerity.Android.Elements.Core;

using Legerity.Android.Elements;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core Android View base control.
/// </summary>
public class View : AndroidElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="View"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public View(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="View"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="View"/>.
    /// </returns>
    public static implicit operator View(WebElement element)
    {
        return new View(element);
    }
}