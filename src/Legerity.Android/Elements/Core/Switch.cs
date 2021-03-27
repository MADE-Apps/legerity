namespace Legerity.Android.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android Switch control.
    /// </summary>
    public class Switch : AndroidElementWrapper
    {
        private const string ToggleOnValue = "true";

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
        public bool IsOn => this.Element.GetAttribute("Checked") == ToggleOnValue;

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
        /// Toggles the switch on.
        /// </summary>
        public void ToggleOn()
        {
            if (this.IsOn)
            {
                return;
            }

            this.Element.Click();
        }

        /// <summary>
        /// Toggles the switch off.
        /// </summary>
        public void ToggleOff()
        {
            if (!this.IsOn)
            {
                return;
            }

            this.Element.Click();
        }
    }
}