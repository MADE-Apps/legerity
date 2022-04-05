namespace Legerity.IOS.Elements.Core
{
    using System;
    using Legerity.IOS.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.iOS;

    /// <summary>
    /// Defines a <see cref="IOSElement"/> wrapper for the core iOS Slider control.
    /// </summary>
    public class Slider : IOSElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Slider"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IOSElement"/> reference.
        /// </param>
        public Slider(IOSElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the value of the slider as a percentage between 0 and 100.
        /// </summary>
        public double Value => double.Parse(this.Element.GetValue().TrimEnd('%'));

        /// <summary>
        /// Gets a value indicating whether the control is in a readonly state.
        /// </summary>
        public bool IsReadonly => !this.IsEnabled;

        /// <summary>
        /// Allows conversion of a <see cref="IOSElement"/> to the <see cref="Slider"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IOSElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Slider"/>.
        /// </returns>
        public static implicit operator Slider(IOSElement element)
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
            return new Slider(element as IOSElement);
        }

        /// <summary>
        /// Sets the value of the slider.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetValue(double value)
        {
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