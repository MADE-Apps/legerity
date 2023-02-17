namespace Legerity.Windows.Elements.Core;

using System;
using System.Linq;
using Legerity.Exceptions;
using Legerity.Extensions;
using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

/// <summary>
/// Defines the color flyout components of the <see cref="InkToolbar"/>.
/// </summary>
public partial class InkToolbar
{
    /// <summary>
    /// Defines a base for a color flyout in the <see cref="InkToolbar"/>.
    /// </summary>
    public abstract class InkToolbarColorFlyoutBase : WindowsElementWrapper
    {
        private readonly By penColorPaletteLocator = WindowsByExtras.AutomationId("PenColorPalette");

        /// <summary>
        /// Initializes a new instance of the <see cref="InkToolbarColorFlyoutBase"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        protected InkToolbarColorFlyoutBase(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the color grid.
        /// </summary>
        /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
        public virtual GridView ColorGridView => this.Driver.FindElement(this.penColorPaletteLocator);

        /// <summary>
        /// Gets the element associated with the size of the ink.
        /// </summary>
        /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
        public virtual Slider SizeSlider =>
            this.Driver.FindElement(WindowsByExtras.AutomationId("PenStrokeWidthSlider"));

        /// <summary>
        /// Gets the currently selected color.
        /// </summary>
        /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
        /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
        /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
        public virtual string SelectedColor => this.GetSelectedColor().GetName();

        /// <summary>
        /// Gets the currently selected size.
        /// </summary>
        public virtual double SelectedSize => this.SizeSlider.Value;

        /// <summary>
        /// Sets the color of the ink.
        /// </summary>
        /// <param name="color">The color to select.</param>
        /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
        /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
        /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
        /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
        /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
        public virtual void SetColor(string color)
        {
            this.ColorGridView.ClickItem(color);
        }

        /// <summary>
        /// Sets the color of the ink by partial color name match.
        /// </summary>
        /// <param name="partialColor">The partial color name to select.</param>
        /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
        /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
        /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
        /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
        /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
        public virtual void SetColorByPartialName(string partialColor)
        {
            this.ColorGridView.ClickItemByPartialName(partialColor);
        }

        /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
        /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
        /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
        private AppiumWebElement GetSelectedColor()
        {
            this.VerifyElementShown(this.penColorPaletteLocator, TimeSpan.FromSeconds(2));

            return this.ColorGridView.Items.FirstOrDefault(i => i.IsSelected());
        }
    }
}