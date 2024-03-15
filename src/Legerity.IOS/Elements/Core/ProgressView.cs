namespace Legerity.IOS.Elements.Core;

using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core iOS ProgressView control.
/// </summary>
public class ProgressView : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public ProgressView(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the progress bar.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Percentage => double.Parse(this.GetValue().TrimEnd('%'));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="ProgressView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ProgressView"/>.
    /// </returns>
    public static implicit operator ProgressView(WebElement element)
    {
        return new ProgressView(element);
    }
}
