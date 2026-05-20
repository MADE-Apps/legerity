// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;

namespace Legerity.Windows;
/// <summary>
/// Defines a collection of extra locator constraints for <see cref="By"/>.
/// </summary>
public static class WindowsByExtras
{
    /// <summary>
    /// Gets a mechanism to find elements by the Windows Automation ID.
    /// </summary>
    /// <param name="automationId">The automation ID to find.</param>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="automationId"/> is null.
    /// </exception>
    public static By AutomationId(string automationId)
    {
        if (automationId == null)
        {
            throw new ArgumentNullException(
                nameof(automationId),
                "Cannot find elements with a null automation ID attribute");
        }

        return By.XPath($".//*[@AutomationId='{automationId}']");
    }
}