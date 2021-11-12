namespace Legerity.Windows.Extensions
{
    using System;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines a collection of extensions for the <see cref="By"/> class.
    /// </summary>
    public static class ByExtensions
    {
        /// <summary>
        /// Provides a locator for retrieving an element by a Windows AutomationId.
        /// </summary>
        /// <param name="automationId">
        /// The automation ID of the element to retrieve.
        /// </param>
        /// <returns>
        /// The <see cref="By"/> locator for the Windows element.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="automationId"/> is null.
        /// </exception>
        public static By AutomationId(string automationId)
        {
            if (automationId == null)
            {
                throw new ArgumentNullException(
                    nameof(automationId),
                    "Cannot find elements with a null automation id attribute.");
            }

            return By.XPath($".//*[@AutomationId='{automationId}']");
        }
    }
}