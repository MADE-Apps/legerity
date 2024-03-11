namespace Legerity.Windows.Elements.Telerik;

using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Telerik UWP RadBulletGraph control.
/// </summary>
public class RadBulletGraph : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RadBulletGraph"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public RadBulletGraph(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the minimum value of the bullet graph.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Minimum => this.GetRangeMinimum();

    /// <summary>
    /// Gets the maximum value of the bullet graph.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Maximum => this.GetRangeMaximum();

    /// <summary>
    /// Gets the value of the bullet graph.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => this.GetRangeValue();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="RadBulletGraph"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="RadBulletGraph"/>.
    /// </returns>
    public static implicit operator RadBulletGraph(WebElement element)
    {
        return new RadBulletGraph(element);
    }
}