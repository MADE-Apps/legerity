namespace Legerity.Extensions;

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
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
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
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
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
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
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
    public static ReadOnlyCollection<IWebElement> FindElementsByPartialText(
        this RemoteWebDriver driver,
        string text)
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
    /// Retrieves all child elements that can be located by the driver in the page.
    /// </summary>
    /// <param name="driver">The remote web driver.</param>
    /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
    public static ReadOnlyCollection<IWebElement> GetAllChildElements(this RemoteWebDriver driver)
    {
        return driver.FindElements(By.XPath(".//*"));
    }

    /// <summary>
    /// Attempts to wait until a specified driver condition is met, with an optional timeout.
    /// </summary>
    /// <param name="appDriver">The driver to wait on.</param>
    /// <param name="condition">The condition of the element to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <param name="exceptionHandler">The optional exception handler thrown if an error occurs as a result of timeout.</param>
    /// <returns>Whether the wait was a success.</returns>
    /// <exception cref="Exception">Thrown when the <paramref name="exceptionHandler"/> callback throws an exception.</exception>
    public static bool TryWaitUntil(
        this IWebDriver appDriver,
        Func<IWebDriver, bool> condition,
        TimeSpan? timeout = default,
        int retries = 0,
        Action<Exception> exceptionHandler = null)
    {
        try
        {
            WaitUntil(appDriver, condition, timeout, retries);
        }
        catch (Exception ex)
        {
            exceptionHandler?.Invoke(ex);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Waits until a specified driver condition is met, with an optional timeout.
    /// </summary>
    /// <param name="appDriver">The driver to wait on.</param>
    /// <param name="condition">The condition of the element to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>The <typeparamref name="TResult"/> of the wait until operation.</returns>
    /// <exception cref="WebDriverException">Thrown when the condition is not met in the allocated timeout period.</exception>
    public static TResult WaitUntil<TResult>(
        this IWebDriver appDriver,
        Func<IWebDriver, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0)
    {
        try
        {
            return new WebDriverWait(appDriver, timeout ?? TimeSpan.Zero).Until(condition);
        }
        catch (WebDriverException)
        {
            if (retries <= 0)
            {
                throw;
            }

            return WaitUntil(appDriver, condition, timeout, retries - 1);
        }
    }
}