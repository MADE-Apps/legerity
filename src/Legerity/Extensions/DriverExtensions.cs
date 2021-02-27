namespace Legerity.Extensions
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a collection of extensions for a driver.
    /// </summary>
    public static class DriverExtensions
    {
        /// <summary>
        /// Finds the first element in the page that matches the <see cref="By" /> query.
        /// </summary>
        /// <param name="driver">The remote web driver.</param>
        /// <param name="by">The query to find the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public static RemoteWebElement FindWebElement(this RemoteWebDriver driver, By by)
        {
            return driver.FindElement(by) as RemoteWebElement;
        }

        /// <summary>
        /// Finds all the elements in the page that matches the <see cref="By" /> query.
        /// </summary>
        /// <param name="driver">The remote web driver.</param>
        /// <param name="by">The query to find the elements.</param>
        /// <returns>A readonly collection of <see cref="RemoteWebElement"/>.</returns>
        public static ReadOnlyCollection<RemoteWebElement> FindWebElements(this RemoteWebDriver driver, By by)
        {
            return driver.FindElements(by).Cast<RemoteWebElement>().ToList().AsReadOnly();
        }
    }
}