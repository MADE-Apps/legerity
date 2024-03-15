namespace Legerity.Windows.Elements.Core;

using System;
using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP TimePicker control.
/// </summary>
public class TimePicker : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimePicker"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public TimePicker(WebElement element)
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
        return new TimePicker(element);
    }

    /// <summary>
    /// Sets the time to the specified time.
    /// </summary>
    /// <param name="time">
    /// The time to set.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SetTime(TimeSpan time)
    {
        // Taps the time picker to show the popup.
        Click();

        // Finds the popup and changes the time.
        var popup = Driver.FindElement(WindowsByExtras.AutomationId("TimePickerFlyoutPresenter"));
        popup.FindElement(WindowsByExtras.AutomationId("HourLoopingSelector")).FindElementByName(time.ToString("%h")).Click();
        popup.FindElement(WindowsByExtras.AutomationId("MinuteLoopingSelector")).FindElementByName(time.ToString("mm")).Click();
        popup.FindElement(WindowsByExtras.AutomationId("AcceptButton")).Click();
    }
}
