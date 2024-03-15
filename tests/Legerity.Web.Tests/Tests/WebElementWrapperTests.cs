using System;
using System.Collections.Generic;
using System.IO;
using Legerity.Web.Extensions;
using Legerity.Web.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Web.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
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
        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act
        var elementDriver = textInputPage.FirstNameInput.ElementDriver;

        // Assert
        elementDriver.ShouldBe(app);
    }

    [Test]
    public void ShouldGetEnabledState()
    {
        // Arrange
        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act
        var enabled = textInputPage.FirstNameInput.IsEnabled;

        // Assert
        enabled.ShouldBeTrue();
    }

    [Test]
    public void ShouldGetVisibleState()
    {
        // Arrange
        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act
        var visible = textInputPage.FirstNameInput.IsVisible;

        // Assert
        visible.ShouldBeTrue();
    }

    [Test]
    public void ShouldWaitUntilConditionMet()
    {
        // Arrange
        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act & Assert
        textInputPage.FirstNameInput.WaitUntil(e => e.IsVisible, TimeSpan.FromSeconds(5));
    }

    [Test]
    public void ShouldThrowExceptionIfWaitUntilConditionNotMet()
    {
        // Arrange
        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act & Assert
        Should.Throw<WebDriverTimeoutException>(() => textInputPage.FirstNameInput.WaitUntil(e => !e.IsVisible));
    }

    [Test]
    public void ShouldTryWaitUntilConditionMet()
    {
        // Arrange
        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act
        var conditionMet = textInputPage.FirstNameInput.TryWaitUntil(e => e.IsVisible, TimeSpan.FromSeconds(5));

        // Assert
        conditionMet.ShouldBeTrue();
    }

    [Test]
    public void ShouldTryWaitUntilConditionNotMet()
    {
        // Arrange
        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act
        var conditionMet = textInputPage.FirstNameInput.TryWaitUntil(e => !e.IsVisible);

        // Assert
        conditionMet.ShouldBeFalse();
    }
}
