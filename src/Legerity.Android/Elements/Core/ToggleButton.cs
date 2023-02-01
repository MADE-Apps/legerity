namespace Legerity.Android.Elements.Core
{
    using System;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android ToggleButton control.
    /// </summary>
    public class ToggleButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleButton"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/> reference.
        /// </param>
        public ToggleButton(AndroidElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the toggle button is in the on position.
        /// </summary>
        public virtual bool IsOn => this.GetAttribute("Checked").Equals("True", StringComparison.CurrentCultureIgnoreCase);

        /// <summary>
        /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="ToggleButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ToggleButton"/>.
        /// </returns>
        public static implicit operator ToggleButton(AndroidElement element)
        {
            return new ToggleButton(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ToggleButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ToggleButton"/>.
        /// </returns>
        public static implicit operator ToggleButton(AppiumWebElement element)
        {
            return new ToggleButton(element as AndroidElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ToggleButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ToggleButton"/>.
        /// </returns>
        public static implicit operator ToggleButton(RemoteWebElement element)
        {
            return new ToggleButton(element as AndroidElement);
        }

        /// <summary>
        /// Toggles the button on.
        /// </summary>
        public virtual void ToggleOn()
        {
            if (this.IsOn)
            {
                return;
            }

            this.Click();
        }

        /// <summary>
        /// Toggles the button off.
        /// </summary>
        public virtual void ToggleOff()
        {
            if (!this.IsOn)
            {
                return;
            }

            this.Click();
        }
    }
}