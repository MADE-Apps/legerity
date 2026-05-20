using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class CalendarViewPage : BaseNavigationPage
{
    public CalendarViewPage(WebDriver app) : base(app)
    {
    }

    public CalendarView CalendarView => this.FindElement(By.ClassName(nameof(this.CalendarView)));

    public CalendarViewPage SetCalendarViewDate(DateTime date)
    {
        this.CalendarView.SetDate(date);
        return this;
    }
}