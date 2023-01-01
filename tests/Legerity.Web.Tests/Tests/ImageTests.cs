namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using Helpers;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.Children)]
internal class ImageTests : BaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_image_test";

    public ImageTests(AppManagerOptions options)
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
    public void ShouldGetImageSource()
    {
        // Arrange
        const string expectedImageSource = "img_girl.jpg";

        RemoteWebDriver app = this.StartApp(this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);

        ImagePage imagePage = new ImagePage(app)
            .AcceptCookies<ImagePage>()
            .SwitchToContentFrame<ImagePage>();

        // Act
        string imageSource = imagePage.Image.Source;

        // Assert
        imageSource.ShouldContain(expectedImageSource);
    }

    [Test]
    public void ShouldGetImageAltText()
    {
        // Arrange
        const string expectedAltText = "Girl in a jacket";

        RemoteWebDriver app = this.StartApp(this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);

        ImagePage imagePage = new ImagePage(app)
            .AcceptCookies<ImagePage>()
            .SwitchToContentFrame<ImagePage>();

        // Act
        string altText = imagePage.Image.AltText;

        // Assert
        altText.ShouldBe(expectedAltText);
    }

    [Test]
    public void ShouldGetImageSize()
    {
        // Arrange
        const double expectedHeight = 600;
        const double expectedWidth = 500;

        RemoteWebDriver app = this.StartApp(this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);

        ImagePage imagePage = new ImagePage(app)
            .AcceptCookies<ImagePage>()
            .SwitchToContentFrame<ImagePage>();

        // Act
        double height = imagePage.Image.Height;
        double width = imagePage.Image.Width;

        // Assert
        height.ShouldBe(expectedHeight);
        width.ShouldBe(expectedWidth);
    }
}