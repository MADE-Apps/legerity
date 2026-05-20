using Legerity.Windows.Extensions;
using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

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
        WebDriver app = this.StartApp();
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
        WebDriver app = this.StartApp();
        PivotPage pivotPage = new HomePage(app).NavigateTo<PivotPage>("Pivot");

        // Act
        pivotPage.ClickEmailTabByPartialName("Flag");

        // Assert
        pivotPage.EmailPivot.SelectedItem.VerifyNameOrAutomationIdContains("Flagged").ShouldBeTrue();
    }
}