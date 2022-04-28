namespace Legerity.Windows.Elements.WCT
{
    using System.Collections.Generic;
    using System.Linq;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit BladeView control.
    /// </summary>
    public class BladeView : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BladeView"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public BladeView(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the UI components associated with the child blades.
        /// </summary>
        public virtual IEnumerable<BladeViewItem> Blades =>
            this.Element.FindElements(By.ClassName("BladeItem"))
                .Select(element => new BladeViewItem(this, element as WindowsElement));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="BladeView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="BladeView"/>.
        /// </returns>
        public static implicit operator BladeView(WindowsElement element)
        {
            return new BladeView(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="BladeView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="BladeView"/>.
        /// </returns>
        public static implicit operator BladeView(AppiumWebElement element)
        {
            return new BladeView(element as WindowsElement);
        }

        /// <summary>
        /// Retrieves a <see cref="BladeViewItem"/> by the given name.
        /// </summary>
        /// <param name="name">The name of the blade to retrieve.</param>
        /// <returns>A <see cref="BladeViewItem"/> instance if found; otherwise, null.</returns>
        public virtual BladeViewItem GetBlade(string name)
        {
            return this.Blades.FirstOrDefault(element => element.Element.VerifyNameOrAutomationIdEquals(name));
        }

        /// <summary>
        /// Retrieves a <see cref="BladeViewItem"/> by the given partial name.
        /// </summary>
        /// <param name="partialName">The partial name of the blade to retrieve.</param>
        /// <returns>A <see cref="BladeViewItem"/> instance if found; otherwise, null.</returns>
        public virtual BladeViewItem GetBladeByPartialName(string partialName)
        {
            return this.Blades.FirstOrDefault(element => element.Element.VerifyNameOrAutomationIdContains(partialName));
        }

        /// <summary>
        /// Closes an open blade by name.
        /// </summary>
        /// <param name="name">The name of the blade to close.</param>
        public virtual void CloseBlade(string name)
        {
            BladeViewItem blade = this.GetBlade(name);
            blade.Close();
        }

        /// <summary>
        /// Closes an open blade by partial name.
        /// </summary>
        /// <param name="partialName">The partial name of the blade to close.</param>
        public virtual void CloseBladeByPartialName(string partialName)
        {
            BladeViewItem blade = this.GetBladeByPartialName(partialName);
            blade.Close();
        }
    }
}