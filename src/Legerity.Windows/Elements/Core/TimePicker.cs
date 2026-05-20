// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core UWP TimePicker control.
/// </summary>
public class TimePicker : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimePicker"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public TimePicker(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="TimePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TimePicker"/>.
    /// </returns>
    public static implicit operator TimePicker(WebElement element)
    {
        return new TimePicker(element as AppiumElement);
    }

    /// <summary>
    /// Sets the time to the specified time.
    /// </summary>
    /// <param name="time">
    /// The time to set.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SetTime(TimeSpan time)
    {
        // Taps the time picker to show the popup.
        this.Click();

        // Finds the popup and changes the time.
        AppiumElement popup = this.Driver.FindElement(WindowsByExtras.AutomationId("TimePickerFlyoutPresenter"));
        popup.FindElement(WindowsByExtras.AutomationId("HourLoopingSelector")).FindElement(By.Name(time.ToString("%h"))).Click();
        popup.FindElement(WindowsByExtras.AutomationId("MinuteLoopingSelector")).FindElement(By.Name(time.ToString("mm"))).Click();
        popup.FindElement(WindowsByExtras.AutomationId("AcceptButton")).Click();
    }
}