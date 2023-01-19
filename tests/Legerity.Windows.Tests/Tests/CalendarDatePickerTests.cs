namespace Legerity.Windows.Tests.Tests;

using System;
using System.Globalization;
using OpenQA.Selenium.Remote;
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
        RemoteWebDriver app = this.StartApp();
        CalendarDatePickerPage calendarDatePickerPage = new HomePage(app).NavigateTo<CalendarDatePickerPage>("CalendarDatePicker");

        // Act
        DateTime? selectedDate = calendarDatePickerPage.CalendarDatePicker.SelectedDate;

        // Assert
        selectedDate.ShouldBeNull();
    }

    [Test]
    public void ShouldSelectDate()
    {
        // Arrange
        DateTime expectedDate = DateTime.Now.AddDays(1).Date;
        RemoteWebDriver app = this.StartApp();
        CalendarDatePickerPage calendarDatePickerPage =
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
        DateTime expectedDate = DateTime.Now.AddDays(1);
        RemoteWebDriver app = this.StartApp();
        CalendarDatePickerPage calendarDatePickerPage =
            new HomePage(app).NavigateTo<CalendarDatePickerPage>("CalendarDatePicker");

        // Act
        calendarDatePickerPage.SetCalendarDatePickerDate(expectedDate);

        // Assert
        calendarDatePickerPage.CalendarDatePicker.Value.ShouldBe(expectedDate.ToString("d", CultureInfo.CurrentCulture));
    }
}