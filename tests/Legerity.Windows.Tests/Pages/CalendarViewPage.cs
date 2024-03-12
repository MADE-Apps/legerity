namespace Legerity.Windows.Tests.Pages;

using System;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class CalendarViewPage : BaseNavigationPage
{
    public CalendarViewPage(WebDriver app) : base(app)
    {
    }

    public CalendarView CalendarView => FindElement(By.ClassName(nameof(CalendarView)));
    
    public CalendarViewPage SetCalendarViewDate(DateTime date)
    {
        CalendarView.SetDate(date);
        return this;
    }
}