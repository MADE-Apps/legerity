// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.IOS.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core iOS Slider control.
/// </summary>
public class Slider : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Slider"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public Slider(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the slider as a percentage between 0 and 100.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => double.Parse(this.GetValue().TrimEnd('%'));

    /// <summary>
    /// Gets a value indicating whether the control is in a readonly state.
    /// </summary>
    public virtual bool IsReadonly => !this.IsEnabled;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Slider"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Slider"/>.
    /// </returns>
    public static implicit operator Slider(WebElement element)
    {
        return new Slider(element as AppiumElement);
    }

    /// <summary>
    /// Sets the value of the slider.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SetValue(double value)
    {
        this.Click();

        var currentValue = this.Value;
        while (Math.Abs(currentValue - value) > double.Epsilon)
        {
            this.Element.SendKeys(currentValue < value ? Keys.ArrowRight : Keys.ArrowLeft);
            currentValue = this.Value;
        }
    }
}