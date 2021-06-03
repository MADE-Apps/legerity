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

        /// <summary>
        /// Finds the first element in the page that matches the specified text.
        /// </summary>
        /// <param name="driver">The remote web driver.</param>
        /// <param name="text">The text to find.</param>
        /// <returns>A <see cref="IWebElement"/>.</returns>
        public static IWebElement FindElementByText(this RemoteWebDriver driver, string text)
        {
            return driver.FindElement(ByExtras.Text(text));
        }

        /// <summary>
        /// Finds all the elements in the page that matches the specified text.
        /// </summary>
        /// <param name="driver">The remote web driver.</param>
        /// <param name="text">The text to find.</param>
        /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByText(this RemoteWebDriver driver, string text)
        {
            return driver.FindElements(ByExtras.Text(text));
        }

        /// <summary>
        /// Finds the first element in the page that matches the specified text partially.
        /// </summary>
        /// <param name="driver">The remote web driver.</param>
        /// <param name="text">The partial text to find.</param>
        /// <returns>A <see cref="IWebElement"/>.</returns>
        public static IWebElement FindElementByPartialText(this RemoteWebDriver driver, string text)
        {
            return driver.FindElement(ByExtras.PartialText(text));
        }

        /// <summary>
        /// Finds all the elements in the page that matches the specified text partially.
        /// </summary>
        /// <param name="driver">The remote web driver.</param>
        /// <param name="text">The partial text to find.</param>
        /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByPartialText(this RemoteWebDriver driver, string text)
        {
            return driver.FindElements(ByExtras.PartialText(text));
        }
    }
}