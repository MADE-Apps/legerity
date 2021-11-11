namespace Legerity.Windows.Elements.MADE
{
    using Legerity.Exceptions;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the MADE.NET UWP DropDownList control.
    /// </summary>
    public class DropDownList : WindowsElementWrapper
    {
        private readonly By dropDownContentQuery = ByExtensions.AutomationId("DropDownContent");

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownList"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public DropDownList(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the <see cref="ListView"/> element associated with the drop down content.
        /// </summary>
        public ListView DropDown => this.Element.FindElement(this.dropDownContentQuery);

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="DropDownList"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="DropDownList"/>.
        /// </returns>
        public static implicit operator DropDownList(WindowsElement element)
        {
            return new DropDownList(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="DropDownList"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="DropDownList"/>.
        /// </returns>
        public static implicit operator DropDownList(AppiumWebElement element)
        {
            return new DropDownList(element as WindowsElement);
        }

        /// <summary>
        /// Selects an item in the combo-box with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to select.
        /// </param>
        public void SelectItem(string name)
        {
            if (!this.IsDropDownOpen())
            {
                this.Element.Click();
            }

            this.DropDown.ClickItem(name);
        }

        /// <summary>
        /// Determines whether the drop down is open.
        /// </summary>
        /// <returns>True if the drop down is open; otherwise, false.</returns>
        public bool IsDropDownOpen()
        {
            bool isVisible;

            try
            {
                isVisible = this.DropDown.IsVisible;
            }
            catch (WebDriverException wde) when (wde.Message.Contains("element could not be located"))
            {
                isVisible = false;
            }
            catch (ElementNotShownException)
            {
                isVisible = false;
            }

            return isVisible;
        }
    }
}