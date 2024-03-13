namespace Legerity.Windows.Tests.Tests;

using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class ProgressBarTests : BaseTestClass
{
    public ProgressBarTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldGetDeterminateValue()
    {
        // Arrange
        var app = StartApp();
        var progressBarPage = new HomePage(app).NavigateTo<ProgressBarPage>("ProgressBar");

        // Act
        progressBarPage.SetDeterminateProgressBarValue(50);

        // Assert
        progressBarPage.DeterminateProgressBar.IsIndeterminate.ShouldBeFalse();
        progressBarPage.DeterminateProgressBar.Percentage.ShouldBe(50);
    }

    [Test]
    public void ShouldGetIndeterminateValue()
    {
        // Arrange
        var app = StartApp();
        var progressBarPage = new HomePage(app).NavigateTo<ProgressBarPage>("ProgressBar");

        // Act & Assert
        progressBarPage.IndeterminateProgressBar.IsIndeterminate.ShouldBeTrue();
    }
}
