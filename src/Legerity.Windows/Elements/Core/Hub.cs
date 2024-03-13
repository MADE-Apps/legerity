namespace Legerity.Windows.Elements.Core;

using System.Collections.ObjectModel;
using System.Linq;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP Hub control.
/// </summary>
public class Hub : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Hub"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Hub(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the hub.
    /// </summary>
    public virtual ReadOnlyCollection<WebElement> Items => Element.FindElements(By.ClassName("HubSection")).Cast<WebElement>().ToList().AsReadOnly();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Hub"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Hub"/>.
    /// </returns>
    public static implicit operator Hub(WebElement element)
    {
        return new Hub(element);
    }
}
