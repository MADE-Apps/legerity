// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.IOS.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core iOS Label control.
/// </summary>
public class Label : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Label"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public Label(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the label.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.GetLabel();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Label"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Label"/>.
    /// </returns>
    public static implicit operator Label(WebElement element)
    {
        return new Label(element as AppiumElement);
    }
}