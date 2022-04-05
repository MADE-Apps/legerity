namespace Legerity.IOS
{
    using OpenQA.Selenium;

    /// <summary>
    /// Defines a collection of extra locator constraints for <see cref="By"/>.
    /// </summary>
    public static class IOSByExtras
    {
        /// <summary>
        /// Gets a mechanism to find elements by the label.
        /// </summary>
        /// <param name="label">The label to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By Label(string label)
        {
            return By.XPath($".//*[@label='{label}']");
        }

        /// <summary>
        /// Gets a mechanism to find elements by a partial label.
        /// </summary>
        /// <param name="label">The label to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By PartialLabel(string label)
        {
            return By.XPath($".//*[contains(@label,'{label}')]");
        }

        /// <summary>
        /// Gets a mechanism to find elements by the value.
        /// </summary>
        /// <param name="value">The value to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By Value(string value)
        {
            return By.XPath($".//*[@value='{value}']");
        }

        /// <summary>
        /// Gets a mechanism to find elements by a partial value.
        /// </summary>
        /// <param name="value">The value to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By PartialValue(string value)
        {
            return By.XPath($".//*[contains(@value,'{value}')]");
        }
    }
}
