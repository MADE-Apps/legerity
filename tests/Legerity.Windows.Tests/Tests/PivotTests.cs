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
        var app = StartApp();
        var pivotPage = new HomePage(app).NavigateTo<PivotPage>("Pivot");

        // Act
        pivotPage.ClickEmailTab("Flagged");

        // Assert
        pivotPage.EmailPivot.SelectedItem.VerifyNameOrAutomationIdContains("Flagged").ShouldBeTrue();
    }

    [Test]
    public void ShouldSelectPivotItemByPartialName()
    {
        // Arrange
        var app = StartApp();
        var pivotPage = new HomePage(app).NavigateTo<PivotPage>("Pivot");

        // Act
        pivotPage.ClickEmailTabByPartialName("Flag");

        // Assert
        pivotPage.EmailPivot.SelectedItem.VerifyNameOrAutomationIdContains("Flagged").ShouldBeTrue();
    }
}
