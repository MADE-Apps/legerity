namespace Legerity.Windows.Tests.Tests;

using System.Collections.ObjectModel;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class GridViewTests : BaseTestClass
{
    public GridViewTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldGetItems()
    {
        // Arrange
        var app = StartApp();
        var gridViewPage = new HomePage(app).NavigateTo<GridViewPage>("GridView");

        // Act
        var items = gridViewPage.BasicGridView.Items;

        // Assert
        items.Count.ShouldBe(8);
    }

    [Test]
    public void ShouldClickItemByName()
    {
        // Arrange
        var app = StartApp();
        var gridViewPage = new HomePage(app).NavigateTo<GridViewPage>("GridView");
        const string expected = "Item 2";

        // Act
        gridViewPage.ClickBasicGridViewItem(expected);

        // Assert
        gridViewPage.BasicGridView.SelectedItem.Text.ShouldBe(expected);
    }

    [Test]
    public void ShouldClickItemByPartialName()
    {
        // Arrange
        var app = StartApp();
        var gridViewPage = new HomePage(app).NavigateTo<GridViewPage>("GridView");
        const string expected = "Item 2";

        // Act
        gridViewPage.ClickBasicGridViewItemByPartialName("2");

        // Assert
        gridViewPage.BasicGridView.SelectedItem.Text.ShouldBe(expected);
    }

    [Test]
    public void ShouldClickItemByIndex()
    {
        // Arrange
        var app = StartApp();
        var gridViewPage = new HomePage(app).NavigateTo<GridViewPage>("GridView");
        const int expected = 2;

        // Act
        gridViewPage.ClickBasicGridViewItemByIndex(expected);

        // Assert
        gridViewPage.BasicGridView.SelectedIndex.ShouldBe(expected);
    }
}
