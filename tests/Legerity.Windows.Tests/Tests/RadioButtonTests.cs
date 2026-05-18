using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

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
        WebDriver app = this.StartApp();
        RadioButtonPage radioButtonPage = new HomePage(app).NavigateTo<RadioButtonPage>("RadioButton");

        // Act
        radioButtonPage.ClickOptionOneRadioButton();

        // Assert
        radioButtonPage.OptionOneRadioButton.IsSelected.ShouldBeTrue();
        radioButtonPage.OptionTwoRadioButton.IsSelected.ShouldBeFalse();
    }
}