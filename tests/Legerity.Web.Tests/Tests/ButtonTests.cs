using System;
using System.Collections.Generic;
using System.IO;
using Legerity.Web.Tests.Pages;

namespace Legerity.Web.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class ButtonTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_button_test";

    public ButtonTests(AppManagerOptions options)
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
        },
        new WebAppManagerOptions(
            WebAppDriverType.Edge,
            Path.Combine(Environment.CurrentDirectory))
        {
            Maximize = true, Url = WebApplication, ImplicitWait = ImplicitWait
        },
        new WebAppManagerOptions(
            WebAppDriverType.Firefox,
            Path.Combine(Environment.CurrentDirectory))
        {
            Maximize = true, Url = WebApplication, ImplicitWait = ImplicitWait
        },
        new WebAppManagerOptions(
            WebAppDriverType.Opera,
            Path.Combine(Environment.CurrentDirectory))
        {
            Maximize = true, Url = WebApplication, ImplicitWait = ImplicitWait
        }
    };

    [Test]
    public void ShouldClickButton()
    {
        // Arrange
        var app = StartApp();

        var buttonPage = new ButtonPage(app)
            .AcceptCookies<ButtonPage>()
            .SwitchToContentFrame<ButtonPage>();

        // Act & Assert
        buttonPage.ClickButton();
    }
}
