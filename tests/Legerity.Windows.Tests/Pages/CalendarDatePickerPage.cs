namespace Legerity.Windows.Tests.Pages;

using System;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class CalendarDatePickerPage : BaseNavigationPage
{
    public CalendarDatePickerPage(WebDriver app) : base(app)
    {
    }

    public CalendarDatePicker CalendarDatePicker =>FindElement(By.ClassName(nameof(CalendarDatePicker)));

    public CalendarDatePickerPage SetCalendarDatePickerDate(DateTime date)
    {
        CalendarDatePicker.SetDate(date);
        return this;
    }
}