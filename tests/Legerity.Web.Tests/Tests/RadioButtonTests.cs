namespace Legerity.Web.Tests.Tests;

using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.Children)]
internal class RadioButtonTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio";

    public RadioButtonTests(AppManagerOptions options)
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
    public void ShouldSelectRadioButton()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        RadioButtonPage radioButtonPage = new RadioButtonPage(app)
            .AcceptCookies<RadioButtonPage>()
            .SwitchToContentFrame<RadioButtonPage>();

        // Act
        radioButtonPage.SelectCssRadioButton();

        // Assert
        radioButtonPage.CssRadioButton.IsSelected.ShouldBeTrue();
    }

    [Test]
    public void ShouldGetGroupName()
    {
        // Arrange
        const string expectedGroupName = "fav_language";

        RemoteWebDriver app = this.StartApp();

        RadioButtonPage radioButtonPage = new RadioButtonPage(app)
            .AcceptCookies<RadioButtonPage>()
            .SwitchToContentFrame<RadioButtonPage>();

        // Act
        string groupName = radioButtonPage.LanguageGroupRadioButtons.FirstOrDefault().Group;

        // Assert
        groupName.ShouldBe(expectedGroupName);
    }
}