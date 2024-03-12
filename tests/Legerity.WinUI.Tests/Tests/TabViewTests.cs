namespace Legerity.WinUI.Tests.Tests;

using Windows.Extensions;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class TabViewTests : BaseTestClass
{
    public TabViewTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSelectTabViewItem()
    {
        // Arrange
        var app = StartApp();
        var tabViewPage = new HomePage(app).NavigateTo<TabViewPage>("TabView");

        // Act
        tabViewPage.SelectTab("Document 1");

        // Assert
        tabViewPage.TabView.SelectedItem.VerifyNameOrAutomationIdContains("Document 1").ShouldBeTrue();
    }

    [Test]
    public void ShouldSelectTabViewItemByPartialName()
    {
        // Arrange
        var app = StartApp();
        var tabViewPage = new HomePage(app).NavigateTo<TabViewPage>("TabView");

        // Act
        tabViewPage.SelectTabByPartialName("1");

        // Assert
        tabViewPage.TabView.SelectedItem.VerifyNameOrAutomationIdContains("Document 1").ShouldBeTrue();
    }
}
