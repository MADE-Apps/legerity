namespace Legerity.WinUI.Tests.Tests;

using Legerity.WinUI.Tests.Pages;
using OpenQA.Selenium.Remote;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class InfoBarTests : BaseTestClass
{
    public InfoBarTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldGetTitle()
    {
        // Arrange
        InfoBarPage infoBarPage = this.StartAndNavigateToPage();

        // Act & Assert
        infoBarPage.CloseableInfoBar.Title.ShouldBe("Title");
    }

    [Test]
    public void ShouldGetMessage()
    {
        // Arrange
        InfoBarPage infoBarPage = this.StartAndNavigateToPage();

        // Act & Assert
        infoBarPage.CloseableInfoBar.Message.ShouldBe("Essential app message for your users to be informed of, acknowledge, or take action on.");
    }

    [Test]
    public void ShouldGetIsOpen()
    {
        // Arrange
        InfoBarPage infoBarPage = this.StartAndNavigateToPage();

        // Act & Assert
        infoBarPage.CloseableInfoBar.IsOpen.ShouldBeTrue();
    }

    [Test]
    public void ShouldClose()
    {
        // Arrange
        InfoBarPage infoBarPage = this.StartAndNavigateToPage();

        // Act & Assert
        infoBarPage.CloseClosableInfoBar();
    }

    private InfoBarPage StartAndNavigateToPage()
    {
        WebDriver app = this.StartApp();
        return new HomePage(app).NavigateTo<InfoBarPage>("InfoBar");
    }
}