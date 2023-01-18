namespace Legerity.Windows.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines the highlighter flyout components of the <see cref="InkToolbar"/>.
    /// </summary>
    public partial class InkToolbar
    {
        /// <summary>
        /// Defines a color flyout for the highlighter in the <see cref="InkToolbar"/>.
        /// </summary>
        public class InkToolbarHighlighterFlyout : InkToolbarColorFlyoutBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Legerity.Windows.Elements.Core.InkToolbar.InkToolbarHighlighterFlyout"/> class.
            /// </summary>
            /// <param name="element">
            /// The <see cref="WindowsElement"/> reference.
            /// </param>
            public InkToolbarHighlighterFlyout(WindowsElement element)
                : base(element)
            {
            }

            /// <summary>
            /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="InkToolbarHighlighterFlyout"/> without direct casting.
            /// </summary>
            /// <param name="element">
            /// The <see cref="WindowsElement"/>.
            /// </param>
            /// <returns>
            /// The <see cref="InkToolbarHighlighterFlyout"/>.
            /// </returns>
            public static implicit operator InkToolbarHighlighterFlyout(WindowsElement element)
            {
                return new InkToolbarHighlighterFlyout(element);
            }

            /// <summary>
            /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="InkToolbarHighlighterFlyout"/> without direct casting.
            /// </summary>
            /// <param name="element">
            /// The <see cref="AppiumWebElement"/>.
            /// </param>
            /// <returns>
            /// The <see cref="InkToolbarHighlighterFlyout"/>.
            /// </returns>
            public static implicit operator InkToolbarHighlighterFlyout(AppiumWebElement element)
            {
                return new InkToolbarHighlighterFlyout(element as WindowsElement);
            }

            /// <summary>
            /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="InkToolbarHighlighterFlyout"/> without direct casting.
            /// </summary>
            /// <param name="element">
            /// The <see cref="RemoteWebElement"/>.
            /// </param>
            /// <returns>
            /// The <see cref="InkToolbarHighlighterFlyout"/>.
            /// </returns>
            public static implicit operator InkToolbarHighlighterFlyout(RemoteWebElement element)
            {
                return new InkToolbarHighlighterFlyout(element as WindowsElement);
            }
        }
    }
}