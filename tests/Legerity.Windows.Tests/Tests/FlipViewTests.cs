namespace Legerity.Windows.Tests.Tests;

using Legerity.Extensions;
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
        var app = StartApp();
        var flipViewPage = new HomePage(app).NavigateTo<FlipViewPage>("FlipView").SelectXamlFlipViewItemByIndex(1);
        var selectedItem = flipViewPage.XamlFlipView.SelectedIndex;
        var expected = selectedItem + 1;

        // Act
        flipViewPage.SelectNextXamlFlipViewItem();

        // Assert
        flipViewPage.XamlFlipView.SelectedIndex.ShouldBe(expected);
    }

    [Test]
    public void ShouldSelectPreviousItem()
    {
        // Arrange
        var app = StartApp();
        var flipViewPage = new HomePage(app).NavigateTo<FlipViewPage>("FlipView").SelectXamlFlipViewItemByIndex(1);
        var selectedItem = flipViewPage.XamlFlipView.SelectedIndex;
        var expected = selectedItem - 1;

        // Act
        flipViewPage.SelectPreviousXamlFlipViewItem();

        // Assert
        flipViewPage.XamlFlipView.SelectedIndex.ShouldBe(expected);
    }

    [Test]
    public void ShouldSelectItemByName()
    {
        // Arrange
        var app = StartApp();
        var flipViewPage = new HomePage(app).NavigateTo<FlipViewPage>("FlipView");
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
        var app = StartApp();
        var flipViewPage = new HomePage(app).NavigateTo<FlipViewPage>("FlipView");
        const int expected = 2;

        // Act
        flipViewPage.SelectXamlFlipViewItemByIndex(expected);

        // Assert
        flipViewPage.XamlFlipView.SelectedIndex.ShouldBe(expected);
    }
}
