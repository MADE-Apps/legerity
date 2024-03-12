namespace Legerity.Windows.Tests.Tests;

using System;
using System.Collections.Generic;
using System.Globalization;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class DatePickerTests : BaseTestClass
{
    public DatePickerTests(AppManagerOptions options)
        : base(options)
    {
    }

    [TestCaseSource(nameof(DateTestCases))]
    public void ShouldSelectDate(DateTime expectedDate)
    {
        // Arrange
        var app = StartApp();
        var datePickerPage = new HomePage(app).NavigateTo<DatePickerPage>("DatePicker");

        // Act
        datePickerPage.SetSimpleDatePickerDate(expectedDate);

        // Assert
        datePickerPage.SimpleDatePicker.SelectedDate.ShouldBe(expectedDate);
    }

    [Test]
    public void ShouldSelectDateWithFormat()
    {
        // Arrange
        var expectedDate = DateTime.Now.AddDays(1);
        var app = StartApp();
        var datePickerPage = new HomePage(app).NavigateTo<DatePickerPage>("DatePicker");

        // Act
        datePickerPage.SetSimpleDatePickerDate(expectedDate);

        // Assert
        datePickerPage.SimpleDatePicker.Value.ShouldBe(expectedDate.ToString("MMMM d, yyyy", CultureInfo.CurrentCulture));
    }

    private static IEnumerable<DateTime> DateTestCases()
    {
        // Ensures that all looping selectors are tested.
        yield return DateTime.Now.AddDays(1).Date;
        yield return DateTime.Now.AddMonths(1).Date;
        yield return DateTime.Now.AddYears(1).Date;
    }
}
