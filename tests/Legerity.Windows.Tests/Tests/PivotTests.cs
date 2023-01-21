namespace Legerity.Windows.Tests.Tests;

using Extensions;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class PivotTests : BaseTestClass
{
    public PivotTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSelectPivotItem()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        PivotPage pivotPage = new HomePage(app).NavigateTo<PivotPage>("Pivot");

        // Act
        pivotPage.ClickEmailTab("Flagged");

        // Assert
        pivotPage.EmailPivot.SelectedItem.VerifyNameOrAutomationIdContains("Flagged").ShouldBeTrue();
    }

    [Test]
    public void ShouldSelectPivotItemByPartialName()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        PivotPage pivotPage = new HomePage(app).NavigateTo<PivotPage>("Pivot");

        // Act
        pivotPage.ClickEmailTabByPartialName("Flag");

        // Assert
        pivotPage.EmailPivot.SelectedItem.VerifyNameOrAutomationIdContains("Flagged").ShouldBeTrue();
    }
}