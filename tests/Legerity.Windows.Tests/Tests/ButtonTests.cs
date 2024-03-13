namespace Legerity.Windows.Tests.Tests;

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
        var app = StartApp();
        var buttonPage = new HomePage(app).NavigateTo<ButtonPage>("Button");

        // Act & Assert
        buttonPage.ClickStandardXamlButton();
    }
}
