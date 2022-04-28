namespace Legerity.Android.Elements.Core
{
    using System;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android RadioButton control.
    /// </summary>
    public class RadioButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadioButton"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/> reference.
        /// </param>
        public RadioButton(AndroidElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the radio button is selected.
        /// </summary>
        public virtual bool IsSelected =>
            this.GetAttribute("Checked").Equals("True", StringComparison.CurrentCultureIgnoreCase);

        /// <summary>
        /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="RadioButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadioButton"/>.
        /// </returns>
        public static implicit operator RadioButton(AndroidElement element)
        {
            return new RadioButton(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="RadioButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadioButton"/>.
        /// </returns>
        public static implicit operator RadioButton(AppiumWebElement element)
        {
            return new RadioButton(element as AndroidElement);
        }
    }
}