namespace Legerity.Extensions;

using System;
using System.Collections.ObjectModel;
using System.Drawing;

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
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
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
    /// <returns>A <see cref="WebElement"/>.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static WebElement FindWebElement<TElement>(this IElementWrapper<TElement> element, By locator)
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
    /// <returns>A readonly collection of <see cref="WebElement"/>.</returns>
    public static ReadOnlyCollection<WebElement> FindWebElements<TElement>(
        this IElementWrapper<TElement> element, By locator)
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
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
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
    public static ReadOnlyCollection<IWebElement> FindElementsByText<TElement>(
        this IElementWrapper<TElement> element, string text)
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
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static IWebElement FindElementByPartialText<TElement>(
        this IElementWrapper<TElement> element,
        string text)
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
    public static ReadOnlyCollection<IWebElement> FindElementsByPartialText<TElement>(
        this IElementWrapper<TElement> element, string text)
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
    public static ReadOnlyCollection<IWebElement> GetAllChildElements<TElement>(
        this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return element.Element.GetAllChildElements();
    }

    /// <summary>
    /// Attempts to wait until a specified element condition is met, with an optional timeout.
    /// </summary>
    /// <param name="element">The element to wait on.</param>
    /// <param name="condition">The condition of the element to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <param name="exceptionHandler">The optional exception handler thrown if an error occurs as a result of timeout.</param>
    /// <typeparam name="TElement">The type of <see cref="IWebElement"/>.</typeparam>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>Whether the wait was a success.</returns>
    /// <exception cref="Exception">Thrown when the <paramref name="exceptionHandler"/> callback throws an exception.</exception>
    public static bool TryWaitUntil<TElement, TResult>(
        this IElementWrapper<TElement> element,
        Func<IElementWrapper<TElement>, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0,
        Action<Exception> exceptionHandler = null)
        where TElement : IWebElement
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
    /// <typeparam name="TElement">The type of <see cref="IWebElement"/>.</typeparam>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>The <typeparamref name="TResult"/> of the wait until operation.</returns>
    /// <exception cref="WebDriverException">Thrown when the condition is not met in the allocated timeout period.</exception>
    /// <exception cref="Exception">Thrown when the <paramref name="condition"/> callback throws an exception.</exception>
    public static TResult WaitUntil<TElement, TResult>(
        this IElementWrapper<TElement> element,
        Func<IElementWrapper<TElement>, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0)
        where TElement : IWebElement
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
