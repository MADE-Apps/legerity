namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;

[TestFixtureSource(nameof(PlatformOptions))]
internal class CommandBarTests : BaseTestClass
{
    public CommandBarTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldClickPrimaryButtonByName()
    {
        // Arrange
        var app = StartApp();
        var commandBarPage = new HomePage(app).NavigateTo<CommandBarPage>("CommandBar");

        // Act & Assert
        commandBarPage.ClickPrimaryAddButton();
    }

    [Test]
    public void ShouldClickPrimaryButtonByPartialName()
    {
        // Arrange
        var app = StartApp();
        var commandBarPage = new HomePage(app).NavigateTo<CommandBarPage>("CommandBar");

        // Act & Assert
        commandBarPage.ClickPrimaryButton("Add");
    }

    [Test]
    public void ShouldClickSecondaryButtonByName()
    {
        // Arrange
        var app = StartApp();
        var commandBarPage = new HomePage(app).NavigateTo<CommandBarPage>("CommandBar");

        // Act & Assert
        commandBarPage.ClickSecondarySettingsButton();
    }

    [Test]
    public void ShouldClickSecondaryButtonByPartialName()
    {
        // Arrange
        var app = StartApp();
        var commandBarPage = new HomePage(app).NavigateTo<CommandBarPage>("CommandBar");

        // Act & Assert
        commandBarPage.ClickSecondaryButton("Setting");
    }
}
