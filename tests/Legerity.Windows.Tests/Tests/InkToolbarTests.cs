using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
[AppExclusion("Microsoft.WinUI3ControlsGallery")]
internal class InkToolbarTests : BaseTestClass
{
    public InkToolbarTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSetBallpointPenColor()
    {
        // Arrange
        WebDriver app = this.StartApp();
        InkToolbarPage inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectBallpointPenColor("Red");

        // Assert
        inkToolbarPage.InkToolbar.SelectedBallpointPenColor.ShouldBe("Red");
    }

    [Test]
    public void ShouldSetPencilColor()
    {
        // Arrange
        WebDriver app = this.StartApp();
        InkToolbarPage inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectPencilColor("Red");

        // Assert
        inkToolbarPage.InkToolbar.SelectedPencilColor.ShouldBe("Red");
    }

    [Test]
    public void ShouldSetHighlighterColor()
    {
        // Arrange
        WebDriver app = this.StartApp();
        InkToolbarPage inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectHighlighterColor("Pink");

        // Assert
        inkToolbarPage.InkToolbar.SelectedHighlighterColor.ShouldBe("Pink");
    }

    [Test]
    public void ShouldSetBallpointPenColorByPartialName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        InkToolbarPage inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectBallpointPenPartialColor("Yell");

        // Assert
        inkToolbarPage.InkToolbar.SelectedBallpointPenColor.ShouldBe("Yellow");
    }

    [Test]
    public void ShouldSetPencilColorByPartialName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        InkToolbarPage inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectPencilPartialColor("Yell");

        // Assert
        inkToolbarPage.InkToolbar.SelectedPencilColor.ShouldBe("Yellow");
    }

    [Test]
    public void ShouldSetHighlighterColorByPartialName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        InkToolbarPage inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectHighlighterPartialColor("Yell");

        // Assert
        inkToolbarPage.InkToolbar.SelectedHighlighterColor.ShouldBe("Yellow");
    }
}