namespace Legerity.Windows.Elements.WCT
{
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit Expander control.
    /// </summary>
    public class Expander : WindowsElementWrapper
    {
        private const string ToggleOnValue = "1";

        private readonly By toggleButtonQuery = ByExtensions.AutomationId("PART_ExpanderToggleButton");

        /// <summary>
        /// Initializes a new instance of the <see cref="Expander"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public Expander(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the expander has the content expanded (visible).
        /// </summary>
        public bool IsExpanded => this.Element.GetAttribute("Toggle.ToggleState") == ToggleOnValue;

        private ToggleButton ToggleButton => this.Element.FindElement(this.toggleButtonQuery);

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="Expander"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Expander"/>.
        /// </returns>
        public static implicit operator Expander(WindowsElement element)
        {
            return new Expander(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Expander"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Expander"/>.
        /// </returns>
        public static implicit operator Expander(AppiumWebElement element)
        {
            return new Expander(element as WindowsElement);
        }

        /// <summary>
        /// Expands the content of the expander.
        /// </summary>
        public void Expand()
        {
            if (this.IsExpanded)
            {
                return;
            }

            this.ToggleButton.Click();
        }

        /// <summary>
        /// Collapses the content of the expander.
        /// </summary>
        public void Collapse()
        {
            if (!this.IsExpanded)
            {
                return;
            }

            this.ToggleButton.Click();
        }
    }
}
