using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Legerity.Web.Tests.Pages;
using Shouldly;

namespace Legerity.Web.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class OptionTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_option";

    public OptionTests(AppManagerOptions options)
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
    public void ShouldSelectOptionByValue()
    {
        // Arrange
        var expected = "audi";

        var app = StartApp();

        var optionPage = new OptionPage(app)
            .AcceptCookies<OptionPage>()
            .SwitchToContentFrame<OptionPage>();

        // Act
        optionPage.SelectCarOptionByValue(expected);

        // Assert
        optionPage.CarOptions.FirstOrDefault(o => o.IsSelected).Value.ShouldBe(expected);
    }

    [Test]
    public void ShouldSelectOptionByDisplayValue()
    {
        // Arrange
        var expected = "Audi";

        var app = StartApp();

        var optionPage = new OptionPage(app)
            .AcceptCookies<OptionPage>()
            .SwitchToContentFrame<OptionPage>();

        // Act
        optionPage.SelectCarOptionByDisplayValue(expected);

        // Assert
        optionPage.CarOptions.FirstOrDefault(o => o.IsSelected).DisplayValue.ShouldBe(expected);
    }
}
