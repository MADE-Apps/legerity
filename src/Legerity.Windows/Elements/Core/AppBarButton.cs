// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core UWP AppBarButton control.
/// </summary>
public class AppBarButton : Button
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppBarButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public AppBarButton(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="AppBarButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="AppBarButton"/>.
    /// </returns>
    public static implicit operator AppBarButton(WebElement element)
    {
        return new AppBarButton(element as AppiumElement);
    }
}