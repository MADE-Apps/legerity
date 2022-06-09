namespace Legerity.Extensions
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Defines a collection of extensions for <see cref="IElementWrapper{TElement}"/> objects.
    /// </summary>
    public static class ElementWrapperExtensions
    {
        /// <summary>
        /// Determines the bounding rectangle for the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="IWebElement"/>.
        /// </typeparam>
        /// <param name="element">The element to determine the rect for.</param>
        /// <returns>The elements bounding rectangle.</returns>
        public static Rectangle GetBoundingRect<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return element.Element.GetBoundingRect();
        }

        /// <summary>
        /// Finds the first element in the given element that matches the <see cref="By" /> locator.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="IWebElement"/>.
        /// </typeparam>
        /// <param name="element">The remote web element.</param>
        /// <param name="locator">The locator to find the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public static RemoteWebElement FindWebElement<TElement>(this IElementWrapper<TElement> element, By locator)
            where TElement : IWebElement
        {
            return element.Element.FindWebElement(locator);
        }

        /// <summary>
        /// Finds all the elements in the given element that matches the <see cref="By" /> locator.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="IWebElement"/>.
        /// </typeparam>
        /// <param name="element">The remote web element.</param>
        /// <param name="locator">The locator to find the elements.</param>
        /// <returns>A readonly collection of <see cref="RemoteWebElement"/>.</returns>
        public static ReadOnlyCollection<RemoteWebElement> FindWebElements<TElement>(this IElementWrapper<TElement> element, By locator)
            where TElement : IWebElement
        {
            return element.Element.FindWebElements(locator);
        }

        /// <summary>
        /// Finds the first element in the given element that matches the specified text.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="IWebElement"/>.
        /// </typeparam>
        /// <param name="element">The remote web element.</param>
        /// <param name="text">The text to find.</param>
        /// <returns>A <see cref="IWebElement"/>.</returns>
        public static IWebElement FindElementByText<TElement>(this IElementWrapper<TElement> element, string text)
            where TElement : IWebElement
        {
            return element.Element.FindElementByText(text);
        }

        /// <summary>
        /// Finds all the elements in the given element that matches the specified text.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="IWebElement"/>.
        /// </typeparam>
        /// <param name="element">The remote web element.</param>
        /// <param name="text">The text to find.</param>
        /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByText<TElement>(this IElementWrapper<TElement> element, string text)
            where TElement : IWebElement
        {
            return element.Element.FindElementsByText(text);
        }

        /// <summary>
        /// Finds the first element in the given element that matches the specified text partially.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="IWebElement"/>.
        /// </typeparam>
        /// <param name="element">The remote web element.</param>
        /// <param name="text">The partial text to find.</param>
        /// <returns>A <see cref="IWebElement"/>.</returns>
        public static IWebElement FindElementByPartialText<TElement>(this IElementWrapper<TElement> element, string text)
            where TElement : IWebElement
        {
            return element.Element.FindElementByPartialText(text);
        }

        /// <summary>
        /// Finds all the elements in the given element that matches the specified text partially.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="IWebElement"/>.
        /// </typeparam>
        /// <param name="element">The remote web element.</param>
        /// <param name="text">The partial text to find.</param>
        /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByPartialText<TElement>(this IElementWrapper<TElement> element, string text)
            where TElement : IWebElement
        {
            return element.Element.FindElementsByPartialText(text);
        }

        /// <summary>
        /// Retrieves all child elements that can be located by the driver for the given element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="IWebElement"/>.
        /// </typeparam>
        /// <param name="element">The remote web driver.</param>
        /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
        public static ReadOnlyCollection<IWebElement> GetAllChildElements<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return element.Element.GetAllChildElements();
        }

        /// <summary>
        /// Waits until a specified element condition is met, with an optional timeout.
        /// </summary>
        /// <param name="element">The element to wait on.</param>
        /// <param name="condition">The condition of the element to wait on.</param>
        /// <param name="timeout">The optional timeout wait on the condition being true.</param>
        /// <typeparam name="TElement">The type of <see cref="IWebElement"/>.</typeparam>
        public static void WaitUntil<TElement>(this IElementWrapper<TElement> element, Func<IElementWrapper<TElement>, bool> condition, TimeSpan? timeout = default)
            where TElement : IWebElement
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
