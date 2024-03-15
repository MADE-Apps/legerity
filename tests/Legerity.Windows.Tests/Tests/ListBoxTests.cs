namespace Legerity.Windows.Tests.Tests;

using Extensions;
using Pages;
using Shouldly;

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
        var app = StartApp();
        var listBoxPage = new HomePage(app).NavigateTo<ListBoxPage>("ListBox");

        // Act
        listBoxPage.ClickColorItem("Red");

        // Assert
        listBoxPage.ColorListBox.SelectedItem.VerifyNameOrAutomationIdEquals("Red").ShouldBeTrue();
    }

    [Test]
    public void ShouldClickItemByPartialName()
    {
        // Arrange
        var app = StartApp();
        var listBoxPage = new HomePage(app).NavigateTo<ListBoxPage>("ListBox");

        // Act
        listBoxPage.ClickColorItemByPartialName("Gre");

        // Assert
        listBoxPage.ColorListBox.SelectedItem.VerifyNameOrAutomationIdEquals("Green").ShouldBeTrue();
    }
}
