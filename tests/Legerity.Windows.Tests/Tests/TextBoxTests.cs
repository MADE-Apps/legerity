using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

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
        TextBoxPage textBoxPage = this.StartAndNavigateToPage();

        // Act
        textBoxPage.SetSimpleTextBox("MADE Apps");

        // Assert
        textBoxPage.SimpleTextBox.Text.ShouldBe("MADE Apps");
    }

    [Test]
    public void ShouldAppendText()
    {
        // Arrange
        TextBoxPage textBoxPage = this.StartAndNavigateToPage().SetSimpleTextBox("MADE ");

        // Act
        textBoxPage.AppendSimpleTextBoxText("Apps");

        // Assert
        textBoxPage.SimpleTextBox.Text.ShouldBe("MADE Apps");
    }

    [Test]
    public void ShouldClearText()
    {
        // Arrange
        TextBoxPage textBoxPage = this.StartAndNavigateToPage().SetSimpleTextBox("MADE Apps");

        // Act
        textBoxPage.ClearSimpleTextBox();

        // Assert
        textBoxPage.SimpleTextBox.Text.ShouldBeNullOrEmpty();
    }

    [Test]
    public void ShouldGetIsReadonly()
    {
        // Arrange
        TextBoxPage textBoxPage = this.StartAndNavigateToPage();

        // Act & Assert
        textBoxPage.ReadonlyTextBox.IsReadonly.ShouldBeTrue();
    }

    private TextBoxPage StartAndNavigateToPage()
    {
        WebDriver app = this.StartApp();
        return new HomePage(app).NavigateTo<TextBoxPage>("TextBox");
    }
}