namespace Legerity.Windows.Tests.Tests;

using Pages;
using Shouldly;
using System.Globalization;
using System;

[TestFixtureSource(nameof(PlatformOptions))]
internal class CalendarViewTests : BaseTestClass
{
    public CalendarViewTests(AppManagerOptions options)
        : base(options)
    {
    }

    [TestCase("12/12/2022")]
    [TestCase("01/01/2023")]
    [TestCase("02/02/2023")]
    public void ShouldSelectDate(string dateString)
    {
        // Arrange
        var expectedDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture);
        var app = StartApp();
        var calendarViewPage = new HomePage(app).NavigateTo<CalendarViewPage>("CalendarView");

        // Act
        calendarViewPage.SetCalendarViewDate(expectedDate);

        // Assert
        calendarViewPage.CalendarView.SelectedDate.ShouldBe(expectedDate);
    }

    [Test]
    public void ShouldSelectDateWithFormat()
    {
        // Arrange
        var expectedDate = DateTime.Now.AddDays(1);
        var app = StartApp();
        var calendarViewPage = new HomePage(app).NavigateTo<CalendarViewPage>("CalendarView");

        // Act
        calendarViewPage.SetCalendarViewDate(expectedDate);

        // Assert
        calendarViewPage.CalendarView.Value.ShouldBe(expectedDate.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture));
    }
}
