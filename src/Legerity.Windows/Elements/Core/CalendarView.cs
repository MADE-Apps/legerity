namespace Legerity.Windows.Elements.Core;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Legerity.Extensions;
using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP CalendarView control.
/// </summary>
public class CalendarView : WindowsElementWrapper
{
    private readonly Dictionary<string, string> months = new()
    {
        { "January", "01" },
        { "February", "02" },
        { "March", "03" },
        { "April", "04" },
        { "May", "05" },
        { "June", "06" },
        { "July", "07" },
        { "August", "08" },
        { "September", "09" },
        { "October", "10" },
        { "November", "11" },
        { "December", "12" },
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="CalendarView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public CalendarView(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the header button (change month, year).
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button HeaderButton => this.FindElement(WindowsByExtras.AutomationId("HeaderButton"));

    /// <summary>
    /// Gets the element associated with the next month button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button NextMonthButton => this.FindElement(WindowsByExtras.AutomationId("NextButton"));

    /// <summary>
    /// Gets the element associated with the previous month button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button PreviousMonthButton =>
        this.FindElement(WindowsByExtras.AutomationId("PreviousButton"));

    /// <summary>
    /// Gets the collection of days associated with the current month in the calendar view.
    /// </summary>
    public virtual ReadOnlyCollection<AppiumWebElement> Days =>
        this.Element.FindElements(By.ClassName("CalendarViewDayItem"));

    /// <summary>
    /// Gets the value of the calendar view.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Value => this.GetValue().RemoveUnicodeCharacters();

    /// <summary>
    /// Gets the value of the calendar view as a <see cref="DateTime"/>.
    /// </summary>
    public virtual DateTime? SelectedDate => this.GetSelectedDate();

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="CalendarView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CalendarView"/>.
    /// </returns>
    public static implicit operator CalendarView(WindowsElement element)
    {
        return new CalendarView(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="CalendarView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CalendarView"/>.
    /// </returns>
    public static implicit operator CalendarView(AppiumWebElement element)
    {
        return new CalendarView(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="CalendarView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CalendarView"/>.
    /// </returns>
    public static implicit operator CalendarView(RemoteWebElement element)
    {
        return new CalendarView(element as WindowsElement);
    }

    /// <summary>
    /// Sets the selected date of the calendar view.
    /// </summary>
    /// <param name="date">The date to set to.</param>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public void SetDate(DateTime date)
    {
        string expectedDay = date.ToString("%d");
        string expectedHeader = date.ToString("MMMM yyyy");

        string currentHeader = this.HeaderButton.GetName();
        DateTime currentViewDate = this.GetCurrentViewDate(currentHeader);

        while (!expectedHeader.Equals(currentHeader, StringComparison.CurrentCultureIgnoreCase))
        {
            if (currentViewDate.Date > date.Date)
            {
                this.PreviousMonthButton.Click();
            }
            else
            {
                this.NextMonthButton.Click();
            }

            Thread.Sleep(10);

            currentHeader = this.HeaderButton.GetName();
        }

        AppiumWebElement item = this.Days.FirstOrDefault(
            element => element.GetName().Equals(expectedDay, StringComparison.CurrentCultureIgnoreCase));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find day {expectedDay} in the current view.");
        }

        item.Click();
    }

    private DateTime GetCurrentViewDate(string currentHeader)
    {
        this.months.TryGetValue(
            string.Join(string.Empty, currentHeader.Where(char.IsLetter)).Trim(),
            out string month);

        string year = string.Join(string.Empty, currentHeader.Where(char.IsDigit)).Trim();

        string dateString = $"01/{month}/{year}";
        return DateTime.ParseExact(dateString, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    }

    private DateTime? GetSelectedDate()
    {
        string value = this.Value;
        return string.IsNullOrEmpty(value) ? default :
            DateTime.TryParse(value, out DateTime date) ? date : default(DateTime?);
    }
}