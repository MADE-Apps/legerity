namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines the pencil flyout components of the <see cref="InkToolbar"/>.
    /// </summary>
    public partial class InkToolbar
    {
        /// <summary>
        /// Defines a color flyout for the pencil in the <see cref="InkToolbar"/>.
        /// </summary>
        public class InkToolbarPencilFlyout : InkToolbarColorFlyoutBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Legerity.Windows.Elements.Core.InkToolbar.InkToolbarPencilFlyout"/> class.
            /// </summary>
            /// <param name="element">
            /// The <see cref="WindowsElement"/> reference.
            /// </param>
            public InkToolbarPencilFlyout(WindowsElement element)
                : base(element)
            {
            }

            /// <summary>
            /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="InkToolbarPencilFlyout"/> without direct casting.
            /// </summary>
            /// <param name="element">
            /// The <see cref="WindowsElement"/>.
            /// </param>
            /// <returns>
            /// The <see cref="InkToolbarPencilFlyout"/>.
            /// </returns>
            public static implicit operator InkToolbarPencilFlyout(WindowsElement element)
            {
                return new InkToolbarPencilFlyout(element);
            }

            /// <summary>
            /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="InkToolbarPencilFlyout"/> without direct casting.
            /// </summary>
            /// <param name="element">
            /// The <see cref="AppiumWebElement"/>.
            /// </param>
            /// <returns>
            /// The <see cref="InkToolbarPencilFlyout"/>.
            /// </returns>
            public static implicit operator InkToolbarPencilFlyout(AppiumWebElement element)
            {
                return new InkToolbarPencilFlyout(element as WindowsElement);
            }

            /// <summary>
            /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="InkToolbarPencilFlyout"/> without direct casting.
            /// </summary>
            /// <param name="element">
            /// The <see cref="RemoteWebElement"/>.
            /// </param>
            /// <returns>
            /// The <see cref="InkToolbarPencilFlyout"/>.
            /// </returns>
            public static implicit operator InkToolbarPencilFlyout(RemoteWebElement element)
            {
                return new InkToolbarPencilFlyout(element as WindowsElement);
            }
        }
    }
}