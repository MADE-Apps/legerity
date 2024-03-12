namespace Legerity.Windows.Elements.WCT;

using System;
using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Windows Community Toolkit RadialGauge control.
/// </summary>
public class RadialGauge : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RadialGauge"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public RadialGauge(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the minimum value of the gauge.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Minimum => this.GetRangeMinimum();

    /// <summary>
    /// Gets the maximum value of the gauge.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Maximum => this.GetRangeMaximum();

    /// <summary>
    /// Gets the small change (step) value of the gauge.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double SmallChange => this.GetRangeSmallChange();

    /// <summary>
    /// Gets the value of the gauge.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => this.GetRangeValue();

    /// <summary>
    /// Gets a value indicating whether the control is in a readonly state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsReadonly => this.IsRangeReadonly();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="RadialGauge"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="RadialGauge"/>.
    /// </returns>
    public static implicit operator RadialGauge(WebElement element)
    {
        return new RadialGauge(element);
    }
    
    /// <summary>
    /// Sets the value of the gauge.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the value is out of the minimum and maximum range of the gauge.
    /// </exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SetValue(double value)
    {
        var min = Minimum;
        var max = Maximum;

        if (value < Minimum)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                value,
                $"Value must be greater than or equal to the minimum value {min}");
        }

        if (value > Maximum)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                value,
                $"Value must be less than or equal to the maximum value {max}");
        }

        Click();

        var currentValue = Value;
        while (Math.Abs(currentValue - value) > double.Epsilon)
        {
            Element.SendKeys(currentValue < value ? Keys.ArrowRight : Keys.ArrowLeft);
            currentValue = Value;
        }
    }
}
