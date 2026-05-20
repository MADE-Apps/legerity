using Legerity.Windows.Extensions;
using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
internal class ListBoxTests : BaseTestClass
{
    public ListBoxTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldClickItem()
    {
        // Arrange
        WebDriver app = this.StartApp();
        ListBoxPage listBoxPage = new HomePage(app).NavigateTo<ListBoxPage>("ListBox");

        // Act
        listBoxPage.ClickColorItem("Red");

        // Assert
        listBoxPage.ColorListBox.SelectedItem.VerifyNameOrAutomationIdEquals("Red").ShouldBeTrue();
    }

    [Test]
    public void ShouldClickItemByPartialName()
    {
        // Arrange
        WebDriver app = this.StartApp();
        ListBoxPage listBoxPage = new HomePage(app).NavigateTo<ListBoxPage>("ListBox");

        // Act
        listBoxPage.ClickColorItemByPartialName("Gre");

        // Assert
        listBoxPage.ColorListBox.SelectedItem.VerifyNameOrAutomationIdEquals("Green").ShouldBeTrue();
    }
}