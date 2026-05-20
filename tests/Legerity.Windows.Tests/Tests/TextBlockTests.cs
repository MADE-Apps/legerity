using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

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
        WebDriver app = this.StartApp();
        TextBlockPage textBlockPage = new HomePage(app).NavigateTo<TextBlockPage>("TextBlock");

        // Act & Assert
        textBlockPage.TextBlock.Text.ShouldBe("I am a TextBlock.");
    }
}