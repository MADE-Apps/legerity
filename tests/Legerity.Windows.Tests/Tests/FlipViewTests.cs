namespace Legerity.Windows.Tests.Tests;

using Legerity.Extensions;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class FlipViewTests : BaseTestClass
{
    public FlipViewTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSelectNextItem()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        FlipViewPage flipViewPage = new HomePage(app).NavigateTo<FlipViewPage>("FlipView").SelectXamlFlipViewItemByIndex(1);
        int selectedItem = flipViewPage.XamlFlipView.SelectedIndex;
        int expected = selectedItem + 1;

        // Act
        flipViewPage.SelectNextXamlFlipViewItem();

        // Assert
        flipViewPage.XamlFlipView.SelectedIndex.ShouldBe(expected);
    }

    [Test]
    public void ShouldSelectPreviousItem()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        FlipViewPage flipViewPage = new HomePage(app).NavigateTo<FlipViewPage>("FlipView").SelectXamlFlipViewItemByIndex(1);
        int selectedItem = flipViewPage.XamlFlipView.SelectedIndex;
        int expected = selectedItem - 1;

        // Act
        flipViewPage.SelectPreviousXamlFlipViewItem();

        // Assert
        flipViewPage.XamlFlipView.SelectedIndex.ShouldBe(expected);
    }

    [Test]
    public void ShouldSelectItemByName()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        FlipViewPage flipViewPage = new HomePage(app).NavigateTo<FlipViewPage>("FlipView");
        const string expected = "Grapes";

        // Act
        flipViewPage.SelectXamlFlipViewItem(expected);

        // Assert
        flipViewPage.XamlFlipView.SelectedItem.GetName().ShouldBe(expected);
    }

    [Test]
    public void ShouldSelectItemByIndex()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();
        FlipViewPage flipViewPage = new HomePage(app).NavigateTo<FlipViewPage>("FlipView");
        const int expected = 2;

        // Act
        flipViewPage.SelectXamlFlipViewItemByIndex(expected);

        // Assert
        flipViewPage.XamlFlipView.SelectedIndex.ShouldBe(expected);
    }
}