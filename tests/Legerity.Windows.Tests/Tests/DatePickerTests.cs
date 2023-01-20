namespace Legerity.Windows.Tests.Tests;

using System;
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

    [Test]
    public void ShouldSelectDate()
    {
        // Arrange
        DateTime expectedDate = DateTime.Now.AddDays(1).Date;
        RemoteWebDriver app = this.StartApp();
        DatePickerPage datePickerPage = new HomePage(app).NavigateTo<DatePickerPage>("DatePicker");

        // Act
        datePickerPage.SetSimpleDatePickerDate(expectedDate);

        // Assert
        datePickerPage.SimpleDatePicker.SelectedDate.ShouldBe(expectedDate);
    }

    [Test]
    public void ShouldSelectDateWithFormat()
    {
        // Arrange
        DateTime expectedDate = DateTime.Now.AddDays(1);
        RemoteWebDriver app = this.StartApp();
        DatePickerPage datePickerPage = new HomePage(app).NavigateTo<DatePickerPage>("DatePicker");

        // Act
        datePickerPage.SetSimpleDatePickerDate(expectedDate);

        // Assert
        datePickerPage.SimpleDatePicker.Value.ShouldBe(expectedDate.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture));
    }
}