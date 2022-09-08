namespace Legerity.Windows.Extensions
{
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
        /// <param name="timeoutExceptionHandler">The optional exception handler thrown if an error occurs as a result of timeout.</param>
        /// <typeparam name="TElementWrapper">The type of <see cref="WindowsElementWrapper"/>.</typeparam>
        public static void TryWaitUntil<TElementWrapper>(
            this TElementWrapper element,
            Func<TElementWrapper, bool> condition,
            TimeSpan? timeout = default,
            Action<WebDriverTimeoutException> timeoutExceptionHandler = null)
            where TElementWrapper : WindowsElementWrapper
        {
            try
            {
                WaitUntil(element, condition, timeout);
            }
            catch (WebDriverTimeoutException ex)
            {
                timeoutExceptionHandler?.Invoke(ex);
            }
        }

        /// <summary>
        /// Waits until a specified element condition is met, with an optional timeout.
        /// </summary>
        /// <param name="element">The element to wait on.</param>
        /// <param name="condition">The condition of the element to wait on.</param>
        /// <param name="timeout">The optional timeout wait on the condition being true.</param>
        /// <typeparam name="TElementWrapper">The type of <see cref="WindowsElementWrapper"/>.</typeparam>
        public static void WaitUntil<TElementWrapper>(
            this TElementWrapper element,
            Func<TElementWrapper, bool> condition,
            TimeSpan? timeout = default)
            where TElementWrapper : WindowsElementWrapper
        {
            new WebDriverWait(element.ElementDriver, timeout ?? TimeSpan.Zero).Until(driver =>
            {
                try
                {
                    return condition(element);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }
    }
}