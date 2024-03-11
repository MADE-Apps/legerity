namespace Legerity.Windows.Elements.Core;

using System;
using Legerity.Exceptions;
using Legerity.Extensions;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP CalendarDatePicker control.
/// </summary>
public class CalendarDatePicker : WindowsElementWrapper
{
    private readonly By calendarPopupLocator = By.XPath(".//*[@ClassName='Popup'][@Name='Popup']");

    /// <summary>
    /// Initializes a new instance of the <see cref="CalendarDatePicker"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public CalendarDatePicker(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the calendar flyout.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual CalendarView CalendarViewFlyout => this.Driver.FindElement(this.calendarPopupLocator)
        .FindElement(WindowsByExtras.AutomationId("CalendarView"));

    /// <summary>
    /// Gets the value of the calendar date picker.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Value => this.GetValue().RemoveUnicodeCharacters();

    /// <summary>
    /// Gets the value of the calendar date picker as a <see cref="DateTime"/>.
    /// </summary>
    public virtual DateTime? SelectedDate => this.GetSelectedDate();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="CalendarDatePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CalendarDatePicker"/>.
    /// </returns>
    public static implicit operator CalendarDatePicker(WebElement element)
    {
        return new CalendarDatePicker(element);
    }
    
    /// <summary>
    /// Sets the selected date of the calendar view.
    /// </summary>
    /// <param name="date">The date to set to.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SetDate(DateTime date)
    {
        this.Click();

        this.VerifyDriverElementShown(this.calendarPopupLocator, TimeSpan.FromSeconds(2));

        this.CalendarViewFlyout.SetDate(date);
    }

    private DateTime? GetSelectedDate()
    {
        string value = this.Value;
        return string.IsNullOrEmpty(value) ? default :
            DateTime.TryParse(value, out DateTime date) ? date : default(DateTime?);
    }
}