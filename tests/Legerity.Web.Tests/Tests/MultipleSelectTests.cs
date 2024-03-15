using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Legerity.Web.Tests.Pages;
using Shouldly;

namespace Legerity.Web.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class MultipleSelectTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_select_multiple";

    public MultipleSelectTests(AppManagerOptions options)
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
    public void ShouldGetIsMultipleTrue()
    {
        // Arrange
        var app = StartApp();

        var selectPage = new SelectPage(app)
            .AcceptCookies<SelectPage>()
            .SwitchToContentFrame<SelectPage>();

        // Act
        var isMultiple = selectPage.CarsSelect.IsMultiple;

        // Act & Assert
        isMultiple.ShouldBeTrue();
    }

    [Test]
    public void ShouldSelectMultipleOptions()
    {
        // Arrange
        var app = StartApp();

        var selectPage = new SelectPage(app)
            .AcceptCookies<SelectPage>()
            .SwitchToContentFrame<SelectPage>();

        // Act
        selectPage.CarsSelect.SelectOptionByValue("volvo");
        selectPage.CarsSelect.SelectOptionByValue("saab");

        // Assert
        selectPage.CarsSelect.SelectedOptions.Count().ShouldBe(2);
        selectPage.CarsSelect.SelectedOptions.ShouldContain(o => o.Value == "volvo");
        selectPage.CarsSelect.SelectedOptions.ShouldContain(o => o.Value == "saab");
    }
}
