using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Tests;

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
        WebDriver app = this.StartApp();
        AppBarButtonPage appBarButtonPage = new HomePage(app).NavigateTo<AppBarButtonPage>("AppBarButton");

        // Act & Assert
        appBarButtonPage.ClickSymbolButton();
    }
}