// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Android.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Android.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core Android RadioButton control.
/// </summary>
public class RadioButton : Button
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RadioButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public RadioButton(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the radio button is selected.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsSelected => this.GetCheckedState();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="RadioButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="RadioButton"/>.
    /// </returns>
    public static implicit operator RadioButton(WebElement element)
    {
        return new RadioButton(element as AppiumElement);
    }
}