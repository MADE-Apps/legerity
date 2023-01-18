namespace Legerity.Android.Elements.Core
{
    using System;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android Switch control.
    /// </summary>
    public class Switch : AndroidElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Switch"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/> reference.
        /// </param>
        public Switch(AndroidElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the toggle switch is in the on position.
        /// </summary>
        public virtual bool IsOn => this.GetAttribute("Checked").Equals("True", StringComparison.CurrentCultureIgnoreCase);

        /// <summary>
        /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="Switch"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Switch"/>.
        /// </returns>
        public static implicit operator Switch(AndroidElement element)
        {
            return new Switch(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Switch"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Switch"/>.
        /// </returns>
        public static implicit operator Switch(AppiumWebElement element)
        {
            return new Switch(element as AndroidElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="Switch"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Switch"/>.
        /// </returns>
        public static implicit operator Switch(RemoteWebElement element)
        {
            return new Switch(element as AndroidElement);
        }

        /// <summary>
        /// Toggles the switch on.
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
        /// Toggles the switch off.
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