namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class AppBarToggleButtonTests : BaseTestClass
{
    public AppBarToggleButtonTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldToggleOn()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        AppBarToggleButtonPage appBarToggleButtonPage = new HomePage(app).NavigateTo<AppBarToggleButtonPage>("AppBarToggleButton");

        // Act
        appBarToggleButtonPage.ToggleSymbolOn();

        // Assert
        appBarToggleButtonPage.SymbolToggleButton.IsOn.ShouldBeTrue();
    }

    [Test]
    public void ShouldKeepToggledOnIfToggledOn()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        AppBarToggleButtonPage appBarToggleButtonPage = new HomePage(app).NavigateTo<AppBarToggleButtonPage>("AppBarToggleButton").ToggleSymbolOn();

        // Act
        appBarToggleButtonPage.ToggleSymbolOn();

        // Assert
        appBarToggleButtonPage.SymbolToggleButton.IsOn.ShouldBeTrue();
    }

    [Test]
    public void ShouldToggleOff()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        AppBarToggleButtonPage appBarToggleButtonPage = new HomePage(app).NavigateTo<AppBarToggleButtonPage>("AppBarToggleButton").ToggleSymbolOn();

        // Act
        appBarToggleButtonPage.ToggleSymbolOff();

        // Assert
        appBarToggleButtonPage.SymbolToggleButton.IsOn.ShouldBeFalse();
    }

    [Test]
    public void ShouldKeepToggledOffIfToggledOff()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        AppBarToggleButtonPage appBarToggleButtonPage = new HomePage(app).NavigateTo<AppBarToggleButtonPage>("AppBarToggleButton").ToggleSymbolOff();

        // Act
        appBarToggleButtonPage.ToggleSymbolOff();

        // Assert
        appBarToggleButtonPage.SymbolToggleButton.IsOn.ShouldBeFalse();
    }
}