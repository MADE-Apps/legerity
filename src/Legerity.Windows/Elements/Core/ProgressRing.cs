// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core UWP ProgressRing control.
/// </summary>
public class ProgressRing : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressRing"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public ProgressRing(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the progress ring.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Percentage => this.GetRangeValue();

    /// <summary>
    /// Gets a value indicating whether the control is in an indeterminate state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public bool IsIndeterminate =>
        this.GetAttribute("IsRangeValuePatternAvailable").Equals(
            "False",
            StringComparison.CurrentCultureIgnoreCase);

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="ProgressRing"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ProgressRing"/>.
    /// </returns>
    public static implicit operator ProgressRing(WebElement element)
    {
        return new ProgressRing(element as AppiumElement);
    }
}