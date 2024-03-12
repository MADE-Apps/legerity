namespace Legerity.Web.Elements.Core;

using System;
using Extensions;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Input range control.
/// </summary>
public class RangeInput : TextInput
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RangeInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public RangeInput(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RangeInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public RangeInput(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the minimum value of the range input.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Minimum => this.GetMinimum();

    /// <summary>
    /// Gets the maximum value of the range input.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Maximum => this.GetMaximum();

    /// <summary>
    /// Gets the value of the range input.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => double.TryParse(Text, out double val) ? val : 0;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="RangeInput"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="RangeInput"/>.
    /// </returns>
    public static implicit operator RangeInput(WebElement element)
    {
        return new RangeInput(element);
    }

    /// <summary>
    /// Sets the value of the range input.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the value is out of the minimum and maximum range of the range input.
    /// </exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SetValue(double value)
    {
        double min = Minimum;
        double max = Maximum;

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

        double currentValue = Value;
        while (Math.Abs(currentValue - value) > double.Epsilon)
        {
            Element.SendKeys(currentValue < value ? Keys.ArrowRight : Keys.ArrowLeft);
            currentValue = Value;
        }
    }

    /// <summary>
    /// Increases the range input value.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Increment()
    {
        Element.SendKeys(Keys.ArrowUp);
    }

    /// <summary>
    /// Decreases the range input value.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Decrement()
    {
        Element.SendKeys(Keys.ArrowDown);
    }
}