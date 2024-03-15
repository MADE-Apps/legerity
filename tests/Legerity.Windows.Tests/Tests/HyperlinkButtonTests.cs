namespace Legerity.Windows.Tests.Tests;

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
        var app = StartApp();
        var hyperlinkButtonPage = new HomePage(app).NavigateTo<HyperlinkButtonPage>("HyperlinkButton");

        // Act & Assert
        hyperlinkButtonPage.ClickHyperlinkButton();
    }
}
