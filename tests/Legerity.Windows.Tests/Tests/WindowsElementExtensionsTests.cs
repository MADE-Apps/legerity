namespace Legerity.Windows.Tests.Tests;

using Elements.Core;
using Extensions;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class WindowsElementExtensionsTests : BaseTestClass
{
    public WindowsElementExtensionsTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldFindWindowsDriverElementByAutomationId()
    {
        // Arrange
        var app = this.StartWindowsApp();

        // Act
        var element = app.FindElementByAutomationId("headerImage");

        // Assert
        element.ShouldNotBeNull();
    }

    [Test]
    public void ShouldFindNestedWrapperElementByAutomationId()
    {
        // Arrange
        var app = this.StartWindowsApp();
        var itemGridView = app.FindElement(WindowsByExtras.AutomationId("ItemGridView"));

        // Act
        var element = itemGridView.FindElementByAutomationId("headerImage");

        // Assert
        element.ShouldNotBeNull();
    }

    [Test]
    public void ShouldTryWaitUntilWrapperElementConditionIsMet()
    {
        // Arrange
        var app = this.StartWindowsApp();
        GridView itemGridView = app.FindElement(WindowsByExtras.AutomationId("ItemGridView"));

        // Act
        var success = itemGridView.TryWaitUntil(gridView => gridView.IsVisible);

        // Assert
        success.ShouldBeTrue();
    }
}
