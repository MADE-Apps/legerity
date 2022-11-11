namespace Legerity.Windows.Elements.Core
{
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP AppBarToggleButton control.
    /// </summary>
    public class AppBarToggleButton : AppBarButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppBarToggleButton"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public AppBarToggleButton(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the toggle button is in the on position.
        /// </summary>
        public virtual bool IsOn => this.GetToggleState() == ToggleState.Checked;

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="AppBarToggleButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AppBarToggleButton"/>.
        /// </returns>
        public static implicit operator AppBarToggleButton(WindowsElement element)
        {
            return new AppBarToggleButton(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="AppBarToggleButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AppBarToggleButton"/>.
        /// </returns>
        public static implicit operator AppBarToggleButton(AppiumWebElement element)
        {
            return new AppBarToggleButton(element as WindowsElement);
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