namespace Legerity.Web.Elements.Core;

using System;
using Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Input number control.
/// </summary>
public class NumberInput : TextInput
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NumberInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public NumberInput(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public NumberInput(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the minimum value of the NumberBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Minimum => this.GetMinimum();

    /// <summary>
    /// Gets the maximum value of the NumberBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Maximum => this.GetMaximum();

    /// <summary>
    /// Gets the value of the NumberBox.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => double.TryParse(this.Text, out double val) ? val : 0;

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="NumberInput"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="NumberInput"/>.
    /// </returns>
    public static implicit operator NumberInput(RemoteWebElement element)
    {
        return new NumberInput(element);
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
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void SetValue(double value)
    {
        double min = this.Minimum;
        double max = this.Maximum;

        if (value < this.Minimum)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                value,
                $"Value must be greater than or equal to the minimum value {min}");
        }

        if (value > this.Maximum)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                value,
                $"Value must be less than or equal to the maximum value {max}");
        }

        this.SetText(value.ToString());
    }

    /// <summary>
    /// Increases the number box value.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Increment()
    {
        this.Element.SendKeys(Keys.ArrowUp);
    }

    /// <summary>
    /// Decreases the number box value.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Decrement()
    {
        this.Element.SendKeys(Keys.ArrowDown);
    }
}