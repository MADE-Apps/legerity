namespace Legerity.Windows.Tests.Tests;

using Elements.Core;
using Extensions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
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
        WindowsDriver<WindowsElement> app = this.StartWindowsApp();

        // Act
        WindowsElement element = app.FindElementByAutomationId("headerImage");

        // Assert
        element.ShouldNotBeNull();
    }

    [Test]
    public void ShouldFindNestedWrapperElementByAutomationId()
    {
        // Arrange
        WindowsDriver<WindowsElement> app = this.StartWindowsApp();
        WindowsElement itemGridView = app.FindElement(WindowsByExtras.AutomationId("ItemGridView"));

        // Act
        AppiumWebElement element = itemGridView.FindElementByAutomationId("headerImage");

        // Assert
        element.ShouldNotBeNull();
    }

    [Test]
    public void ShouldTryWaitUntilWrapperElementConditionIsMet()
    {
        // Arrange
        WindowsDriver<WindowsElement> app = this.StartWindowsApp();
        GridView itemGridView = app.FindElement(WindowsByExtras.AutomationId("ItemGridView"));

        // Act
        bool success = itemGridView.TryWaitUntil(gridView => gridView.IsVisible);

        // Assert
        success.ShouldBeTrue();
    }
}