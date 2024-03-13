namespace Legerity.Windows.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP AppBarButton control.
/// </summary>
public class AppBarButton : Button
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppBarButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public AppBarButton(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="AppBarButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="AppBarButton"/>.
    /// </returns>
    public static implicit operator AppBarButton(WebElement element)
    {
        return new AppBarButton(element);
    }
}
