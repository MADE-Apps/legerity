namespace Legerity.WinUI.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;

[TestFixtureSource(nameof(PlatformOptions))]
internal class MenuBarTests : BaseTestClass
{
    public MenuBarTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldClickOption()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        MenuBarPage menuBarPage = new HomePage(app).NavigateTo<MenuBarPage>("MenuBar");

        // Act & Assert
        menuBarPage.SelectSimpleMenuBarOption("File");
    }

    [Test]
    public void ShouldClickOptionByPartialName()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        MenuBarPage menuBarPage = new HomePage(app).NavigateTo<MenuBarPage>("MenuBar");

        // Act & Assert
        menuBarPage.SelectSimpleMenuBarOptionPartial("Fil");
    }

    [Test]
    public void ShouldClickChildOption()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        MenuBarPage menuBarPage = new HomePage(app).NavigateTo<MenuBarPage>("MenuBar");

        // Act & Assert
        menuBarPage.SelectSimpleMenuBarOption("File", "Open");
    }

    [Test]
    public void ShouldClickChildOptionByPartialName()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        MenuBarPage menuBarPage = new HomePage(app).NavigateTo<MenuBarPage>("MenuBar");

        // Act & Assert
        menuBarPage.SelectSimpleMenuBarOptionPartial("Fil", "Ope");
    }
}