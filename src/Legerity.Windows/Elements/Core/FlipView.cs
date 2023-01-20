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
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP FlipView control.
    /// </summary>
    public class FlipView : WindowsElementWrapper
    {
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
        public virtual ReadOnlyCollection<AppiumWebElement> Items => this.Element.FindElements(By.ClassName("FlipViewItem"));

        /// <summary>
        /// Gets the element associated with the next item button.
        /// </summary>
        public virtual Button NextButton => this.Element.FindElement(WindowsByExtras.AutomationId("NextButtonHorizontal"));

        /// <summary>
        /// Gets the element associated with the previous item button.
        /// </summary>
        public virtual Button PreviousButton => this.Element.FindElement(WindowsByExtras.AutomationId("PreviousButtonHorizontal"));

        /// <summary>
        /// Gets the currently selected item.
        /// </summary>
        public virtual AppiumWebElement SelectedItem => this.Items.FirstOrDefault(i => i.IsSelected());

        /// <summary>
        /// Gets the currently selected item index.
        /// </summary>
        public virtual int SelectedIndex => this.Items.IndexOf(this.SelectedItem);

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
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="FlipView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="FlipView"/>.
        /// </returns>
        public static implicit operator FlipView(RemoteWebElement element)
        {
            return new FlipView(element as WindowsElement);
        }

        /// <summary>
        /// Selects an item in the flip view by the specified name.
        /// </summary>
        /// <param name="name">
        /// The name of the item.
        /// </param>
        public virtual void SelectItem(string name)
        {
            int expectedItemIdx = this.Items.IndexOf(this.Items.FirstOrDefault(x =>
                x.Text.Contains(name, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase)));
            this.SelectItemByIndex(expectedItemIdx);
        }

        /// <summary>
        /// Selects an items in the flip view by index.
        /// </summary>
        /// <param name="index">The index of the item to select.</param>
        public virtual void SelectItemByIndex(int index)
        {
            int currentItemIdx = this.SelectedIndex;
            int diff = index - currentItemIdx;
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
        public virtual void SelectNext()
        {
            this.Click();
            this.Element.SendKeys(Keys.ArrowRight);
        }

        /// <summary>
        /// Selects the previous item in the flip view.
        /// </summary>
        public virtual void SelectPrevious()
        {
            this.Click();
            this.Element.SendKeys(Keys.ArrowLeft);
        }
    }
}