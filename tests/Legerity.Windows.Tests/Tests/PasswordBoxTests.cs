namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class PasswordBoxTests : BaseTestClass
{
    public PasswordBoxTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSetPassword()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        PasswordBoxPage passwordBoxPage = new HomePage(app).NavigateTo<PasswordBoxPage>("PasswordBox");

        // Act
        passwordBoxPage.SetPassword("password");
        passwordBoxPage.PasswordBox.RevealPassword();

        // Assert
        passwordBoxPage.PasswordBox.Password.ShouldBe("password");
        passwordBoxPage.PasswordBox.HidePassword();
    }
}