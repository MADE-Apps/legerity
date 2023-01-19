namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;

[TestFixtureSource(nameof(PlatformOptions))]
internal class AppBarButtonTests : BaseTestClass
{
    public AppBarButtonTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldClickSymbolButton()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        AppBarButtonPage appBarButtonPage = new HomePage(app).NavigateTo<AppBarButtonPage>("AppBarButton");

        // Act & Assert
        appBarButtonPage.ClickSymbolButton();
    }
}