namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;

[TestFixtureSource(nameof(PlatformOptions))]
internal class HyperlinkButtonTests : BaseTestClass
{
    public HyperlinkButtonTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldClickHyperlinkButton()
    {
        // Arrange
        WebDriver app = this.StartApp();
        HyperlinkButtonPage hyperlinkButtonPage = new HomePage(app).NavigateTo<HyperlinkButtonPage>("HyperlinkButton");

        // Act & Assert
        hyperlinkButtonPage.ClickHyperlinkButton();
    }
}