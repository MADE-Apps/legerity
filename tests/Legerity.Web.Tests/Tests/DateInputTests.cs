// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Web.Tests.Tests;

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
        DateTime expected = DateTime.Now.Date;

        WebDriver app = this.StartApp();

        DateInputPage dateInputPage = new DateInputPage(app)
            .AcceptCookies<DateInputPage>()
            .SwitchToContentFrame<DateInputPage>();

        // Act
        dateInputPage.SetBirthdayDate(expected);

        // Assert
        dateInputPage.DateInput.SelectedDate.ShouldBe(expected);
    }
}