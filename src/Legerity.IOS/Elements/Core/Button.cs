// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.IOS.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core iOS Button control.
/// </summary>
public class Button : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Button"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public Button(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the button's label content.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Label => this.GetLabel();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Button"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Button"/>.
    /// </returns>
    public static implicit operator Button(WebElement element)
    {
        return new Button(element as AppiumElement);
    }
}