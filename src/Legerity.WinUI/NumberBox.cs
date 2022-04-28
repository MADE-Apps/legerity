namespace Legerity.Windows.Elements.WinUI
{
    using System;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the WinUI NumberBox control.
    /// </summary>
    public class NumberBox : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public NumberBox(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the minimum value of the NumberBox.
        /// </summary>
        public virtual double Minimum => this.GetRangeMinimum();

        /// <summary>
        /// Gets the maximum value of the NumberBox.
        /// </summary>
        public virtual double Maximum => this.GetRangeMaximum();

        /// <summary>
        /// Gets the small change (step) value of the NumberBox.
        /// </summary>
        public virtual double SmallChange => this.GetRangeSmallChange();

        /// <summary>
        /// Gets the value of the NumberBox.
        /// </summary>
        public virtual double Value => this.GetRangeValue();

        /// <summary>
        /// Gets a value indicating whether the control is in a readonly state.
        /// </summary>
        public virtual bool IsReadonly => this.IsRangeReadonly();

        /// <summary>
        /// Gets the element associated with the inline up button.
        /// </summary>
        public virtual Button InlineUpButton => this.Element.FindElement(WindowsByExtras.AutomationId("UpSpinButton"));

        /// <summary>
        /// Gets the element associated with the inline down button.
        /// </summary>
        public virtual Button InlineDownButton =>
            this.Element.FindElement(WindowsByExtras.AutomationId("DownSpinButton"));

        /// <summary>
        /// Gets the element associated with the input text box.
        /// </summary>
        public virtual TextBox InputBox => this.Element.FindElement(WindowsByExtras.AutomationId("InputBox"));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="NumberBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="NumberBox"/>.
        /// </returns>
        public static implicit operator NumberBox(WindowsElement element)
        {
            return new NumberBox(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="NumberBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="NumberBox"/>.
        /// </returns>
        public static implicit operator NumberBox(AppiumWebElement element)
        {
            return new NumberBox(element as WindowsElement);
        }

        /// <summary>
        /// Sets the value of the NumberBox.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the value is out of the minimum and maximum range of the NumberBox.
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

            this.InputBox.SetText(value.ToString());
            this.InputBox.Element.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Increases the number box value by the <see cref="SmallChange"/> value.
        /// </summary>
        public virtual void Increment()
        {
            this.Element.SendKeys(Keys.ArrowUp);
        }

        /// <summary>
        /// Decreases the number box value by the <see cref="SmallChange"/> value.
        /// </summary>
        public virtual void Decrement()
        {
            this.Element.SendKeys(Keys.ArrowDown);
        }
    }
}