// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Android.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core Android TextView control.
/// </summary>
public class TextView : AndroidElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public TextView(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text view.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.Element.Text;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="TextView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextView"/>.
    /// </returns>
    public static implicit operator TextView(WebElement element)
    {
        return new TextView(element as AppiumElement);
    }
}