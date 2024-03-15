namespace Legerity.Windows.Extensions;

using System;
using System.Globalization;
using Legerity.Extensions;

/// <summary>
/// Defines a collection of extensions for <see cref="WebElement"/> objects.
/// </summary>
public static class WindowsElementExtensions
{
    /// <summary>
    /// Finds an element within the <paramref name="driver"/> with the given <paramref name="automationId"/>.
    /// </summary>
    /// <param name="driver">The <see cref="WindowsDriver"/> to search.</param>
    /// <param name="automationId">The automation ID associated with the element to locate.</param>
    /// <returns>The located <see cref="WebElement"/>.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="automationId"/> is null.</exception>
    public static WebElement FindElementByAutomationId(
        this WindowsDriver driver,
        string automationId)
    {
        return driver.FindElement(WindowsByExtras.AutomationId(automationId));
    }

    /// <summary>
    /// Finds an element within the <paramref name="element"/> with the given <paramref name="automationId"/>.
    /// </summary>
    /// <param name="element">The element to search.</param>
    /// <param name="automationId">The automation ID associated with the element to locate.</param>
    /// <returns>The located <see cref="WebElement"/>.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="automationId"/> is null.</exception>
    public static WebElement FindElementByAutomationId(this WebElement element, string automationId)
    {
        return element.FindElement(WindowsByExtras.AutomationId(automationId)) as WebElement;
    }

    /// <summary>
    /// Verifies the elements name or AutomationId based on the given compare.
    /// </summary>
    /// <param name="element">
    /// The element to verify.
    /// </param>
    /// <param name="compare">
    /// The value to verify is the name or AutomationId.
    /// </param>
    /// <returns>
    /// True if the element's name or AutomationId matches; otherwise, false.
    /// </returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static bool VerifyNameOrAutomationIdEquals(this WebElement element, string compare)
    {
        var name = element.GetName();
        var automationId = element.GetAutomationId();

        return string.Equals(compare, name, StringComparison.CurrentCultureIgnoreCase) || string.Equals(
            compare,
            automationId,
            StringComparison.CurrentCultureIgnoreCase);
    }
    
    /// <summary>
    /// Verifies the elements name or AutomationId based on the given partial compare.
    /// </summary>
    /// <param name="element">
    /// The element to verify.
    /// </param>
    /// <param name="partialCompare">The partial value to verify is the name or AutomationId.</param>
    /// <returns>
    /// True if the element's name or AutomationId matches; otherwise, false.
    /// </returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static bool VerifyNameOrAutomationIdContains(this WebElement element, string partialCompare)
    {
        var name = element.GetName();
        var automationId = element.GetAutomationId();

        return name.Contains(partialCompare, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase) ||
               automationId.Contains(partialCompare, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase);
    }
}
