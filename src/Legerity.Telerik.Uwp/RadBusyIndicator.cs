namespace Legerity.Windows.Elements.Telerik
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Telerik UWP RadBusyIndicator control.
    /// </summary>
    public class RadBusyIndicator : WindowsElementWrapper
    {
        private const string OnValue = "On";

        /// <summary>
        /// Initializes a new instance of the <see cref="RadBusyIndicator"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public RadBusyIndicator(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the busy indicator is on.
        /// </summary>
        public virtual bool IsOn => this.GetAttribute("ItemStatus") == OnValue;

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="RadBusyIndicator"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadBusyIndicator"/>.
        /// </returns>
        public static implicit operator RadBusyIndicator(WindowsElement element)
        {
            return new RadBusyIndicator(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="RadBusyIndicator"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadBusyIndicator"/>.
        /// </returns>
        public static implicit operator RadBusyIndicator(AppiumWebElement element)
        {
            return new RadBusyIndicator(element as WindowsElement);
        }
    }
}