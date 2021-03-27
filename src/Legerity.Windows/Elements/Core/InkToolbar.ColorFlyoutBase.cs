namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Linq;

    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    public partial class InkToolbar
    {
        /// <summary>
        /// Defines a base for a color flyout in the <see cref="InkToolbar"/>.
        /// </summary>
        private abstract class InkToolbarColorFlyoutBase : WindowsElementWrapper
        {
            private readonly By colorGridViewQuery = ByExtensions.AutomationId("PenColorPalette");

            private readonly By sizeSliderQuery = ByExtensions.AutomationId("PenStrokeWidthSlider");
            
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
            public GridView ColorGridView => this.Driver.FindElement(this.colorGridViewQuery);

            /// <summary>
            /// Gets the element associated with the size of the ink.
            /// </summary>
            public Slider SizeSlider => this.Driver.FindElement(this.sizeSliderQuery);

            /// <summary>
            /// Gets the currently selected color.
            /// </summary>
            public string SelectedColor => this.GetSelectedColor().GetAttribute("Name");

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
                this.VerifyElementShown(this.colorGridViewQuery, TimeSpan.FromSeconds(2));

                return this.ColorGridView.Items.FirstOrDefault(
                    i => i.GetAttribute("SelectionItem.IsSelected").Equals(
                        "True",
                        StringComparison.CurrentCultureIgnoreCase));
            }
        }
    }
}