namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
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
        var app = StartApp();
        var inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectBallpointPenColor("Red");

        // Assert
        inkToolbarPage.InkToolbar.SelectedBallpointPenColor.ShouldBe("Red");
    }

    [Test]
    public void ShouldSetPencilColor()
    {
        // Arrange
        var app = StartApp();
        var inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectPencilColor("Red");

        // Assert
        inkToolbarPage.InkToolbar.SelectedPencilColor.ShouldBe("Red");
    }

    [Test]
    public void ShouldSetHighlighterColor()
    {
        // Arrange
        var app = StartApp();
        var inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectHighlighterColor("Pink");

        // Assert
        inkToolbarPage.InkToolbar.SelectedHighlighterColor.ShouldBe("Pink");
    }

    [Test]
    public void ShouldSetBallpointPenColorByPartialName()
    {
        // Arrange
        var app = StartApp();
        var inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectBallpointPenPartialColor("Yell");

        // Assert
        inkToolbarPage.InkToolbar.SelectedBallpointPenColor.ShouldBe("Yellow");
    }

    [Test]
    public void ShouldSetPencilColorByPartialName()
    {
        // Arrange
        var app = StartApp();
        var inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectPencilPartialColor("Yell");

        // Assert
        inkToolbarPage.InkToolbar.SelectedPencilColor.ShouldBe("Yellow");
    }

    [Test]
    public void ShouldSetHighlighterColorByPartialName()
    {
        // Arrange
        var app = StartApp();
        var inkToolbarPage = new HomePage(app).NavigateTo<InkToolbarPage>("InkToolbar");

        // Act
        inkToolbarPage.SelectHighlighterPartialColor("Yell");

        // Assert
        inkToolbarPage.InkToolbar.SelectedHighlighterColor.ShouldBe("Yellow");
    }
}
