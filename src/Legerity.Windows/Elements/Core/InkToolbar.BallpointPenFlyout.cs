namespace Legerity.Windows.Elements.Core;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines the ballpoint pen flyout components of the <see cref="InkToolbar"/>.
/// </summary>
public partial class InkToolbar
{
    /// <summary>
    /// Defines a color flyout for the ballpoint pen in the <see cref="InkToolbar"/>.
    /// </summary>
    public class InkToolbarBallpointPenFlyout : InkToolbarColorFlyoutBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Legerity.Windows.Elements.Core.InkToolbar.InkToolbarBallpointPenFlyout"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public InkToolbarBallpointPenFlyout(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="InkToolbarBallpointPenFlyout"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbarBallpointPenFlyout"/>.
        /// </returns>
        public static implicit operator InkToolbarBallpointPenFlyout(WindowsElement element)
        {
            return new InkToolbarBallpointPenFlyout(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="InkToolbarBallpointPenFlyout"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbarBallpointPenFlyout"/>.
        /// </returns>
        public static implicit operator InkToolbarBallpointPenFlyout(AppiumWebElement element)
        {
            return new InkToolbarBallpointPenFlyout(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="InkToolbarBallpointPenFlyout"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbarBallpointPenFlyout"/>.
        /// </returns>
        public static implicit operator InkToolbarBallpointPenFlyout(RemoteWebElement element)
        {
            return new InkToolbarBallpointPenFlyout(element as WindowsElement);
        }
    }
}