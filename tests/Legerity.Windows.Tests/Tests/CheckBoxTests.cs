namespace Legerity.Windows.Tests.Tests;

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
        var app = StartApp();
        var checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox");

        // Act
        checkBoxPage.CheckOnTwoStateCheckBox();

        // Assert
        checkBoxPage.TwoStateCheckBox.IsChecked.ShouldBeTrue();
    }

    [Test]
    public void ShouldKeepCheckedIfCheckOn()
    {
        // Arrange
        var app = StartApp();
        var checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox").CheckOnTwoStateCheckBox();

        // Act
        checkBoxPage.CheckOnTwoStateCheckBox();

        // Assert
        checkBoxPage.TwoStateCheckBox.IsChecked.ShouldBeTrue();
    }

    [Test]
    public void ShouldCheckOff()
    {
        // Arrange
        var app = StartApp();
        var checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox").CheckOnTwoStateCheckBox();

        // Act
        checkBoxPage.CheckOffTwoStateCheckBox();

        // Assert
        checkBoxPage.TwoStateCheckBox.IsChecked.ShouldBeFalse();
    }

    [Test]
    public void ShouldKeepCheckedOffIfCheckOff()
    {
        // Arrange
        var app = StartApp();
        var checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox").CheckOffTwoStateCheckBox();

        // Act
        checkBoxPage.CheckOffTwoStateCheckBox();

        // Assert
        checkBoxPage.TwoStateCheckBox.IsChecked.ShouldBeFalse();
    }

    [Test]
    public void ShouldSetIndeterminateStateIfSupported()
    {
        // Arrange
        var app = StartApp();
        var checkBoxPage = new HomePage(app).NavigateTo<CheckBoxPage>("CheckBox");

        // Act
        checkBoxPage.CheckIndeterminateThreeStateCheckBox();

        // Assert
        checkBoxPage.ThreeStateCheckBox.IsIndeterminate.ShouldBeTrue();
    }
}
