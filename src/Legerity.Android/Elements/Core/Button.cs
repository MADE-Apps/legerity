namespace Legerity.Android.Elements.Core;

using Elements;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core Android Button control.
/// </summary>
public class Button : AndroidElementWrapper
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
