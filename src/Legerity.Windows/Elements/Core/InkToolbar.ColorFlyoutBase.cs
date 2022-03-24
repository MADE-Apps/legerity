namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Linq;
    using Legerity.Extensions;
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
        private abstract class InkToolbarColorFlyoutBase : WindowsElementWrapper
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
            public GridView ColorGridView => this.Driver.FindElement(this.penColorPaletteLocator);

            /// <summary>
            /// Gets the element associated with the size of the ink.
            /// </summary>
            public Slider SizeSlider => this.Driver.FindElement(WindowsByExtras.AutomationId("PenStrokeWidthSlider"));

            /// <summary>
            /// Gets the currently selected color.
            /// </summary>
            public string SelectedColor => this.GetSelectedColor().GetName();

            /// <summary>
            /// Gets the currently selected size.
            /// </summary>
            public double SelectedSize => this.SizeSlider.Value;

            /// <summary>
            /// Sets the color of the ink.
            /// </summary>
            /// <param name="color">The color to select.</param>
            public void SetColor(string color)
            {
                this.ColorGridView.ClickItem(color);
            }

            private AppiumWebElement GetSelectedColor()
            {
                this.VerifyElementShown(this.penColorPaletteLocator, TimeSpan.FromSeconds(2));

                return this.ColorGridView.Items.FirstOrDefault(
                    i => i.GetAttribute("SelectionItem.IsSelected").Equals(
                        "True",
                        StringComparison.CurrentCultureIgnoreCase));
            }
        }
    }
}