namespace Legerity.Windows.Elements.Core;

using System;
using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP ProgressBar control.
/// </summary>
public class ProgressBar : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressBar"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public ProgressBar(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the progress bar.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Percentage => this.GetRangeValue();

    /// <summary>
    /// Gets a value indicating whether the control is in an indeterminate state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public bool IsIndeterminate =>
        GetAttribute("IsRangeValuePatternAvailable").Equals(
            "False",
            StringComparison.CurrentCultureIgnoreCase);

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="ProgressBar"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ProgressBar"/>.
    /// </returns>
    public static implicit operator ProgressBar(WebElement element)
    {
        return new ProgressBar(element);
    }
}
