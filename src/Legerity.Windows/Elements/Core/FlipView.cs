namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using Legerity.Extensions;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP FlipView control.
    /// </summary>
    public class FlipView : WindowsElementWrapper
    {
        private readonly By flipViewItemQuery = By.ClassName("FlipViewItem");

        private readonly By nextButtonQuery = ByExtensions.AutomationId("NextButtonHorizontal");

        private readonly By previousButtonQuery = ByExtensions.AutomationId("PreviousButtonHorizontal");

        /// <summary>
        /// Initializes a new instance of the <see cref="FlipView"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public FlipView(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the collection of items associated with the flip view.
        /// </summary>
        public ReadOnlyCollection<AppiumWebElement> Items => this.Element.FindElements(this.flipViewItemQuery);

        /// <summary>
        /// Gets the element associated with the next item button.
        /// </summary>
        public Button NextButton => this.Element.FindElement(this.nextButtonQuery);

        /// <summary>
        /// Gets the element associated with the previous item button.
        /// </summary>
        public Button PreviousButton => this.Element.FindElement(this.previousButtonQuery);

        /// <summary>
        /// Gets the currently selected item.
        /// </summary>
        public AppiumWebElement SelectedItem =>
            this.Items.FirstOrDefault(
                i => i.GetAttribute("SelectionItem.IsSelected").Equals(
                    "True",
                    StringComparison.CurrentCultureIgnoreCase));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="FlipView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="FlipView"/>.
        /// </returns>
        public static implicit operator FlipView(WindowsElement element)
        {
            return new FlipView(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="FlipView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="FlipView"/>.
        /// </returns>
        public static implicit operator FlipView(AppiumWebElement element)
        {
            return new FlipView(element as WindowsElement);
        }

        /// <summary>
        /// Selects an item in the flip view by the specified name.
        /// </summary>
        /// <param name="name">
        /// The name of the item.
        /// </param>
        public void SelectItem(string name)
        {
            int currentItemIdx = this.Items.IndexOf(this.SelectedItem);
            int expectedItemIdx = this.Items.IndexOf(
                this.Items.FirstOrDefault(
                    x => x.Text.Contains(name, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase)));

            int diff = expectedItemIdx - currentItemIdx;
            int shifts = Math.Abs(diff);

            for (int i = 0; i < shifts; i++)
            {
                if (diff > 0)
                {
                    this.SelectNext();
                }
                else
                {
                    this.SelectPrevious();
                }
            }
        }

        /// <summary>
        /// Selects the next item in the flip view.
        /// </summary>
        public void SelectNext()
        {
            this.Element.Click();
            this.Element.SendKeys(Keys.ArrowRight);
        }

        /// <summary>
        /// Selects the previous item in the flip view.
        /// </summary>
        public void SelectPrevious()
        {
            this.Element.Click();
            this.Element.SendKeys(Keys.ArrowLeft);
        }
    }
}