namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class ProgressRingTests : BaseTestClass
{
    public ProgressRingTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldGetDeterminatePercentage()
    {
        // Arrange
        ProgressRingPage progressRingPage = this.StartAndNavigateToPage();

        // Act
        progressRingPage.SetDeterminateProgressRingValue(50);

        // Assert
        progressRingPage.DeterminateProgressRing.IsIndeterminate.ShouldBeFalse();
        progressRingPage.DeterminateProgressRing.Percentage.ShouldBe(50);
    }

    [Test]
    public void ShouldGetIsIndeterminate()
    {
        // Arrange
        ProgressRingPage progressBarPage = this.StartAndNavigateToPage();

        // Act & Assert
        progressBarPage.IndeterminateProgressRing.IsIndeterminate.ShouldBeTrue();
    }

    private ProgressRingPage StartAndNavigateToPage()
    {
        RemoteWebDriver app = this.StartApp();
        return new HomePage(app).NavigateTo<ProgressRingPage>("ProgressRing");
    }
}