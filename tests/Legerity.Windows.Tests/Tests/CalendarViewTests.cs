using System.Globalization;
using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
internal class CalendarViewTests : BaseTestClass
{
    public CalendarViewTests(AppManagerOptions options)
        : base(options)
    {
    }

    [TestCase(-30)]
    [TestCase(30)]
    public void ShouldSelectDate(int daysFromToday)
    {
        // Arrange
        var expectedDate = DateTime.Now.Date.AddDays(daysFromToday);
        WebDriver app = this.StartApp();
        CalendarViewPage calendarViewPage = new HomePage(app).NavigateTo<CalendarViewPage>("CalendarView");

        // Act
        calendarViewPage.SetCalendarViewDate(expectedDate);

        // Assert
        calendarViewPage.CalendarView.SelectedDate.ShouldBe(expectedDate);
    }

    [Test]
    public void ShouldSelectDateWithFormat()
    {
        // Arrange
        DateTime expectedDate = DateTime.Now.AddDays(1);
        WebDriver app = this.StartApp();
        CalendarViewPage calendarViewPage = new HomePage(app).NavigateTo<CalendarViewPage>("CalendarView");

        // Act
        calendarViewPage.SetCalendarViewDate(expectedDate);

        // Assert
        calendarViewPage.CalendarView.Value.ShouldBe(expectedDate.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture));
    }
}