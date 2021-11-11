namespace Legerity.Windows.Elements.WCT
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit Carousel control.
    /// </summary>
    public class Carousel : WindowsElementWrapper
    {
        private readonly By carouselItemQuery = By.ClassName("CarouselItem");

        /// <summary>
        /// Initializes a new instance of the <see cref="Carousel"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public Carousel(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the collection of items associated with the carousel.
        /// </summary>
        public ReadOnlyCollection<AppiumWebElement> Items => this.Element.FindElements(this.carouselItemQuery);

        /// <summary>
        /// Gets the element associated with the currently selected item.
        /// </summary>
        public AppiumWebElement SelectedItem =>
            this.Items.FirstOrDefault(
                i => i.GetAttribute("SelectionItem.IsSelected").Equals(
                    "True",
                    StringComparison.CurrentCultureIgnoreCase));

        /// <summary>
        /// Gets the index of the element associated with the currently selected item.
        /// </summary>
        public int SelectedIndex => this.Items.IndexOf(this.SelectedItem);

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="ListView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ListView"/>.
        /// </returns>
        public static implicit operator Carousel(WindowsElement element)
        {
            return new Carousel(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ListView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ListView"/>.
        /// </returns>
        public static implicit operator Carousel(AppiumWebElement element)
        {
            return new Carousel(element as WindowsElement);
        }

        /// <summary>
        /// Clicks on an item in the carousel with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to click.
        /// </param>
        public void SelectItem(string name)
        {
            this.VerifyElementsShown(this.carouselItemQuery, TimeSpan.FromSeconds(2));

            int index = this.Items.IndexOf(this.Items.FirstOrDefault(element => element.VerifyNameOrAutomationIdEquals(name)));
            int selectedIndex = this.SelectedIndex;
            while (Math.Abs(index - selectedIndex) > double.Epsilon)
            {
                this.Element.SendKeys(selectedIndex < index ? Keys.ArrowRight : Keys.ArrowLeft);
                selectedIndex = this.SelectedIndex;
            }
        }

        /// <summary>
        /// Clicks on an item in the carousel with the specified item name.
        /// </summary>
        /// <param name="index">
        /// The index of the item to click.
        /// </param>
        /// <exception cref="T:System.IndexOutOfRangeException">Cannot select an element that is outside the range of items available.</exception>
        public void SelectItem(int index)
        {
            if (index > this.Items.Count - 1)
            {
                throw new IndexOutOfRangeException(
                    "Cannot select an element that is outside the range of items available.");
            }

            this.VerifyElementsShown(this.carouselItemQuery, TimeSpan.FromSeconds(2));

            int selectedIndex = this.SelectedIndex;
            while (Math.Abs(index - selectedIndex) > double.Epsilon)
            {
                this.Element.SendKeys(selectedIndex < index ? Keys.ArrowRight : Keys.ArrowLeft);
                selectedIndex = this.SelectedIndex;
            }
        }
    }
}
