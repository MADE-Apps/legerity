namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class CheckBoxTests : BaseTestClass
{
    public CheckBoxTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldCheckOn()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        CheckBoxPage checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox");

        // Act
        checkBoxPage.CheckOnTwoStateCheckBox();

        // Assert
        checkBoxPage.TwoStateCheckBox.IsChecked.ShouldBeTrue();
    }

    [Test]
    public void ShouldKeepCheckedIfCheckOn()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        CheckBoxPage checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox").CheckOnTwoStateCheckBox();

        // Act
        checkBoxPage.CheckOnTwoStateCheckBox();

        // Assert
        checkBoxPage.TwoStateCheckBox.IsChecked.ShouldBeTrue();
    }

    [Test]
    public void ShouldCheckOff()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        CheckBoxPage checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox").CheckOnTwoStateCheckBox();

        // Act
        checkBoxPage.CheckOffTwoStateCheckBox();

        // Assert
        checkBoxPage.TwoStateCheckBox.IsChecked.ShouldBeFalse();
    }

    [Test]
    public void ShouldKeepCheckedOffIfCheckOff()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        CheckBoxPage checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox").CheckOffTwoStateCheckBox();

        // Act
        checkBoxPage.CheckOffTwoStateCheckBox();

        // Assert
        checkBoxPage.TwoStateCheckBox.IsChecked.ShouldBeFalse();
    }

    [Test]
    public void ShouldSetIndeterminateStateIfSupported()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        CheckBoxPage checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox");

        // Act
        checkBoxPage.CheckIndeterminateThreeStateCheckBox();

        // Assert
        checkBoxPage.ThreeStateCheckBox.IsIndeterminate.ShouldBeTrue();
    }
}