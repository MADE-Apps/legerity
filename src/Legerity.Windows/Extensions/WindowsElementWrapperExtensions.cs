namespace Legerity.Windows.Extensions;

using System;
using Legerity.Windows.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

/// <summary>
/// Defines a collection of extensions for <see cref="WindowsElementWrapper"/> objects.
/// </summary>
public static class WindowsElementWrapperExtensions
{
    /// <summary>
    /// Attempts to wait until a specified element condition is met, with an optional timeout.
    /// </summary>
    /// <param name="element">The element to wait on.</param>
    /// <param name="condition">The condition of the element to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <param name="exceptionHandler">The optional exception handler thrown if an error occurs as a result of timeout.</param>
    /// <typeparam name="TElementWrapper">The type of <see cref="WindowsElementWrapper"/>.</typeparam>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>Whether the wait was a success.</returns>
    /// <exception cref="Exception">Thrown when the <paramref name="exceptionHandler"/> callback throws an exception.</exception>
    public static bool TryWaitUntil<TElementWrapper, TResult>(
        this TElementWrapper element,
        Func<TElementWrapper, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0,
        Action<Exception> exceptionHandler = null)
        where TElementWrapper : WindowsElementWrapper
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
    /// <typeparam name="TElementWrapper">The type of <see cref="WindowsElementWrapper"/>.</typeparam>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>The <typeparamref name="TResult"/> of the wait until operation.</returns>
    /// <exception cref="WebDriverException">Thrown when the condition is not met in the allocated timeout period.</exception>
    /// <exception cref="Exception">Thrown when the <paramref name="condition"/> callback throws an exception.</exception>
    public static TResult WaitUntil<TElementWrapper, TResult>(
        this TElementWrapper element,
        Func<TElementWrapper, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0)
        where TElementWrapper : WindowsElementWrapper
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