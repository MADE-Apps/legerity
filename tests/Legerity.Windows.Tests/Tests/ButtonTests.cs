namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;

[TestFixtureSource(nameof(PlatformOptions))]
internal class ButtonTests : BaseTestClass
{
    public ButtonTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldClickSymbolButton()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        ButtonPage buttonPage = new HomePage(app).NavigateTo<ButtonPage>("Button");

        // Act & Assert
        buttonPage.ClickStandardXamlButton();
    }
}