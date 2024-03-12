namespace Legerity.Windows.Tests.Tests;

using System;
using OpenQA.Selenium.Remote;
using Pages;

[TestFixtureSource(nameof(PlatformOptions))]
internal class TimePickerTests : BaseTestClass
{
    public TimePickerTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSetTime()
    {
        // Arrange
        var timePickerPage = StartAndNavigateToPage();

        // Act & Assert
        timePickerPage.SetTimePickerTime(new TimeSpan(12, 30, 0));
    }

    private TimePickerPage StartAndNavigateToPage()
    {
        var app = StartApp();
        return new HomePage(app).NavigateTo<TimePickerPage>("TimePicker");
    }
}
