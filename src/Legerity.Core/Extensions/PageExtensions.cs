namespace Legerity.Extensions
{
    using System;
    using System.Collections.ObjectModel;
    using Legerity.Pages;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Defines a collection of extensions for page objects.
    /// </summary>
    public static class PageExtensions
    {
        /// <summary>
        /// Waits until a specified page condition is met, with an optional timeout.
        /// </summary>
        /// <param name="page">The page to wait on.</param>
        /// <param name="condition">The condition of the page to wait on.</param>
        /// <param name="timeout">The optional timeout wait on the condition being true.</param>
        /// <typeparam name="TPage">The type of <see cref="BasePage"/>.</typeparam>
        /// <returns>The instance of the page.</returns>
        public static TPage WaitUntil<TPage>(this TPage page, Func<TPage, bool> condition, TimeSpan? timeout = default)
            where TPage : BasePage
        {
            new WebDriverWait(AppManager.App, timeout ?? TimeSpan.Zero).Until(driver =>
            {
                try
                {
                    return condition(page);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });

            return page;
        }
    }
}
