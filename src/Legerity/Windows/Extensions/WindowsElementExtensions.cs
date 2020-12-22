namespace Legerity.Windows.Extensions
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a collection of extensions for <see cref="WindowsElement"/> objects.
    /// </summary>
    public static class WindowsElementExtensions
    {
        /// <summary>
        /// Finds an element within the <paramref name="driver"/> with the given <paramref name="automationId"/>.
        /// </summary>
        /// <param name="driver">The <see cref="WindowsDriver{TElement}"/> to search.</param>
        /// <param name="automationId">The automation ID associated with the element to locate.</param>
        /// <returns>The located <typeparamref name="TElement"/>.</returns>
        public static TElement FindElementByAutomationId<TElement>(this WindowsDriver<TElement> driver, string automationId) where TElement : IWebElement
        {
            return driver.FindElement(ByExtensions.AutomationId(automationId));
        }

        /// <summary>
        /// Finds an element within the <paramref name="element"/> with the given <paramref name="automationId"/>.
        /// </summary>
        /// <param name="element">The element to search.</param>
        /// <param name="automationId">The automation ID associated with the element to locate.</param>
        /// <returns>The located <see cref="AppiumWebElement"/>.</returns>
        public static AppiumWebElement FindElementByAutomationId(this WindowsElement element, string automationId)
        {
            return element.FindElement(ByExtensions.AutomationId(automationId));
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
        public static bool VerifyNameOrAutomationIdEquals(this AppiumWebElement element, string compare)
        {
            string name = element.GetAttribute("Name");
            string automationId = element.GetAttribute("AutomationId");

            return string.Equals(compare, name, StringComparison.CurrentCultureIgnoreCase) || string.Equals(
                       compare,
                       automationId,
                       StringComparison.CurrentCultureIgnoreCase);
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
            string name = element.GetAttribute("Name");
            string automationId = element.GetAttribute("AutomationId");

            return string.Equals(compare, name, StringComparison.CurrentCultureIgnoreCase) || string.Equals(
                       compare,
                       automationId,
                       StringComparison.CurrentCultureIgnoreCase);
        }
    }
}