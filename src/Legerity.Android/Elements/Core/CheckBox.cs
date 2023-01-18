namespace Legerity.Android.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android CheckBox control.
    /// </summary>
    public class CheckBox : AndroidElementWrapper
    {
        private const string CheckedValue = "true";

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/> reference.
        /// </param>
        public CheckBox(AndroidElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the check box is in the checked state.
        /// </summary>
        public virtual bool IsChecked => this.GetAttribute("Checked") == CheckedValue;

        /// <summary>
        /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="CheckBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CheckBox"/>.
        /// </returns>
        public static implicit operator CheckBox(AndroidElement element)
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
            return new CheckBox(element as AndroidElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="CheckBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CheckBox"/>.
        /// </returns>
        public static implicit operator CheckBox(RemoteWebElement element)
        {
            return new CheckBox(element as AndroidElement);
        }

        /// <summary>
        /// Checks the check box on.
        /// </summary>
        public virtual void CheckOn()
        {
            if (this.IsChecked)
            {
                return;
            }

            this.Click();
        }

        /// <summary>
        /// Checks the check box off.
        /// </summary>
        public virtual void CheckOff()
        {
            if (!this.IsChecked)
            {
                return;
            }

            this.Click();
        }
    }
}