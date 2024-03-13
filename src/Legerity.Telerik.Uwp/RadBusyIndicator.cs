namespace Legerity.Windows.Elements.Telerik;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Telerik UWP RadBusyIndicator control.
/// </summary>
public class RadBusyIndicator : WindowsElementWrapper
{
    private const string OnValue = "On";

    /// <summary>
    /// Initializes a new instance of the <see cref="RadBusyIndicator"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public RadBusyIndicator(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the busy indicator is on.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsOn => GetAttribute("ItemStatus") == OnValue;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="RadBusyIndicator"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="RadBusyIndicator"/>.
    /// </returns>
    public static implicit operator RadBusyIndicator(WebElement element)
    {
        return new RadBusyIndicator(element);
    }
}
