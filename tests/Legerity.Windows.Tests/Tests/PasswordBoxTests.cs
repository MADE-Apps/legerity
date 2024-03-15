namespace Legerity.Windows.Tests.Tests;

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
        var app = StartApp();
        var passwordBoxPage = new HomePage(app).NavigateTo<PasswordBoxPage>("PasswordBox");

        // Act
        passwordBoxPage.SetPassword("password");
        passwordBoxPage.PasswordBox.RevealPassword();

        // Assert
        passwordBoxPage.PasswordBox.Password.ShouldBe("password");
        passwordBoxPage.PasswordBox.HidePassword();
    }
}
