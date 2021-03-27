namespace Legerity.Windows.Elements.Core
{
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP Hub control.
    /// </summary>
    public class Hub : WindowsElementWrapper
    {
        private readonly By hubSectionItemQuery = By.ClassName("HubSection");

        /// <summary>
        /// Initializes a new instance of the <see cref="Hub"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public Hub(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the collection of items associated with the hub.
        /// </summary>
        public ReadOnlyCollection<AppiumWebElement> Items => this.Element.FindElements(this.hubSectionItemQuery);
        
        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="Hub"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Hub"/>.
        /// </returns>
        public static implicit operator Hub(WindowsElement element)
        {
            return new Hub(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Hub"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Hub"/>.
        /// </returns>
        public static implicit operator Hub(AppiumWebElement element)
        {
            return new Hub(element as WindowsElement);
        }
    }
}