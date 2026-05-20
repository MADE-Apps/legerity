using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Tests;

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
        WebDriver app = this.StartApp();
        ButtonPage buttonPage = new HomePage(app).NavigateTo<ButtonPage>("Button");

        // Act & Assert
        buttonPage.ClickStandardXamlButton();
    }
}