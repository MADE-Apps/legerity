namespace Legerity.Windows.Elements.WinUI;

using System;
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the WinUI NumberBox control.
/// </summary>
public class NumberBox : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NumberBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public NumberBox(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the minimum value of the NumberBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Minimum => this.GetRangeMinimum();

    /// <summary>
    /// Gets the maximum value of the NumberBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Maximum => this.GetRangeMaximum();

    /// <summary>
    /// Gets the small change (step) value of the NumberBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double SmallChange => this.GetRangeSmallChange();

    /// <summary>
    /// Gets the value of the NumberBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => this.GetRangeValue();

    /// <summary>
    /// Gets a value indicating whether the control is in a readonly state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsReadonly => this.IsRangeReadonly();

    /// <summary>
    /// Gets the element associated with the inline up button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button InlineUpButton => FindElement(WindowsByExtras.AutomationId("UpSpinButton"));

    /// <summary>
    /// Gets the element associated with the inline down button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button InlineDownButton =>
        FindElement(WindowsByExtras.AutomationId("DownSpinButton"));

    /// <summary>
    /// Gets the element associated with the input text box.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextBox InputBox => FindElement(WindowsByExtras.AutomationId("InputBox"));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="NumberBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="NumberBox"/>.
    /// </returns>
    public static implicit operator NumberBox(WebElement element)
    {
        return new NumberBox(element);
    }
    
    /// <summary>
    /// Sets the value of the NumberBox.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the value is out of the minimum and maximum range of the NumberBox.
    /// </exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
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
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void Increment()
    {
        Element.SendKeys(Keys.ArrowUp);
    }

    /// <summary>
    /// Decreases the number box value by the <see cref="SmallChange"/> value.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Decrement()
    {
        Element.SendKeys(Keys.ArrowDown);
    }
}