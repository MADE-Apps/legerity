namespace Legerity.Windows.Tests.Tests;

using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class ToggleSwitchTests : BaseTestClass
{
    public ToggleSwitchTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldToggleOn()
    {
        // Arrange
        var toggleSwitchPage = StartAndNavigateToPage();

        // Act
        toggleSwitchPage.ToggleSwitchOn();

        // Assert
        toggleSwitchPage.SimpleToggleSwitch.IsOn.ShouldBeTrue();
    }

    [Test]
    public void ShouldKeepToggledOnIfToggledOn()
    {
        // Arrange
        var toggleSwitchPage = StartAndNavigateToPage().ToggleSwitchOn();

        // Act
        toggleSwitchPage.ToggleSwitchOn();

        // Assert
        toggleSwitchPage.SimpleToggleSwitch.IsOn.ShouldBeTrue();
    }

    [Test]
    public void ShouldToggleOff()
    {
        // Arrange
        var toggleSwitchPage = StartAndNavigateToPage().ToggleSwitchOn();

        // Act
        toggleSwitchPage.ToggleSwitchOff();

        // Assert
        toggleSwitchPage.SimpleToggleSwitch.IsOn.ShouldBeFalse();
    }

    [Test]
    public void ShouldKeepToggledOffIfToggledOff()
    {
        // Arrange
        var toggleSwitchPage = StartAndNavigateToPage().ToggleSwitchOff();

        // Act
        toggleSwitchPage.ToggleSwitchOff();

        // Assert
        toggleSwitchPage.SimpleToggleSwitch.IsOn.ShouldBeFalse();
    }

    private ToggleSwitchPage StartAndNavigateToPage()
    {
        var app = StartApp();
        return new HomePage(app).NavigateTo<ToggleSwitchPage>("ToggleSwitch");
    }
}
