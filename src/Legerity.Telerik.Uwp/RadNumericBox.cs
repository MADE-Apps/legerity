namespace Legerity.Windows.Elements.Telerik;

using System;
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Telerik UWP RadNumericBox control.
/// </summary>
public class RadNumericBox : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RadNumericBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public RadNumericBox(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the minimum value of the RadNumericBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Minimum => this.GetRangeMinimum();

    /// <summary>
    /// Gets the maximum value of the RadNumericBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Maximum => this.GetRangeMaximum();

    /// <summary>
    /// Gets the small change (step) value of the RadNumericBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double SmallChange => this.GetRangeSmallChange();

    /// <summary>
    /// Gets the value of the RadNumericBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => this.GetRangeValue();

    /// <summary>
    /// Gets a value indicating whether the control is in a readonly state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsReadonly => this.IsRangeReadonly();

    /// <summary>
    /// Gets the element associated with the increase button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button Increase => FindElement(WindowsByExtras.AutomationId("PART_IncreaseButton"));

    /// <summary>
    /// Gets the element associated with the decrease button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button DecreaseButton => FindElement(WindowsByExtras.AutomationId("PART_DecreaseButton"));

    /// <summary>
    /// Gets the element associated with the input text box.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextBox InputBox => FindElement(WindowsByExtras.AutomationId("PART_TextBox"));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="RadNumericBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="RadNumericBox"/>.
    /// </returns>
    public static implicit operator RadNumericBox(WebElement element)
    {
        return new RadNumericBox(element);
    }
    
    /// <summary>
    /// Sets the value of the RadNumericBox.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the value is out of the minimum and maximum range of the RadNumericBox.
    /// </exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
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

        InputBox.SetText(value.ToString());
        InputBox.Element.SendKeys(Keys.Enter);
    }

    /// <summary>
    /// Increases the number box value by the <see cref="SmallChange"/> value.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Increment()
    {
        Increase.Click();
    }

    /// <summary>
    /// Decreases the number box value by the <see cref="SmallChange"/> value.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Decrement()
    {
        DecreaseButton.Click();
    }
}