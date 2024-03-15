using System;
using System.Collections.Generic;
using System.IO;
using Legerity.Web.Tests.Pages;
using Shouldly;

namespace Legerity.Web.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class TextInputTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_input_text";

    public TextInputTests(AppManagerOptions options)
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
    public void ShouldSetText()
    {
        // Arrange
        const string expected = "James";

        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        // Act
        textInputPage.SetFirstName(expected);

        // Assert
        textInputPage.FirstNameInput.Text.ShouldBe(expected);
    }

    [Test]
    public void ShouldAppendText()
    {
        // Arrange
        const string expected = "James";

        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        textInputPage.SetFirstName("J");

        // Act
        textInputPage.AppendFirstName("ames");

        // Assert
        textInputPage.FirstNameInput.Text.ShouldBe(expected);
    }

    [Test]
    public void ShouldClearText()
    {
        // Arrange
        var app = StartApp();

        var textInputPage = new TextInputPage(app)
            .AcceptCookies<TextInputPage>()
            .SwitchToContentFrame<TextInputPage>();

        textInputPage.SetFirstName("James");

        // Act
        textInputPage.ClearFirstName();

        // Assert
        textInputPage.FirstNameInput.Text.ShouldBeEmpty();
    }
}
