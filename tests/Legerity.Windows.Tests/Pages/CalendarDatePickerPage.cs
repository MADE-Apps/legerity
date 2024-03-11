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

    public CalendarDatePicker CalendarDatePicker =>this.FindElement(By.ClassName(nameof(this.CalendarDatePicker)));

    public CalendarDatePickerPage SetCalendarDatePickerDate(DateTime date)
    {
        this.CalendarDatePicker.SetDate(date);
        return this;
    }
}