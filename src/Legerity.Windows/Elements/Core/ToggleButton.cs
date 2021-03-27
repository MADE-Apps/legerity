namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP ToggleButton control.
    /// </summary>
    public class ToggleButton : Button
    {
        private const string ToggleOnValue = "1";

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleButton"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public ToggleButton(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the toggle button is in the on position.
        /// </summary>
        public bool IsOn => this.Element.GetAttribute("Toggle.ToggleState") == ToggleOnValue;

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="ToggleButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ToggleButton"/>.
        /// </returns>
        public static implicit operator ToggleButton(WindowsElement element)
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
            return new ToggleButton(element as WindowsElement);
        }

        /// <summary>
        /// Toggles the button on.
        /// </summary>
        public void ToggleOn()
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
        public void ToggleOff()
        {
            if (!this.IsOn)
            {
                return;
            }

            this.Click();
        }
    }
}