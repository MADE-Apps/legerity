namespace Legerity.Android.Elements.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android DatePicker control.
    /// </summary>
    public class DatePicker : AndroidElementWrapper
    {
        private readonly Dictionary<string, string> months = new Dictionary<string, string>()
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
        /// The <see cref="AndroidElement"/> reference.
        /// </param>
        public DatePicker(AndroidElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the date text.
        /// <para>
        /// This will be in the format, 'ddd, MMM d'.
        /// </para>
        /// </summary>
        public TextView DateTextView => this.Element.FindElement(By.Id("android:id/date_picker_header_date"));

        /// <summary>
        /// Gets the element associated with the year text.
        /// <para>
        /// This will be in the format, 'YYYY'.
        /// </para>
        /// </summary>
        public TextView YearTextView => this.Element.FindElement(By.Id("android:id/date_picker_header_year"));

        /// <summary>
        /// Gets the element associated with the day picker.
        /// </summary>
        public View DayPickerView => this.Element.FindElement(By.Id("android:id/day_picker_view_pager"));

        /// <summary>
        /// Gets the element associated with the next month button.
        /// </summary>
        public Button NextMonthButton => this.Element.FindElementByAndroidUIAutomator("UiSelector().description(\"Next month\")");

        /// <summary>
        /// Gets the element associated with the previous month button.
        /// </summary>
        public Button PreviousMonthButton => this.Element.FindElementByAndroidUIAutomator("UiSelector().description(\"Previous month\")");

        /// <summary>
        /// Gets the selected date/time value.
        /// </summary>
        public DateTime SelectedDate => this.GetCurrentViewDate();

        /// <summary>
        /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="DatePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="DatePicker"/>.
        /// </returns>
        public static implicit operator DatePicker(AndroidElement element)
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
            return new DatePicker(element as AndroidElement);
        }

        /// <summary>
        /// Sets the selected date of the date picker.
        /// </summary>
        /// <param name="date">The date to set to.</param>
        public void SetDate(DateTime date)
        {
            DateTime currentViewDate = this.GetCurrentViewDate();

            int monthDifference = ((date.Year - currentViewDate.Year) * 12) + date.Month - currentViewDate.Month;

            if (monthDifference > 0)
            {
                for (int i = 0; i < monthDifference; i++)
                {
                    this.NextMonthButton.Click();
                }
            }
            else
            {
                for (int i = 0; i < Math.Abs(monthDifference); i++)
                {
                    this.PreviousMonthButton.Click();
                }
            }

            View item = this.DayPickerView.Element.FindElementByAndroidUIAutomator($"UiSelector().text(\"{date.Day}\")");
            item.Click();
        }

        private DateTime GetCurrentViewDate()
        {
            string currentYear = this.YearTextView.Text;
            string currentDate = this.DateTextView.Text;
            return this.GetCurrentViewDate(currentDate, currentYear);
        }

        private DateTime GetCurrentViewDate(string currentDate, string currentYear)
        {
            string day = string.Join(string.Empty, currentDate.Where(char.IsDigit)).Trim();

            var currentDateSplit = currentDate.Split(',').ToList();
            string currentMonthPart = currentDateSplit.LastOrDefault();

            this.months.TryGetValue(
                string.Join(string.Empty, (currentMonthPart ?? string.Empty).Where(char.IsLetter)).Trim(),
                out string month);

            string year = string.Join(string.Empty, currentYear.Where(char.IsDigit)).Trim();

            string dateString = $"{day}/{month}/{year}";
            return DateTime.ParseExact(dateString, @"d/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}