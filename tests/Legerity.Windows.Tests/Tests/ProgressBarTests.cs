using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

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
        WebDriver app = this.StartApp();
        ProgressBarPage progressBarPage = new HomePage(app).NavigateTo<ProgressBarPage>("ProgressBar");

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
        WebDriver app = this.StartApp();
        ProgressBarPage progressBarPage = new HomePage(app).NavigateTo<ProgressBarPage>("ProgressBar");

        // Act & Assert
        progressBarPage.IndeterminateProgressBar.IsIndeterminate.ShouldBeTrue();
    }
}