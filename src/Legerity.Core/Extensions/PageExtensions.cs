namespace Legerity.Extensions;

using System;
using Legerity.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

/// <summary>
/// Defines a collection of extensions for page objects.
/// </summary>
public static class PageExtensions
{
    /// <summary>
    /// Attempts to wait until a specified page condition is met, with an optional timeout.
    /// </summary>
    /// <param name="page">The page to wait on.</param>
    /// <param name="condition">The condition of the page to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <param name="exceptionHandler">The optional exception handler thrown if an error occurs as a result of timeout.</param>
    /// <typeparam name="TPage">The type of <see cref="BasePage"/>.</typeparam>
    /// <returns>Whether the wait was a success and the instance of the page.</returns>
    public static (bool success, TPage page) TryWaitUntil<TPage>(
        this TPage page,
        Func<TPage, bool> condition,
        TimeSpan? timeout = default,
        int retries = 0,
        Action<Exception> exceptionHandler = null)
        where TPage : BasePage
    {
        try
        {
            WaitUntil(page, condition, timeout, retries);
        }
        catch (Exception ex)
        {
            exceptionHandler?.Invoke(ex);
            return (false, page);
        }

        return (true, page);
    }

    /// <summary>
    /// Waits until a specified page condition is met, with an optional timeout.
    /// </summary>
    /// <param name="page">The page to wait on.</param>
    /// <param name="condition">The condition of the page to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <typeparam name="TPage">The type of <see cref="BasePage"/>.</typeparam>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>The instance of the page.</returns>
    /// <exception cref="WebDriverException">Thrown if the condition is not met in the allocated timeout period.</exception>
    public static TPage WaitUntil<TPage, TResult>(
        this TPage page,
        Func<TPage, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0)
        where TPage : BasePage
    {
        try
        {
            new WebDriverWait(page.App, timeout ?? TimeSpan.Zero).Until(_ =>
            {
                try
                {
                    return condition(page);
                }
                catch (StaleElementReferenceException)
                {
                    return default;
                }
            });
        }
        catch (WebDriverException)
        {
            if (retries <= 0)
            {
                throw;
            }

            return WaitUntil(page, condition, timeout, retries - 1);
        }

        return page;
    }
}