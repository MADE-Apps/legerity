namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class TextBlockTests : BaseTestClass
{
    public TextBlockTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldGetText()
    {
        // Arrange
        var app = StartApp();
        var textBlockPage = new HomePage(app).NavigateTo<TextBlockPage>("TextBlock");

        // Act & Assert
        textBlockPage.TextBlock.Text.ShouldBe("I am a TextBlock.");
    }
}
