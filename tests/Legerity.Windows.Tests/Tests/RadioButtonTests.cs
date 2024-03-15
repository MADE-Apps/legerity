namespace Legerity.Windows.Tests.Tests;

using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class RadioButtonTests : BaseTestClass
{
    public RadioButtonTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSelectRadioButton()
    {
        // Arrange
        var app = StartApp();
        var radioButtonPage = new HomePage(app).NavigateTo<RadioButtonPage>("RadioButton");

        // Act
        radioButtonPage.ClickOptionOneRadioButton();

        // Assert
        radioButtonPage.OptionOneRadioButton.IsSelected.ShouldBeTrue();
        radioButtonPage.OptionTwoRadioButton.IsSelected.ShouldBeFalse();
    }
}
