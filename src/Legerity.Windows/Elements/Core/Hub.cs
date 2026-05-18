// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core UWP Hub control.
/// </summary>
public class Hub : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Hub"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public Hub(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the hub.
    /// </summary>
    public virtual ReadOnlyCollection<AppiumElement> Items => this.Element.FindElements(By.ClassName("HubSection"));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Hub"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Hub"/>.
    /// </returns>
    public static implicit operator Hub(WebElement element)
    {
        return new Hub(element as AppiumElement);
    }
}