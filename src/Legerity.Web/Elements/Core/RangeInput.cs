namespace Legerity.Web.Elements.Core
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

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
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RangeInput"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public RangeInput(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the minimum value of the range input.
        /// </summary>
        public double Minimum => double.Parse(this.Element.GetAttribute("min"));

        /// <summary>
        /// Gets the maximum value of the range input.
        /// </summary>
        public double Maximum => double.Parse(this.Element.GetAttribute("max"));

        /// <summary>
        /// Gets the value of the range input.
        /// </summary>
        public double Value => double.TryParse(this.Text, out double val) ? val : 0;

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="RangeInput"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RangeInput"/>.
        /// </returns>
        public static implicit operator RangeInput(RemoteWebElement element)
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
        /// Thrown if the value is out of the minimum and maximum range of the range input.
        /// </exception>
        public void SetValue(double value)
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

            this.Element.Click();

            double currentValue = this.Value;
            while (Math.Abs(currentValue - value) > double.Epsilon)
            {
                this.Element.SendKeys(currentValue < value ? Keys.ArrowRight : Keys.ArrowLeft);
                currentValue = this.Value;
            }
        }

        /// <summary>
        /// Increases the range input value.
        /// </summary>
        public void Increment()
        {
            this.Element.SendKeys(Keys.ArrowUp);
        }

        /// <summary>
        /// Decreases the range input value.
        /// </summary>
        public void Decrement()
        {
            this.Element.SendKeys(Keys.ArrowDown);
        }
    }
}