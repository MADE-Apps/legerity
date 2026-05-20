// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;

namespace Legerity.Windows.Extensions;
/// <summary>
/// Defines Windows-specific fluent chaining extensions for <see cref="By"/> locators and <see cref="ByBuilder"/>.
/// </summary>
/// <example>
/// <code>
/// // Shortcut
/// By.ClassName("ListView").WithAutomationId("ItemRow")
///
/// // Builder
/// By.ClassName("ListView").ThenFind(by => by.HasAutomationId("ItemRow"))
/// By.TagName("Window").That(by => by.HasAutomationId("MainWindow"))
/// </code>
/// </example>
public static class WindowsByExtensions
{
    /// <summary>
    /// Adds an AutomationId constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="automationId">The AutomationId to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the AutomationId.</returns>
    public static By WithAutomationId(this By by, string automationId)
    {
        return new ByAll(by, WindowsByExtras.AutomationId(automationId));
    }

    /// <summary>
    /// Finds child elements with the specified AutomationId within elements matched by the base locator.
    /// </summary>
    /// <param name="by">The parent locator.</param>
    /// <param name="automationId">The AutomationId of the child element to find.</param>
    /// <returns>A <see cref="ByNested"/> locator that scopes the AutomationId search within matched parents.</returns>
    public static By ThenFindByAutomationId(this By by, string automationId)
    {
        return new ByNested(by, WindowsByExtras.AutomationId(automationId));
    }

    /// <summary>
    /// Adds an AutomationId constraint to the builder.
    /// </summary>
    /// <param name="builder">The builder instance.</param>
    /// <param name="automationId">The AutomationId to match.</param>
    /// <returns>The builder instance for chaining.</returns>
    public static ByBuilder HasAutomationId(this ByBuilder builder, string automationId)
    {
        return builder.Matching(WindowsByExtras.AutomationId(automationId));
    }
}