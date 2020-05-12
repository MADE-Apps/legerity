namespace Legerity.Windows.Extensions
{
    using System;

    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a collection of extensions for <see cref="WindowsElement"/> objects.
    /// </summary>
    public static class WindowsElementExtensions
    {
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
        public static bool VerifyNameOrAutomationIdEquals(this AppiumWebElement element, string compare)
        {
            return element.GetAttribute("Name").Equals(compare, StringComparison.CurrentCultureIgnoreCase) || element
                       .GetAttribute("AutomationId").Equals(compare, StringComparison.CurrentCultureIgnoreCase);
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
        public static bool VerifyNameOrAutomationIdEquals(this WindowsElement element, string compare)
        {
            return element.GetAttribute("Name").Equals(compare, StringComparison.CurrentCultureIgnoreCase) || element
                       .GetAttribute("AutomationId").Equals(compare, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}