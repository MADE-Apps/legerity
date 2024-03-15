namespace Legerity.Windows.Tests.Tests;

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
        var app = StartApp();
        var appBarToggleButtonPage = new HomePage(app).NavigateTo<AppBarToggleButtonPage>("AppBarToggleButton");

        // Act
        appBarToggleButtonPage.ToggleSymbolOn();

        // Assert
        appBarToggleButtonPage.SymbolToggleButton.IsOn.ShouldBeTrue();
    }

    [Test]
    public void ShouldKeepToggledOnIfToggledOn()
    {
        // Arrange
        var app = StartApp();
        var appBarToggleButtonPage = new HomePage(app).NavigateTo<AppBarToggleButtonPage>("AppBarToggleButton").ToggleSymbolOn();

        // Act
        appBarToggleButtonPage.ToggleSymbolOn();

        // Assert
        appBarToggleButtonPage.SymbolToggleButton.IsOn.ShouldBeTrue();
    }

    [Test]
    public void ShouldToggleOff()
    {
        // Arrange
        var app = StartApp();
        var appBarToggleButtonPage = new HomePage(app).NavigateTo<AppBarToggleButtonPage>("AppBarToggleButton").ToggleSymbolOn();

        // Act
        appBarToggleButtonPage.ToggleSymbolOff();

        // Assert
        appBarToggleButtonPage.SymbolToggleButton.IsOn.ShouldBeFalse();
    }

    [Test]
    public void ShouldKeepToggledOffIfToggledOff()
    {
        // Arrange
        var app = StartApp();
        var appBarToggleButtonPage = new HomePage(app).NavigateTo<AppBarToggleButtonPage>("AppBarToggleButton").ToggleSymbolOff();

        // Act
        appBarToggleButtonPage.ToggleSymbolOff();

        // Assert
        appBarToggleButtonPage.SymbolToggleButton.IsOn.ShouldBeFalse();
    }
}
