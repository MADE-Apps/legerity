namespace Legerity.Windows.Elements.WCT
{
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit Expander control.
    /// </summary>
    public class Expander : WindowsElementWrapper
    {
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
        public virtual bool IsExpanded => this.GetToggleState() == ToggleState.Checked;

        /// <summary>
        /// Gets the <see cref="ToggleButton"/> associated with the expander.
        /// </summary>
        public virtual ToggleButton ToggleButton => this.Element.FindElement(WindowsByExtras.AutomationId("PART_ExpanderToggleButton"));

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
        public virtual void Expand()
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
        public virtual void Collapse()
        {
            if (!this.IsExpanded)
            {
                return;
            }

            this.ToggleButton.Click();
        }
    }
}
