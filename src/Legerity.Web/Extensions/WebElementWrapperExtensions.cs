namespace Legerity.Web.Extensions;

using System;
using Legerity.Web.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

/// <summary>
/// Defines a collection of extensions for <see cref="WebElementWrapper"/> objects.
/// </summary>
public static class WebElementWrapperExtensions
{
    /// <summary>
    /// Attempts to wait until a specified element condition is met, with an optional timeout.
    /// </summary>
    /// <param name="element">The element to wait on.</param>
    /// <param name="condition">The condition of the element to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <param name="exceptionHandler">The optional exception handler thrown if an error occurs as a result of timeout.</param>
    /// <typeparam name="TElementWrapper">The type of <see cref="WebElementWrapper"/>.</typeparam>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>Whether the wait was a success.</returns>
    public static bool TryWaitUntil<TElementWrapper, TResult>(
        this TElementWrapper element,
        Func<TElementWrapper, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0,
        Action<Exception> exceptionHandler = null)
        where TElementWrapper : WebElementWrapper
    {
        try
        {
            WaitUntil(element, condition, timeout, retries);
        }
        catch (Exception ex)
        {
            exceptionHandler?.Invoke(ex);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Waits until a specified element condition is met, with an optional timeout.
    /// </summary>
    /// <param name="element">The element to wait on.</param>
    /// <param name="condition">The condition of the element to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <typeparam name="TElementWrapper">The type of <see cref="WebElementWrapper"/>.</typeparam>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>The <typeparamref name="TResult"/> of the wait until operation.</returns>
    /// <exception cref="WebDriverException">Thrown if the condition is not met in the allocated timeout period.</exception>
    public static TResult WaitUntil<TElementWrapper, TResult>(
        this TElementWrapper element,
        Func<TElementWrapper, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0)
        where TElementWrapper : WebElementWrapper
    {
        try
        {
            return new WebDriverWait(element.ElementDriver, timeout ?? TimeSpan.Zero).Until(_ =>
            {
                try
                {
                    return condition(element);
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

            return WaitUntil(element, condition, timeout, retries - 1);
        }
    }
}