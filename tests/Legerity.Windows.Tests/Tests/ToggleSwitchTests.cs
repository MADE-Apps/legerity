using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

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
        ToggleSwitchPage toggleSwitchPage = this.StartAndNavigateToPage();

        // Act
        toggleSwitchPage.ToggleSwitchOn();

        // Assert
        toggleSwitchPage.SimpleToggleSwitch.IsOn.ShouldBeTrue();
    }

    [Test]
    public void ShouldKeepToggledOnIfToggledOn()
    {
        // Arrange
        ToggleSwitchPage toggleSwitchPage = this.StartAndNavigateToPage().ToggleSwitchOn();

        // Act
        toggleSwitchPage.ToggleSwitchOn();

        // Assert
        toggleSwitchPage.SimpleToggleSwitch.IsOn.ShouldBeTrue();
    }

    [Test]
    public void ShouldToggleOff()
    {
        // Arrange
        ToggleSwitchPage toggleSwitchPage = this.StartAndNavigateToPage().ToggleSwitchOn();

        // Act
        toggleSwitchPage.ToggleSwitchOff();

        // Assert
        toggleSwitchPage.SimpleToggleSwitch.IsOn.ShouldBeFalse();
    }

    [Test]
    public void ShouldKeepToggledOffIfToggledOff()
    {
        // Arrange
        ToggleSwitchPage toggleSwitchPage = this.StartAndNavigateToPage().ToggleSwitchOff();

        // Act
        toggleSwitchPage.ToggleSwitchOff();

        // Assert
        toggleSwitchPage.SimpleToggleSwitch.IsOn.ShouldBeFalse();
    }

    private ToggleSwitchPage StartAndNavigateToPage()
    {
        WebDriver app = this.StartApp();
        return new HomePage(app).NavigateTo<ToggleSwitchPage>("ToggleSwitch");
    }
}