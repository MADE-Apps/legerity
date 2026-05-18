
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using Shouldly;

namespace Legerity.Windows.Tests.Tests;

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
        WindowsDriver app = this.StartWindowsApp();

        // Act
        var element = app.FindElementByAutomationId("headerImage");

        // Assert
        element.ShouldNotBeNull();
    }

    [Test]
    public void ShouldFindNestedWrapperElementByAutomationId()
    {
        // Arrange
        WindowsDriver app = this.StartWindowsApp();
        AppiumElement itemGridView = app.FindElement(WindowsByExtras.AutomationId("ItemGridView"));

        // Act
        AppiumElement element = itemGridView.FindElementByAutomationId("headerImage");

        // Assert
        element.ShouldNotBeNull();
    }

    [Test]
    public void ShouldTryWaitUntilWrapperElementConditionIsMet()
    {
        // Arrange
        WindowsDriver app = this.StartWindowsApp();
        GridView itemGridView = app.FindElement(WindowsByExtras.AutomationId("ItemGridView"));

        // Act
        var success = itemGridView.TryWaitUntil(gridView => gridView.IsVisible);

        // Assert
        success.ShouldBeTrue();
    }
}