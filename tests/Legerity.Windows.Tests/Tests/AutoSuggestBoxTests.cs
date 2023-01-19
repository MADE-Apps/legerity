namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class AutoSuggestBoxTests : BaseTestClass
{
    public AutoSuggestBoxTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSetText()
    {
        // Arrange
        const string expectedText = "British Shorthair";

        RemoteWebDriver app = this.StartApp();
        AutoSuggestBoxPage autoSuggestBoxPage = new HomePage(app).NavigateTo<AutoSuggestBoxPage>("AutoSuggestBox");

        // Act
        autoSuggestBoxPage.SetBasicSuggestionText(expectedText);

        // Assert
        autoSuggestBoxPage.BasicAutoSuggestBox.Text.ShouldBe(expectedText);
    }

    [Test]
    public void ShouldSelectSuggestion()
    {
        // Arrange
        const string expectedText = "British Shorthair";

        RemoteWebDriver app = this.StartApp();
        AutoSuggestBoxPage autoSuggestBoxPage = new HomePage(app).NavigateTo<AutoSuggestBoxPage>("AutoSuggestBox");

        // Act
        autoSuggestBoxPage.SelectBasicSuggestion(expectedText);

        // Assert
        autoSuggestBoxPage.BasicAutoSuggestBox.Text.ShouldBe(expectedText);
    }

    [Test]
    public void ShouldSelectSuggestionByValue()
    {
        // Arrange
        const string expectedText = "British Shorthair";

        RemoteWebDriver app = this.StartApp();
        AutoSuggestBoxPage autoSuggestBoxPage = new HomePage(app).NavigateTo<AutoSuggestBoxPage>("AutoSuggestBox");

        // Act
        autoSuggestBoxPage.SelectBasicSuggestionByValue("British", expectedText);

        // Assert
        autoSuggestBoxPage.BasicAutoSuggestBox.Text.ShouldBe(expectedText);
    }

    [Test]
    public void ShouldSelectSuggestionByPartialSuggestion()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        AutoSuggestBoxPage autoSuggestBoxPage = new HomePage(app).NavigateTo<AutoSuggestBoxPage>("AutoSuggestBox");

        // Act
        autoSuggestBoxPage.SelectBasicSuggestionByPartialSuggestion("British", "Shorthair");

        // Assert
        autoSuggestBoxPage.BasicAutoSuggestBox.Text.ShouldBe("British Shorthair");
    }
}