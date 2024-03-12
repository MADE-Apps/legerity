namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class TextBoxTests : BaseTestClass
{
    public TextBoxTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSetText()
    {
        // Arrange
        var textBoxPage = StartAndNavigateToPage();

        // Act
        textBoxPage.SetSimpleTextBox("MADE Apps");

        // Assert
        textBoxPage.SimpleTextBox.Text.ShouldBe("MADE Apps");
    }

    [Test]
    public void ShouldAppendText()
    {
        // Arrange
        var textBoxPage = StartAndNavigateToPage().SetSimpleTextBox("MADE ");

        // Act
        textBoxPage.AppendSimpleTextBoxText("Apps");

        // Assert
        textBoxPage.SimpleTextBox.Text.ShouldBe("MADE Apps");
    }

    [Test]
    public void ShouldClearText()
    {
        // Arrange
        var textBoxPage = StartAndNavigateToPage().SetSimpleTextBox("MADE Apps");

        // Act
        textBoxPage.ClearSimpleTextBox();

        // Assert
        textBoxPage.SimpleTextBox.Text.ShouldBeNullOrEmpty();
    }

    [Test]
    public void ShouldGetIsReadonly()
    {
        // Arrange
        var textBoxPage = StartAndNavigateToPage();

        // Act & Assert
        textBoxPage.ReadonlyTextBox.IsReadonly.ShouldBeTrue();
    }

    private TextBoxPage StartAndNavigateToPage()
    {
        var app = StartApp();
        return new HomePage(app).NavigateTo<TextBoxPage>("TextBox");
    }
}
