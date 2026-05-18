// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.IOS.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core iOS Switch control.
/// </summary>
public class Switch : IOSElementWrapper
{
    private const string ToggleOnValue = "1";

    /// <summary>
    /// Initializes a new instance of the <see cref="Switch"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public Switch(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the toggle switch is in the on position.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsOn => this.GetValue() == ToggleOnValue;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Switch"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Switch"/>.
    /// </returns>
    public static implicit operator Switch(WebElement element)
    {
        return new Switch(element as AppiumElement);
    }

    /// <summary>
    /// Toggles the switch on.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ToggleOn()
    {
        if (this.IsOn)
        {
            return;
        }

        this.Click();
    }

    /// <summary>
    /// Toggles the switch off.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ToggleOff()
    {
        if (!this.IsOn)
        {
            return;
        }

        this.Click();
    }
}