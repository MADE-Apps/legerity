using System;
using System.Collections.Generic;
using System.IO;
using Legerity.Web.Tests.Pages;
using Shouldly;

namespace Legerity.Web.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class ImageTests : W3SchoolsBaseTestClass
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

        var app = StartApp();

        var imagePage = new ImagePage(app)
            .AcceptCookies<ImagePage>()
            .SwitchToContentFrame<ImagePage>();

        // Act
        var imageSource = imagePage.Image.Source;

        // Assert
        imageSource.ShouldContain(expectedImageSource);
    }

    [Test]
    public void ShouldGetImageAltText()
    {
        // Arrange
        const string expectedAltText = "Girl in a jacket";

        var app = StartApp();

        var imagePage = new ImagePage(app)
            .AcceptCookies<ImagePage>()
            .SwitchToContentFrame<ImagePage>();

        // Act
        var altText = imagePage.Image.AltText;

        // Assert
        altText.ShouldBe(expectedAltText);
    }

    [Test]
    public void ShouldGetImageSize()
    {
        // Arrange
        const double expectedHeight = 600;
        const double expectedWidth = 500;

        var app = StartApp();

        var imagePage = new ImagePage(app)
            .AcceptCookies<ImagePage>()
            .SwitchToContentFrame<ImagePage>();

        // Act
        var height = imagePage.Image.Height;
        var width = imagePage.Image.Width;

        // Assert
        height.ShouldBe(expectedHeight);
        width.ShouldBe(expectedWidth);
    }
}
