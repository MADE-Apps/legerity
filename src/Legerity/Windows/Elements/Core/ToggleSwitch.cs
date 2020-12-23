namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP ToggleSwitch control.
    /// </summary>
    public class ToggleSwitch : WindowsElementWrapper
    {
        private const string ToggleOnValue = "1";

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleSwitch"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public ToggleSwitch(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the toggle switch is in the on position.
        /// </summary>
        public bool IsOn => this.Element.GetAttribute("Toggle.ToggleState") == ToggleOnValue;

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="ToggleSwitch"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ToggleSwitch"/>.
        /// </returns>
        public static implicit operator ToggleSwitch(WindowsElement element)
        {
            return new ToggleSwitch(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ToggleSwitch"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ToggleSwitch"/>.
        /// </returns>
        public static implicit operator ToggleSwitch(AppiumWebElement element)
        {
            return new ToggleSwitch(element as WindowsElement);
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