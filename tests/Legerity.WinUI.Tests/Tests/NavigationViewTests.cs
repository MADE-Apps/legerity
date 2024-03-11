namespace Legerity.WinUI.Tests.Tests;

using Windows.Extensions;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class NavigationViewTests : BaseTestClass
{
    public NavigationViewTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldClickMenuOption()
    {
        // Arrange
        NavigationViewPage navigationViewPage = this.StartAndNavigateToPage();

        // Act
        navigationViewPage.SelectNavigationViewMenuOption("Menu Item2");

        // Assert
        navigationViewPage.NavigationView.SelectedMenuItem.Element.VerifyNameOrAutomationIdEquals("Menu Item2").ShouldBeTrue();
    }

    [Test]
    public void ShouldClickMenuOptionByPartialName()
    {
        // Arrange
        NavigationViewPage navigationViewPage = this.StartAndNavigateToPage();

        // Act
        navigationViewPage.SelectNavigationViewMenuOptionByPartialName("Item2");

        // Assert
        navigationViewPage.NavigationView.SelectedMenuItem.Element.VerifyNameOrAutomationIdEquals("Menu Item2").ShouldBeTrue();
    }

    [Test]
    public void ShouldOpenSettings()
    {
        // Arrange
        NavigationViewPage navigationViewPage = this.StartAndNavigateToPage();

        // Act
        navigationViewPage.OpenNavigationViewSettings();

        // Assert
        navigationViewPage.NavigationView.SettingsMenuItem.IsSelected().ShouldBeTrue();
    }

    [Test]
    public void ShouldOpenPane()
    {
        // Arrange
        NavigationViewPage navigationViewPage = this.StartAndNavigateToPage().CloseNavigationView();

        // Act
        navigationViewPage.OpenNavigationView();

        // Assert
        navigationViewPage.NavigationView.IsPaneOpen.ShouldBeTrue();
    }

    [Test]
    public void ShouldKeepPaneOpenIfOpenPane()
    {
        // Arrange
        NavigationViewPage navigationViewPage = this.StartAndNavigateToPage().CloseNavigationView().OpenNavigationView();

        // Act
        navigationViewPage.OpenNavigationView();

        // Assert
        navigationViewPage.NavigationView.IsPaneOpen.ShouldBeTrue();
    }

    [Test]
    public void ShouldClosePane()
    {
        // Arrange
        NavigationViewPage navigationViewPage = this.StartAndNavigateToPage().OpenNavigationView();

        // Act
        navigationViewPage.CloseNavigationView();

        // Assert
        navigationViewPage.NavigationView.IsPaneOpen.ShouldBeFalse();
    }

    [Test]
    public void ShouldKeepPaneClosedIfClosePane()
    {
        // Arrange
        NavigationViewPage navigationViewPage = this.StartAndNavigateToPage().OpenNavigationView().CloseNavigationView();

        // Act
        navigationViewPage.CloseNavigationView();

        // Assert
        navigationViewPage.NavigationView.IsPaneOpen.ShouldBeFalse();
    }

    private NavigationViewPage StartAndNavigateToPage()
    {
        WebDriver app = this.StartApp();
        return new HomePage(app).NavigateTo<NavigationViewPage>("NavigationView");
    }
}