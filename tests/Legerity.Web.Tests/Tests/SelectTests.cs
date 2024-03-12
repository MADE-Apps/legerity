namespace Legerity.Web.Tests.Tests;

using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class SelectTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_select";

    public SelectTests(AppManagerOptions options)
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
    public void ShouldGetOptions()
    {
        // Arrange
        var app = StartApp();

        var selectPage = new SelectPage(app)
            .AcceptCookies<SelectPage>()
            .SwitchToContentFrame<SelectPage>();

        // Act
        var options = selectPage.CarsSelect.Options.Select(o => o.DisplayValue);

        // Assert
        options.Count().ShouldBe(4);
        options.ShouldContain("Volvo");
        options.ShouldContain("Saab");
        options.ShouldContain("Opel");
        options.ShouldContain("Audi");
    }

    [Test]
    public void ShouldGetIsMultipleFalse()
    {
        // Arrange
        var app = StartApp();

        var selectPage = new SelectPage(app)
            .AcceptCookies<SelectPage>()
            .SwitchToContentFrame<SelectPage>();

        // Act
        var isMultiple = selectPage.CarsSelect.IsMultiple;

        // Assert
        isMultiple.ShouldBeFalse();
    }

    [Test]
    public void ShouldSelectOptionByValue()
    {
        // Arrange
        var expected = "audi";

        var app = StartApp();

        var selectPage = new SelectPage(app)
            .AcceptCookies<SelectPage>()
            .SwitchToContentFrame<SelectPage>();

        // Act
        selectPage.CarsSelect.SelectOptionByValue(expected);

        // Assert
        selectPage.CarsSelect.SelectedOption.Value.ShouldBe(expected);
    }

    [Test]
    public void ShouldSelectOptionByDisplayValue()
    {
        // Arrange
        var expected = "Audi";

        var app = StartApp();

        var selectPage = new SelectPage(app)
            .AcceptCookies<SelectPage>()
            .SwitchToContentFrame<SelectPage>();

        // Act
        selectPage.CarsSelect.SelectOptionByDisplayValue(expected);

        // Assert
        selectPage.CarsSelect.SelectedOption.DisplayValue.ShouldBe(expected);
    }

    [Test]
    public void ShouldSelectOptionByPartialValue()
    {
        // Arrange
        var expected = "audi";

        var app = StartApp();

        var selectPage = new SelectPage(app)
            .AcceptCookies<SelectPage>()
            .SwitchToContentFrame<SelectPage>();

        // Act
        selectPage.CarsSelect.SelectOptionByPartialValue("aud");

        // Assert
        selectPage.CarsSelect.SelectedOption.Value.ShouldBe(expected);
    }

    [Test]
    public void ShouldSelectOptionByPartialDisplayValue()
    {
        // Arrange
        var expected = "Audi";

        var app = StartApp();

        var selectPage = new SelectPage(app)
            .AcceptCookies<SelectPage>()
            .SwitchToContentFrame<SelectPage>();

        // Act
        selectPage.CarsSelect.SelectOptionByPartialDisplayValue("Aud");

        // Assert
        selectPage.CarsSelect.SelectedOption.DisplayValue.ShouldBe(expected);
    }
}
