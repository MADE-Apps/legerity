// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.Core;
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
        /// The <see cref="AppiumElement"/> reference.
        /// </param>
        public InkToolbarBallpointPenFlyout(AppiumElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WebElement"/> to the <see cref="InkToolbarBallpointPenFlyout"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbarBallpointPenFlyout"/>.
        /// </returns>
        public static implicit operator InkToolbarBallpointPenFlyout(WebElement element)
        {
            return new InkToolbarBallpointPenFlyout(element as AppiumElement);
        }
    }
}