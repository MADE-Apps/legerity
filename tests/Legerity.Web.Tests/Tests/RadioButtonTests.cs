using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Legerity.Web.Tests.Pages;
using Shouldly;

namespace Legerity.Web.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
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
        var app = StartApp();

        var radioButtonPage = new RadioButtonPage(app)
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

        var app = StartApp();

        var radioButtonPage = new RadioButtonPage(app)
            .AcceptCookies<RadioButtonPage>()
            .SwitchToContentFrame<RadioButtonPage>();

        // Act
        var groupName = radioButtonPage.LanguageGroupRadioButtons.FirstOrDefault().Group;

        // Assert
        groupName.ShouldBe(expectedGroupName);
    }
}
