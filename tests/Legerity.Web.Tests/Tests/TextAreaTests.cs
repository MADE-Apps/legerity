namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class TextAreaTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_textarea";

    public TextAreaTests(AppManagerOptions options)
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
    public void ShouldGetSize()
    {
        // Arrange
        WebDriver app = this.StartApp();

        TextAreaPage textAreaPage = new TextAreaPage(app)
            .AcceptCookies<TextAreaPage>()
            .SwitchToContentFrame<TextAreaPage>();

        // Act
        int rows = textAreaPage.ReviewTextArea.Rows;
        int columns = textAreaPage.ReviewTextArea.Cols;

        // Assert
        rows.ShouldBe(4);
        columns.ShouldBe(50);
    }

    [Test]
    public void ShouldSetText()
    {
        // Arrange
        const string expected = "The cat was playing in the garden.";

        WebDriver app = this.StartApp();

        TextAreaPage textAreaPage = new TextAreaPage(app)
            .AcceptCookies<TextAreaPage>()
            .SwitchToContentFrame<TextAreaPage>();

        // Act
        textAreaPage.SetReview(expected);

        // Assert
        textAreaPage.ReviewTextArea.Text.ShouldBe(expected);
    }

    [Test]
    public void ShouldAppendText()
    {
        // Arrange
        const string expected = "The cat was playing in the garden.";

        WebDriver app = this.StartApp();

        TextAreaPage textAreaPage = new TextAreaPage(app)
            .AcceptCookies<TextAreaPage>()
            .SwitchToContentFrame<TextAreaPage>();

        textAreaPage.SetReview("The cat was");

        // Act
        textAreaPage.AppendReview(" playing in the garden.");

        // Assert
        textAreaPage.ReviewTextArea.Text.ShouldBe(expected);
    }

    [Test]
    public void ShouldClearText()
    {
        // Arrange
        WebDriver app = this.StartApp();

        TextAreaPage textAreaPage = new TextAreaPage(app)
            .AcceptCookies<TextAreaPage>()
            .SwitchToContentFrame<TextAreaPage>();

        textAreaPage.SetReview("The cat was playing in the garden.");

        // Act
        textAreaPage.ClearReview();

        // Assert
        textAreaPage.ReviewTextArea.Text.ShouldBeEmpty();
    }
}