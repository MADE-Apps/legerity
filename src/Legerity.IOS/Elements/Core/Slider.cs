namespace Legerity.IOS.Elements.Core;

using System;
using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core iOS Slider control.
/// </summary>
public class Slider : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Slider"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Slider(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the slider as a percentage between 0 and 100.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => double.Parse(this.GetValue().TrimEnd('%'));

    /// <summary>
    /// Gets a value indicating whether the control is in a readonly state.
    /// </summary>
    public virtual bool IsReadonly => !IsEnabled;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Slider"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Slider"/>.
    /// </returns>
    public static implicit operator Slider(WebElement element)
    {
        return new Slider(element);
    }
    
    /// <summary>
    /// Sets the value of the slider.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SetValue(double value)
    {
        Click();

        var currentValue = Value;
        while (Math.Abs(currentValue - value) > double.Epsilon)
        {
            Element.SendKeys(currentValue < value ? Keys.ArrowRight : Keys.ArrowLeft);
            currentValue = Value;
        }
    }
}
