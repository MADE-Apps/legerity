namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

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
        string expected = "audi";

        WebDriver app = this.StartApp();

        OptionPage optionPage = new OptionPage(app)
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
        string expected = "Audi";

        WebDriver app = this.StartApp();

        OptionPage optionPage = new OptionPage(app)
            .AcceptCookies<OptionPage>()
            .SwitchToContentFrame<OptionPage>();

        // Act
        optionPage.SelectCarOptionByDisplayValue(expected);

        // Assert
        optionPage.CarOptions.FirstOrDefault(o => o.IsSelected).DisplayValue.ShouldBe(expected);
    }
}