namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP CheckBox control.
    /// </summary>
    public class CheckBox : WindowsElementWrapper
    {
        private const string CheckedValue = "1";

        private const string IndeterminateValue = "2";

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public CheckBox(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the check box is in the checked state.
        /// </summary>
        public bool IsChecked => this.Element.GetAttribute("Toggle.ToggleState") == CheckedValue;

        /// <summary>
        /// Gets a value indicating whether the check box is in the indeterminate state.
        /// </summary>
        public bool IsIndeterminate => this.Element.GetAttribute("Toggle.ToggleState") == IndeterminateValue;

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="CheckBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CheckBox"/>.
        /// </returns>
        public static implicit operator CheckBox(WindowsElement element)
        {
            return new CheckBox(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="CheckBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CheckBox"/>.
        /// </returns>
        public static implicit operator CheckBox(AppiumWebElement element)
        {
            return new CheckBox(element as WindowsElement);
        }

        /// <summary>
        /// Checks the check box on.
        /// </summary>
        public void CheckOn()
        {
            if (this.IsChecked)
            {
                return;
            }

            this.Element.Click();
        }

        /// <summary>
        /// Checks the check box off.
        /// </summary>
        public void CheckOff()
        {
            if (!this.IsChecked)
            {
                return;
            }

            this.Element.Click();
        }
    }
}