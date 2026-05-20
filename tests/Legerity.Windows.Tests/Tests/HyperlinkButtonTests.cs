using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Tests;

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