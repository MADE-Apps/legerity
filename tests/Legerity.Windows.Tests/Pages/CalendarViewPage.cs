namespace Legerity.Windows.Tests.Pages;

using System;
using Elements.Core;
using OpenQA.Selenium;

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
