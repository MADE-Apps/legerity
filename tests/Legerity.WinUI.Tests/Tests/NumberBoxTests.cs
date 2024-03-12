namespace Legerity.WinUI.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class NumberBoxTests : BaseTestClass
{
    public NumberBoxTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSetValue()
    {
        // Arrange
        var numberBoxPage = StartAndNavigateToPage();

        // Act
        numberBoxPage.SetSpinnerNumberBoxValue(10);

        // Assert
        numberBoxPage.SpinnerNumberBox.Value.ShouldBe(10);
    }

    [Test]
    public void ShouldGetIsReadonly()
    {
        // Arrange
        var numberBoxPage = StartAndNavigateToPage();

        // Act & Assert
        numberBoxPage.SpinnerNumberBox.IsReadonly.ShouldBeFalse();
    }

    [Test]
    public void ShouldGetSmallChangeValue()
    {
        // Arrange
        var numberBoxPage = StartAndNavigateToPage();

        // Act & Assert
        numberBoxPage.SpinnerNumberBox.SmallChange.ShouldBe(10);
    }

    [Test]
    public void ShouldIncrementValue()
    {
        // Arrange
        var numberBoxPage = StartAndNavigateToPage().SetSpinnerNumberBoxValue(0);

        // Act
        numberBoxPage.IncrementSpinnerNumberBoxValue();

        // Assert
        numberBoxPage.SpinnerNumberBox.Value.ShouldBe(10);
    }

    [Test]
    public void ShouldDecrementValue()
    {
        // Arrange
        var numberBoxPage = StartAndNavigateToPage().SetSpinnerNumberBoxValue(0);

        // Act
        numberBoxPage.DecrementSpinnerNumberBoxValue();

        // Assert
        numberBoxPage.SpinnerNumberBox.Value.ShouldBe(-10);
    }

    private NumberBoxPage StartAndNavigateToPage()
    {
        var app = StartApp();
        return new HomePage(app).NavigateTo<NumberBoxPage>("NumberBox");
    }
}
