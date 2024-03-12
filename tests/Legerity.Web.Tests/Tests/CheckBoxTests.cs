namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class CheckBoxTests : W3SchoolsBaseTestClass
{
    private const string WebApplication =
        "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_checkbox";

    public CheckBoxTests(AppManagerOptions options)
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
    public void ShouldCheckUncheckedCheckbox()
    {
        // Arrange
        var app = StartApp();

        var checkBoxPage = new CheckBoxPage(app)
            .AcceptCookies<CheckBoxPage>()
            .SwitchToContentFrame<CheckBoxPage>()
            .CheckBikeOff();

        // Act
        checkBoxPage.CheckBikeOn();

        // Assert
        checkBoxPage.BikeCheckBox.IsChecked.ShouldBeTrue();
    }

    [Test]
    public void ShouldKeepCheckedIfCheckedAgain()
    {
        // Arrange
        var app = StartApp();

        var checkBoxPage = new CheckBoxPage(app)
            .AcceptCookies<CheckBoxPage>()
            .SwitchToContentFrame<CheckBoxPage>()
            .CheckBikeOn();

        // Act
        checkBoxPage.CheckBikeOn();

        // Assert
        checkBoxPage.BikeCheckBox.IsChecked.ShouldBeTrue();
    }

    [Test]
    public void ShouldUncheckCheckedCheckbox()
    {
        // Arrange
        var app = StartApp();

        var checkBoxPage = new CheckBoxPage(app)
            .AcceptCookies<CheckBoxPage>()
            .SwitchToContentFrame<CheckBoxPage>()
            .CheckBikeOn();

        // Act
        checkBoxPage.CheckBikeOff();

        // Assert
        checkBoxPage.BikeCheckBox.IsChecked.ShouldBeFalse();
    }

    [Test]
    public void ShouldKeepUncheckedIfUncheckedAgain()
    {
        // Arrange
        var app = StartApp();

        var checkBoxPage = new CheckBoxPage(app)
            .AcceptCookies<CheckBoxPage>()
            .SwitchToContentFrame<CheckBoxPage>()
            .CheckBikeOff();

        // Act
        checkBoxPage.CheckBikeOff();

        // Assert
        checkBoxPage.BikeCheckBox.IsChecked.ShouldBeFalse();
    }
}
