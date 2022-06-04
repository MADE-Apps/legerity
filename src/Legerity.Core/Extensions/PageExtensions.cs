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
        /// Finds the first element in the given element that matches the <see cref="By" /> locator.
        /// </summary>
        /// <typeparam name="TPage">
        /// The type of <see cref="BasePage"/>.
        /// </typeparam>
        /// <param name="page">The page object.</param>
        /// <param name="locator">The locator to find the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public static RemoteWebElement FindWebElement<TPage>(this TPage page, By locator)
            where TPage : BasePage
        {
            return page.App.FindWebElement(locator);
        }

        /// <summary>
        /// Finds all the elements in the given element that matches the <see cref="By" /> locator.
        /// </summary>
        /// <typeparam name="TPage">
        /// The type of <see cref="BasePage"/>.
        /// </typeparam>
        /// <param name="page">The page object.</param>
        /// <param name="locator">The locator to find the elements.</param>
        /// <returns>A readonly collection of <see cref="RemoteWebElement"/>.</returns>
        public static ReadOnlyCollection<RemoteWebElement> FindWebElements<TPage>(this TPage page, By locator)
            where TPage : BasePage
        {
            return page.App.FindWebElements(locator);
        }

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
