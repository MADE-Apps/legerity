// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the UWP MenuFlyoutItem control.
/// </summary>
public class MenuFlyoutItem : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenuFlyoutItem"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public MenuFlyoutItem(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="MenuFlyoutItem"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="MenuFlyoutItem"/>.
    /// </returns>
    public static implicit operator MenuFlyoutItem(WebElement element)
    {
        return new MenuFlyoutItem(element as AppiumElement);
    }
}