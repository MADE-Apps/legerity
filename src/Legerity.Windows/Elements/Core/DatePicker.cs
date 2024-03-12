namespace Legerity.Windows.Elements.Core;

using System;
using System.Text.RegularExpressions;
using Extensions;
using Legerity.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP DatePicker control.
/// </summary>
public class DatePicker : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DatePicker"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public DatePicker(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the date picker.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Value => GetValue();

    /// <summary>
    /// Gets the value of the date picker as a <see cref="DateTime"/>.
    /// </summary>
    public virtual DateTime? SelectedDate => GetSelectedDate();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="DatePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DatePicker"/>.
    /// </returns>
    public static implicit operator DatePicker(WebElement element)
    {
        return new DatePicker(element);
    }

    /// <summary>
    /// Sets the date to the specified date.
    /// </summary>
    /// <param name="date">The date to set.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SetDate(DateTime date)
    {
        var selectedDate = SelectedDate;
        if (selectedDate.HasValue && selectedDate.Value.Date == date.Date)
        {
            return;
        }

        var selectedDay = selectedDate?.ToString("%d");
        var selectedMonth = selectedDate?.ToString("MMMM");
        var selectedYear = selectedDate?.ToString("yyyy");

        // Taps the date picker to show the popup.
        Click();

        // Finds the popup and changes the date.
        WindowsElementWrapper popup = Driver.FindElement(WindowsByExtras.AutomationId("DatePickerFlyoutPresenter"));

        if (selectedDay != date.ToString("%d"))
        {
            popup.FindElement(WindowsByExtras.AutomationId("DayLoopingSelector")).FindElementByName(date.ToString("%d")).Click();
        }

        if (selectedMonth != date.ToString("MMMM"))
        {
            popup.FindElement(WindowsByExtras.AutomationId("MonthLoopingSelector")).FindElementByName(date.ToString("MMMM")).Click();
        }

        if (selectedYear != date.ToString("yyyy"))
        {
            popup.FindElement(WindowsByExtras.AutomationId("YearLoopingSelector")).FindElementByName(date.ToString("yyyy")).Click();
        }

        popup.FindElement(WindowsByExtras.AutomationId("AcceptButton")).Click();
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string GetValue()
    {
        var button = FindElement(WindowsByExtras.AutomationId("FlyoutButton"));
        var name = button.GetName().RemoveUnicodeCharacters();
        var match = Regex.Match(name, @"\w+\s\d{1,2},\s\d{4}");
        return match.Success ? match.Value : null;
    }

    private DateTime? GetSelectedDate()
    {
        var value = Value;
        return string.IsNullOrEmpty(value) ? default :
            DateTime.TryParse(value, out var date) ? date : default(DateTime?);
    }
}
