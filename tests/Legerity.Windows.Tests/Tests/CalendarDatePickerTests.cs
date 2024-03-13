namespace Legerity.Windows.Tests.Tests;

using System;
using System.Globalization;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class CalendarDatePickerTests : BaseTestClass
{
    public CalendarDatePickerTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldReturnNullSelectedDateIfNoDateSelected()
    {
        // Arrange
        var app = StartApp();
        var calendarDatePickerPage = new HomePage(app).NavigateTo<CalendarDatePickerPage>("CalendarDatePicker");

        // Act
        var selectedDate = calendarDatePickerPage.CalendarDatePicker.SelectedDate;

        // Assert
        selectedDate.ShouldBeNull();
    }

    [Test]
    public void ShouldSelectDate()
    {
        // Arrange
        var expectedDate = DateTime.Now.AddDays(1).Date;
        var app = StartApp();
        var calendarDatePickerPage =
            new HomePage(app).NavigateTo<CalendarDatePickerPage>("CalendarDatePicker");

        // Act
        calendarDatePickerPage.SetCalendarDatePickerDate(expectedDate);

        // Assert
        calendarDatePickerPage.CalendarDatePicker.SelectedDate.ShouldBe(expectedDate);
    }

    [Test]
    public void ShouldSelectDateWithFormat()
    {
        // Arrange
        var expectedDate = DateTime.Now.AddDays(1);
        var app = StartApp();
        var calendarDatePickerPage =
            new HomePage(app).NavigateTo<CalendarDatePickerPage>("CalendarDatePicker");

        // Act
        calendarDatePickerPage.SetCalendarDatePickerDate(expectedDate);

        // Assert
        calendarDatePickerPage.CalendarDatePicker.Value.ShouldBe(expectedDate.ToString("d", CultureInfo.CurrentCulture));
    }
}
