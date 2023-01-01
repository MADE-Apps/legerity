namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using Helpers;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class CheckBoxTests : BaseTestClass
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
        RemoteWebDriver app = this.StartApp(this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);

        var checkBoxPage = new CheckBoxPage(app);
        checkBoxPage.AcceptCookies<CheckBoxPage>();
        checkBoxPage.SwitchToContentFrame<CheckBoxPage>();
        checkBoxPage.CheckBikeOff();

        // Act
        checkBoxPage.CheckBikeOn();

        // Assert
        checkBoxPage.BikeCheckBox.IsChecked.ShouldBeTrue();
    }

    [Test]
    public void ShouldKeepCheckedIfCheckedAgain()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp(this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);

        var checkBoxPage = new CheckBoxPage(app);
        checkBoxPage.AcceptCookies<CheckBoxPage>();
        checkBoxPage.SwitchToContentFrame<CheckBoxPage>();
        checkBoxPage.CheckBikeOn();

        // Act
        checkBoxPage.CheckBikeOn();

        // Assert
        checkBoxPage.BikeCheckBox.IsChecked.ShouldBeTrue();
    }

    [Test]
    public void ShouldUncheckCheckedCheckbox()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp(this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);

        var checkBoxPage = new CheckBoxPage(app);
        checkBoxPage.AcceptCookies<CheckBoxPage>();
        checkBoxPage.SwitchToContentFrame<CheckBoxPage>();
        checkBoxPage.CheckBikeOn();

        // Act
        checkBoxPage.CheckBikeOff();

        // Assert
        checkBoxPage.BikeCheckBox.IsChecked.ShouldBeFalse();
    }

    [Test]
    public void ShouldKeepUncheckedIfUncheckedAgain()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp(this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);

        var checkBoxPage = new CheckBoxPage(app);
        checkBoxPage.AcceptCookies<CheckBoxPage>();
        checkBoxPage.SwitchToContentFrame<CheckBoxPage>();
        checkBoxPage.CheckBikeOff();

        // Act
        checkBoxPage.CheckBikeOff();

        // Assert
        checkBoxPage.BikeCheckBox.IsChecked.ShouldBeFalse();
    }
}