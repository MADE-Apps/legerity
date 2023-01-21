namespace Legerity.Windows.Tests.Pages;

using System;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class CalendarViewPage : BaseNavigationPage
{
    public CalendarViewPage(RemoteWebDriver app) : base(app)
    {
    }

    public CalendarView CalendarView => this.FindElement(By.ClassName(nameof(this.CalendarView)));
    
    public CalendarViewPage SetCalendarViewDate(DateTime date)
    {
        this.CalendarView.SetDate(date);
        return this;
    }
}