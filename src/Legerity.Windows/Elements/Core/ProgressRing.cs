namespace Legerity.Windows.Elements.Core;

using Legerity.Windows.Extensions;
using System;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP ProgressRing control.
/// </summary>
public class ProgressRing : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressRing"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public ProgressRing(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the progress ring.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Percentage => this.GetRangeValue();

    /// <summary>
    /// Gets a value indicating whether the control is in an indeterminate state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public bool IsIndeterminate =>
        this.GetAttribute("IsRangeValuePatternAvailable").Equals(
            "False",
            StringComparison.CurrentCultureIgnoreCase);

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="ProgressRing"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ProgressRing"/>.
    /// </returns>
    public static implicit operator ProgressRing(WebElement element)
    {
        return new ProgressRing(element);
    }
}