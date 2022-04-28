namespace Legerity.Web.Elements.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Legerity.Extensions;
    using Legerity.Web.Elements;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="IWebElement"/> wrapper for the core web Select control.
    /// </summary>
    public class Select : WebElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Select"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public Select(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Select"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public Select(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether multiple items can be selected.
        /// </summary>
        public virtual bool IsMultiple => this.GetIsMultiple();

        /// <summary>
        /// Gets the collection of items associated with the select.
        /// </summary>
        public virtual IEnumerable<Option> Options =>
            this.Element.FindElements(WebByExtras.Option()).Select(e => new Option(e));

        /// <summary>
        /// Gets the selected item when in a single selection state.
        /// </summary>
        public virtual Option SelectedOption => this.Options.FirstOrDefault(e => e.IsSelected);

        /// <summary>
        /// Gets the selected items when in a multiple selection state.
        /// </summary>
        public virtual IEnumerable<Option> SelectedOptions => this.Options.Where(e => e.IsSelected);

        /// <summary>
        /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="Select"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Select"/>.
        /// </returns>
        public static implicit operator Select(RemoteWebElement element)
        {
            return new Select(element);
        }

        /// <summary>
        /// Selects an item in the select element with the specified display value.
        /// </summary>
        /// <param name="displayValue">
        /// The display value of the item to select.
        /// </param>
        public virtual void SelectOptionByDisplayValue(string displayValue)
        {
            Option item =
                this.Options.FirstOrDefault(e =>
                    e.DisplayValue.Equals(displayValue, StringComparison.CurrentCultureIgnoreCase));
            item.Select();
        }

        /// <summary>
        /// Selects an item in the select element with the specified partial display value.
        /// </summary>
        /// <param name="partialDisplayValue">
        /// The partial display value of the item to select.
        /// </param>
        public virtual void SelectOptionByPartialDisplayValue(string partialDisplayValue)
        {
            Option item =
                this.Options.FirstOrDefault(e =>
                    e.DisplayValue.Contains(
                        partialDisplayValue,
                        CultureInfo.CurrentCulture,
                        CompareOptions.IgnoreCase));
            item.Select();
        }

        /// <summary>
        /// Selects an item in the select element with the specified value.
        /// </summary>
        /// <param name="value">
        /// The value of the item to select.
        /// </param>
        public virtual void SelectOptionByValue(string value)
        {
            Option item =
                this.Options.FirstOrDefault(e =>
                    e.Value.Equals(value, StringComparison.CurrentCultureIgnoreCase));
            item.Select();
        }

        /// <summary>
        /// Selects an item in the select element with the specified partial value.
        /// </summary>
        /// <param name="partialValue">
        /// The partial value of the item to select.
        /// </param>
        public virtual void SelectOptionByPartialValue(string partialValue)
        {
            Option item =
                this.Options.FirstOrDefault(e =>
                    e.Value.Contains(
                        partialValue,
                        CultureInfo.CurrentCulture,
                        CompareOptions.IgnoreCase));
            item.Select();
        }

        private bool GetIsMultiple()
        {
            string multipleAttr = this.GetAttribute("multiple");
            if (multipleAttr == null)
            {
                return false;
            }

            return bool.TryParse(multipleAttr, out bool isMultiple) && isMultiple;
        }
    }
}