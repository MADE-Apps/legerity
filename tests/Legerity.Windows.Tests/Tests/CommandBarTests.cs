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
        WebDriver app = this.StartApp();
        CommandBarPage commandBarPage = new HomePage(app).NavigateTo<CommandBarPage>("CommandBar");

        // Act & Assert
        commandBarPage.ClickPrimaryAddButton();
    }

    [Test]
    public void ShouldClickPrimaryButtonByPartialName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        CommandBarPage commandBarPage = new HomePage(app).NavigateTo<CommandBarPage>("CommandBar");

        // Act & Assert
        commandBarPage.ClickPrimaryButton("Add");
    }

    [Test]
    public void ShouldClickSecondaryButtonByName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        CommandBarPage commandBarPage = new HomePage(app).NavigateTo<CommandBarPage>("CommandBar");

        // Act & Assert
        commandBarPage.ClickSecondarySettingsButton();
    }

    [Test]
    public void ShouldClickSecondaryButtonByPartialName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        CommandBarPage commandBarPage = new HomePage(app).NavigateTo<CommandBarPage>("CommandBar");

        // Act & Assert
        commandBarPage.ClickSecondaryButton("Setting");
    }
}