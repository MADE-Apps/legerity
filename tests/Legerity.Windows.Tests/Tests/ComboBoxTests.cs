using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
internal class ComboBoxTests : BaseTestClass
{
    public ComboBoxTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSelectItemByName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        ComboBoxPage comboBoxPage = new HomePage(app).NavigateTo<ComboBoxPage>("ComboBox");

        // Act
        comboBoxPage.SelectColorByName("Red");

        // Assert
        comboBoxPage.ColorComboBox.SelectedItem.ShouldBe("Red");
    }

    [Test]
    public void ShouldSelectItemByPartialName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        ComboBoxPage comboBoxPage = new HomePage(app).NavigateTo<ComboBoxPage>("ComboBox");

        // Act
        comboBoxPage.SelectColorByPartialName("Yell");

        // Assert
        comboBoxPage.ColorComboBox.SelectedItem.ShouldBe("Yellow");
    }
}