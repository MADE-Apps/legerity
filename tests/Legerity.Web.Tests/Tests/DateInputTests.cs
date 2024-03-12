namespace Legerity.Web.Tests.Tests;

using System.Collections.Generic;
using System.IO;
using System;
using Legerity.Web.Tests.Pages;
using OpenQA.Selenium.Remote;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class DateInputTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_date";

    public DateInputTests(AppManagerOptions options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets the platform options to run tests on.
    /// </summary>
    protected static IEnumerable<AppManagerOptions> PlatformOptions => new List<AppManagerOptions>
    {
        new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Maximize = true, Url = WebApplication, ImplicitWait = ImplicitWait, DriverOptions = ConfigureChromeOptions()
        }
    };

    [Test]
    public void ShouldSetDate()
    {
        // Arrange
        var expected = DateTime.Now.Date;

        var app = StartApp();

        var dateInputPage = new DateInputPage(app)
            .AcceptCookies<DateInputPage>()
            .SwitchToContentFrame<DateInputPage>();

        // Act
        dateInputPage.SetBirthdayDate(expected);

        // Assert
        dateInputPage.DateInput.SelectedDate.ShouldBe(expected);
    }
}
