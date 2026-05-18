using System.Collections.ObjectModel;
using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

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
        WebDriver app = this.StartApp();
        GridViewPage gridViewPage = new HomePage(app).NavigateTo<GridViewPage>("GridView");

        // Act
        ReadOnlyCollection<AppiumElement> items = gridViewPage.BasicGridView.Items;

        // Assert
        items.Count.ShouldBe(8);
    }

    [Test]
    public void ShouldClickItemByName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        GridViewPage gridViewPage = new HomePage(app).NavigateTo<GridViewPage>("GridView");
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
        WebDriver app = this.StartApp();
        GridViewPage gridViewPage = new HomePage(app).NavigateTo<GridViewPage>("GridView");
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
        WebDriver app = this.StartApp();
        GridViewPage gridViewPage = new HomePage(app).NavigateTo<GridViewPage>("GridView");
        const int expected = 2;

        // Act
        gridViewPage.ClickBasicGridViewItemByIndex(expected);

        // Assert
        gridViewPage.BasicGridView.SelectedIndex.ShouldBe(expected);
    }
}