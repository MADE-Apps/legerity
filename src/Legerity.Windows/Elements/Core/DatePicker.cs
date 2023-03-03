namespace Legerity.Windows.Elements.Core;

using System;
using System.Text.RegularExpressions;
using Legerity.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP DatePicker control.
/// </summary>
public class DatePicker : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DatePicker"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public DatePicker(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the date picker.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Value => this.GetValue();

    /// <summary>
    /// Gets the value of the date picker as a <see cref="DateTime"/>.
    /// </summary>
    public virtual DateTime? SelectedDate => this.GetSelectedDate();

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="DatePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DatePicker"/>.
    /// </returns>
    public static implicit operator DatePicker(WindowsElement element)
    {
        return new DatePicker(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="DatePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DatePicker"/>.
    /// </returns>
    public static implicit operator DatePicker(AppiumWebElement element)
    {
        return new DatePicker(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="DatePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DatePicker"/>.
    /// </returns>
    public static implicit operator DatePicker(RemoteWebElement element)
    {
        return new DatePicker(element as WindowsElement);
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
        DateTime? selectedDate = this.SelectedDate;
        if (selectedDate.HasValue && selectedDate.Value.Date == date.Date)
        {
            return;
        }

        string selectedDay = selectedDate?.ToString("%d");
        string selectedMonth = selectedDate?.ToString("MMMM");
        string selectedYear = selectedDate?.ToString("yyyy");

        // Taps the date picker to show the popup.
        this.Click();

        // Finds the popup and changes the date.
        WindowsElementWrapper popup = this.Driver.FindElement(WindowsByExtras.AutomationId("DatePickerFlyoutPresenter"));

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
        AppiumWebElement button = this.FindElement(WindowsByExtras.AutomationId("FlyoutButton"));
        string name = button.GetName().RemoveUnicodeCharacters();
        Match match = Regex.Match(name, @"\w+\s\d{1,2},\s\d{4}");
        return match.Success ? match.Value : null;
    }

    private DateTime? GetSelectedDate()
    {
        string value = this.Value;
        return string.IsNullOrEmpty(value) ? default :
            DateTime.TryParse(value, out DateTime date) ? date : default(DateTime?);
    }
}