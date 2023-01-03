namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.Children)]
internal class WebElementWrapperTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_input_text";

    public WebElementWrapperTests(AppManagerOptions options)
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
    public void ShouldGetElementDriverMatchingAppDriver()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        TextInputPage textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act
        IWebDriver elementDriver = textInputPage.FirstNameInput.ElementDriver;

        // Assert
        elementDriver.ShouldBe(app);
    }

    [Test]
    public void ShouldGetEnabledState()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        TextInputPage textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act
        bool enabled = textInputPage.FirstNameInput.IsEnabled;

        // Assert
        enabled.ShouldBeTrue();
    }

    [Test]
    public void ShouldGetVisibleState()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        TextInputPage textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act
        bool visible = textInputPage.FirstNameInput.IsVisible;

        // Assert
        visible.ShouldBeTrue();
    }
}