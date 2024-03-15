namespace Legerity.Windows.Tests.Tests;

using Pages;
using Shouldly;

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
        var app = StartApp();
        var comboBoxPage = new HomePage(app).NavigateTo<ComboBoxPage>("ComboBox");

        // Act
        comboBoxPage.SelectColorByName("Red");

        // Assert
        comboBoxPage.ColorComboBox.SelectedItem.ShouldBe("Red");
    }

    [Test]
    public void ShouldSelectItemByPartialName()
    {
        // Arrange
        var app = StartApp();
        var comboBoxPage = new HomePage(app).NavigateTo<ComboBoxPage>("ComboBox");

        // Act
        comboBoxPage.SelectColorByPartialName("Yell");

        // Assert
        comboBoxPage.ColorComboBox.SelectedItem.ShouldBe("Yellow");
    }
}
