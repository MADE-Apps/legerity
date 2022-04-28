namespace Legerity.Windows.Elements.Core
{
    using System;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP Slider control.
    /// </summary>
    public class Slider : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Slider"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public Slider(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the minimum value of the slider.
        /// </summary>
        public virtual double Minimum => this.GetRangeMinimum();

        /// <summary>
        /// Gets the maximum value of the slider.
        /// </summary>
        public virtual double Maximum => this.GetRangeMaximum();

        /// <summary>
        /// Gets the small change (step) value of the slider.
        /// </summary>
        public virtual double SmallChange => this.GetRangeSmallChange();

        /// <summary>
        /// Gets the value of the slider.
        /// </summary>
        public virtual double Value => this.GetRangeValue();

        /// <summary>
        /// Gets a value indicating whether the control is in a readonly state.
        /// </summary>
        public virtual bool IsReadonly => this.IsRangeReadonly();

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="Slider"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Slider"/>.
        /// </returns>
        public static implicit operator Slider(WindowsElement element)
        {
            return new Slider(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Slider"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Slider"/>.
        /// </returns>
        public static implicit operator Slider(AppiumWebElement element)
        {
            return new Slider(element as WindowsElement);
        }

        /// <summary>
        /// Sets the value of the slider.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the value is out of the minimum and maximum range of the slider.
        /// </exception>
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

            this.Click();

            double currentValue = this.Value;
            while (Math.Abs(currentValue - value) > double.Epsilon)
            {
                this.Element.SendKeys(currentValue < value ? Keys.ArrowRight : Keys.ArrowLeft);
                currentValue = this.Value;
            }
        }
    }
}