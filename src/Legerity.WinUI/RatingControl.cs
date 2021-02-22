namespace Legerity.Windows.Elements.WinUI
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the WinUI Rating control.
    /// </summary>
    public class RatingControl : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RatingControl"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public RatingControl(WindowsElement element)
            : base(element)
        {
        }
        
        /// <summary>
        /// Gets the value of the rating out of 5.
        /// </summary>
        public double Value => double.Parse(this.Element.GetAttribute("RangeValue.Value"));

        /// <summary>
        /// Gets a value indicating whether the control is in a readonly state.
        /// </summary>
        public bool IsReadonly => bool.Parse(this.Element.GetAttribute("RangeValue.IsReadOnly"));
        
        private double Minimum => double.Parse(this.Element.GetAttribute("RangeValue.Minimum"));
        
        private double Maximum => double.Parse(this.Element.GetAttribute("RangeValue.Maximum"));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="RatingControl"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RatingControl"/>.
        /// </returns>
        public static implicit operator RatingControl(WindowsElement element)
        {
            return new RatingControl(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="RatingControl"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RatingControl"/>.
        /// </returns>
        public static implicit operator RatingControl(AppiumWebElement element)
        {
            return new RatingControl(element as WindowsElement);
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
        public void SetValue(double value)
        {
            double min = this.Minimum;
            double max = this.Maximum;

            if (value < this.Minimum)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Value must be greater than or equal to the minimum value {min}");
            }

            if (value > this.Maximum)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Value must be less than or equal to the maximum value {max}");
            }

            this.Element.Click();

            double currentValue = this.Value;
            while (Math.Abs(currentValue - value) > double.Epsilon)
            {
                this.Element.SendKeys(currentValue < value ? Keys.ArrowRight : Keys.ArrowLeft);
                currentValue = this.Value;
            }
        }
    }
}