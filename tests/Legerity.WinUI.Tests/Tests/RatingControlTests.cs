namespace Legerity.WinUI.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class RatingControlTests : BaseTestClass
{
    public RatingControlTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSetValue()
    {
        // Arrange
        RatingControlPage ratingControlPage = StartAndNavigateToPage();

        // Act
        ratingControlPage.SetSimpleRatingValue(3);

        // Assert
        ratingControlPage.SimpleRatingControl.Value.ShouldBe(3);
    }

    [Test]
    public void ShouldGetValueRange()
    {
        // Arrange
        RatingControlPage ratingControlPage = StartAndNavigateToPage();

        // Act & Assert
        ratingControlPage.SimpleRatingControl.Minimum.ShouldBe(0);
        ratingControlPage.SimpleRatingControl.Maximum.ShouldBe(5);
    }

    [Test]
    public void ShouldGetIsReadonly()
    {
        // Arrange
        RatingControlPage ratingControlPage = StartAndNavigateToPage();

        // Act & Assert
        ratingControlPage.SimpleRatingControl.IsReadonly.ShouldBeFalse();
    }

    private RatingControlPage StartAndNavigateToPage()
    {
        WebDriver app = StartApp();
        return new HomePage(app).NavigateTo<RatingControlPage>("RatingControl");
    }
}