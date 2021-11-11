namespace Legerity.Windows.Elements.WCT
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit RadialGauge control.
    /// </summary>
    public class RadialGauge : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadialGauge"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public RadialGauge(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the minimum value of the gauge.
        /// </summary>
        public double Minimum => double.Parse(this.Element.GetAttribute("RangeValue.Minimum"));

        /// <summary>
        /// Gets the maximum value of the gauge.
        /// </summary>
        public double Maximum => double.Parse(this.Element.GetAttribute("RangeValue.Maximum"));

        /// <summary>
        /// Gets the small change (step) value of the gauge.
        /// </summary>
        public double SmallChange => double.Parse(this.Element.GetAttribute("RangeValue.SmallChange"));

        /// <summary>
        /// Gets the value of the gauge.
        /// </summary>
        public double Value => double.Parse(this.Element.GetAttribute("RangeValue.Value"));

        /// <summary>
        /// Gets a value indicating whether the control is in a readonly state.
        /// </summary>
        public bool IsReadonly => bool.Parse(this.Element.GetAttribute("RangeValue.IsReadOnly"));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="RadialGauge"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadialGauge"/>.
        /// </returns>
        public static implicit operator RadialGauge(WindowsElement element)
        {
            return new RadialGauge(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="RadialGauge"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadialGauge"/>.
        /// </returns>
        public static implicit operator RadialGauge(AppiumWebElement element)
        {
            return new RadialGauge(element as WindowsElement);
        }

        /// <summary>
        /// Sets the value of the gauge.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the value is out of the minimum and maximum range of the gauge.
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
