namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the UWP MenuFlyoutItem control.
    /// </summary>
    public class MenuFlyoutItem : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuFlyoutItem"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public MenuFlyoutItem(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Clicks the item.
        /// </summary>
        public void Click()
        {
            this.Element.Click();
        }
    }
}