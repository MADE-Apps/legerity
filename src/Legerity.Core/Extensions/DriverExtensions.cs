namespace Legerity.Extensions
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Defines a collection of extensions for a driver.
    /// </summary>
    public static class DriverExtensions
    {
        /// <summary>
        /// Finds the first element in the page that matches the <see cref="By" /> locator.
        /// </summary>
        /// <param name="driver">The remote web driver.</param>
        /// <param name="locator">The locator to find the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public static RemoteWebElement FindWebElement(this RemoteWebDriver driver, By locator)
        {
            return driver.FindElement(locator) as RemoteWebElement;
        }

        /// <summary>
        /// Finds all the elements in the page that matches the <see cref="By" /> locator.
        /// </summary>
        /// <param name="driver">The remote web driver.</param>
        /// <param name="locator">The locator to find the elements.</param>
        /// <returns>A readonly collection of <see cref="RemoteWebElement"/>.</returns>
        public static ReadOnlyCollection<RemoteWebElement> FindWebElements(this RemoteWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Cast<RemoteWebElement>().ToList().AsReadOnly();
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

        /// <summary>
        /// Retrieves all elements that can be located by the driver in the page.
        /// </summary>
        /// <param name="driver">The remote web driver.</param>
        /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
        public static ReadOnlyCollection<IWebElement> GetAllElements(this RemoteWebDriver driver)
        {
            return driver.FindElements(By.XPath("//*"));
        }

        /// <summary>
        /// Waits until a specified driver condition is met, with an optional timeout.
        /// </summary>
        /// <param name="appDriver">The driver to wait on.</param>
        /// <param name="condition">The condition of the element to wait on.</param>
        /// <param name="timeout">The optional timeout wait on the condition being true.</param>
        /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
        /// <exception cref="WebDriverException">Thrown if the condition is not met in the allocated timeout period.</exception>
        public static void WaitUntil(this IWebDriver appDriver, Func<IWebDriver, bool> condition, TimeSpan? timeout = default, int retries = 0)
        {
            try
            {
                new WebDriverWait(appDriver, timeout ?? TimeSpan.Zero).Until(condition);
            }
            catch (WebDriverException)
            {
                if (retries <= 0)
                {
                    throw;
                }

                WaitUntil(appDriver, condition, timeout, retries - 1);
            }
        }
    }
}