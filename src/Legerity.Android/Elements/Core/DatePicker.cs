// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Android.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the core Android DatePicker control.
/// </summary>
public class DatePicker : AndroidElementWrapper
{
    private readonly Dictionary<string, string> months = new()
    {
        { "Jan", "01" },
        { "Feb", "02" },
        { "Mar", "03" },
        { "Apr", "04" },
        { "May", "05" },
        { "Jun", "06" },
        { "Jul", "07" },
        { "Aug", "08" },
        { "Sep", "09" },
        { "Oct", "10" },
        { "Nov", "11" },
        { "Dec", "12" },
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="DatePicker"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public DatePicker(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the date text.
    /// <para>
    /// This will be in the format, 'ddd, MMM d'.
    /// </para>
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextView DateTextView => this.FindElement(By.Id("android:id/date_picker_header_date"));

    /// <summary>
    /// Gets the element associated with the year text.
    /// <para>
    /// This will be in the format, 'YYYY'.
    /// </para>
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextView YearTextView => this.FindElement(By.Id("android:id/date_picker_header_year"));

    /// <summary>
    /// Gets the element associated with the day picker.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual View DayPickerView => this.FindElement(By.Id("android:id/day_picker_view_pager"));

    /// <summary>
    /// Gets the element associated with the next month button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button NextMonthButton => this.Element.FindElement(new ByAndroidUIAutomator("UiSelector().description(\"Next month\")"));

    /// <summary>
    /// Gets the element associated with the previous month button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button PreviousMonthButton => this.Element.FindElement(new ByAndroidUIAutomator("UiSelector().description(\"Previous month\")"));

    /// <summary>
    /// Gets the selected date/time value.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual DateTime SelectedDate => this.GetCurrentViewDate();

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
        return new DatePicker(element as AppiumElement);
    }

    /// <summary>
    /// Sets the selected date of the date picker.
    /// </summary>
    /// <param name="date">The date to set to.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SetDate(DateTime date)
    {
        DateTime currentViewDate = this.GetCurrentViewDate();

        var monthDifference = ((date.Year - currentViewDate.Year) * 12) + date.Month - currentViewDate.Month;

        if (monthDifference > 0)
        {
            for (var i = 0; i < monthDifference; i++)
            {
                this.NextMonthButton.Click();
            }
        }
        else
        {
            for (var i = 0; i < Math.Abs(monthDifference); i++)
            {
                this.PreviousMonthButton.Click();
            }
        }

        View item = this.DayPickerView.Element.FindElement(new ByAndroidUIAutomator($"UiSelector().text(\"{date.Day}\")"));
        item.Click();
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private DateTime GetCurrentViewDate()
    {
        var currentYear = this.YearTextView.Text;
        var currentDate = this.DateTextView.Text;
        return this.GetCurrentViewDate(currentDate, currentYear);
    }

    private DateTime GetCurrentViewDate(string currentDate, string currentYear)
    {
        var day = string.Join(string.Empty, currentDate.Where(char.IsDigit)).Trim();

        var currentDateSplit = currentDate.Split(',').ToList();
        var currentMonthPart = currentDateSplit.LastOrDefault();

        this.months.TryGetValue(
            string.Join(string.Empty, (currentMonthPart ?? string.Empty).Where(char.IsLetter)).Trim(),
            out var month);

        var year = string.Join(string.Empty, currentYear.Where(char.IsDigit)).Trim();

        var dateString = $"{day}/{month}/{year}";
        return DateTime.ParseExact(dateString, @"d/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    }
}