namespace Legerity.Helpers;

using System;
using Legerity.Pages;

/// <summary>
/// Defines a set of conditions that can be used with the WaitUntil methods of elements and pages.
/// </summary>
public static class WaitUntilConditions
{
    /// <summary>
    /// A condition for validating whether the title of the current Window matches the specified title.
    /// </summary>
    /// <param name="title">The expected title, which must be an exact match.</param>
    /// <param name="comparison">The comparison for validating equality.</param>
    /// <returns>True if the title matches; otherwise, false.</returns>
    public static Func<IWebDriver, bool> TitleIs(
        string title,
        StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
    {
        return driver => driver.Title.Equals(title, comparison);
    }

    /// <summary>
    /// A condition for validating whether the title of the current Window contains a case-sensitive substring.
    /// </summary>
    /// <param name="title">The fragment of title expected.</param>
    /// <returns>True if the title contains the text; otherwise, false.</returns>
    public static Func<IWebDriver, bool> TitleContains(string title)
    {
        return driver => driver.Title.Contains(title);
    }

    /// <summary>
    /// A condition for validating whether the URL of the current Window matches the specified URL.
    /// </summary>
    /// <param name="url">The URL that the page should be on.</param>
    /// <param name="comparison">The comparison for validating equality.</param>
    /// <returns>True if the URL matches; otherwise, false.</returns>
    public static Func<IWebDriver, bool> UrlIs(
        string url,
        StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
    {
        return driver => driver.Url.Equals(url, comparison);
    }

    /// <summary>
    /// A condition for validating whether the URL of the current Window contains a case-sensitive substring.
    /// </summary>
    /// <param name="url">The fragment of URL expected.</param>
    /// <returns>True if the URL contains the text; otherwise, false.</returns>
    public static Func<IWebDriver, bool> UrlContains(string url)
    {
        return driver => driver.Url.Contains(url);
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator exists within the context of the page.
    /// <para>
    /// Note, the element may exist but may not be visible.
    /// </para>
    /// </summary>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element exists; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static Func<IWebDriver, bool> ElementExists(By locator)
    {
        return driver => driver.FindElement(locator) != null;
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator exists within the context of an element.
    /// <para>
    /// Note, the element may exist but may not be visible.
    /// </para>
    /// </summary>
    /// <typeparam name="TElement">The type of <see cref="IWebElement"/>.</typeparam>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element exists; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static Func<TElement, bool> ElementExistsInElement<TElement>(By locator)
        where TElement : IWebElement
    {
        return element => element.FindElement(locator) != null;
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator exists within the context of an element wrapper.
    /// <para>
    /// Note, the element may exist but may not be visible.
    /// </para>
    /// </summary>
    /// <typeparam name="TElement">The type of <see cref="IWebElement"/>.</typeparam>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element exists; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static Func<IElementWrapper<TElement>, bool> ElementExistsInElementWrapper<TElement>(By locator)
        where TElement : IWebElement
    {
        return wrapper => wrapper.Element.FindElement(locator) != null;
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator exists within the context of a page object.
    /// <para>
    /// Note, the element may exist but may not be visible.
    /// </para>
    /// </summary>
    /// <typeparam name="TPage">The type of <see cref="BasePage"/>.</typeparam>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element exists; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static Func<TPage, bool> ElementExistsInPage<TPage>(By locator)
        where TPage : BasePage
    {
        return page => page.FindElement(locator) != null;
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator is visible within the context of the page.
    /// </summary>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element is visible; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static Func<IWebDriver, bool> ElementIsVisible(By locator)
    {
        return driver =>
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator is visible within the context of an element.
    /// </summary>
    /// <typeparam name="TElement">The type of <see cref="IWebElement"/>.</typeparam>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element is visible; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static Func<TElement, bool> ElementIsVisibleInElement<TElement>(By locator)
        where TElement : IWebElement
    {
        return element =>
        {
            try
            {
                return element.FindElement(locator).Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator is visible within the context of an element wrapper.
    /// </summary>
    /// <typeparam name="TElement">The type of <see cref="IWebElement"/>.</typeparam>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element is visible; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static Func<IElementWrapper<TElement>, bool> ElementIsVisibleInElementWrapper<TElement>(By locator)
        where TElement : IWebElement
    {
        return wrapper =>
        {
            try
            {
                return wrapper.Element.FindElement(locator).Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator is visible within the context of a page object.
    /// </summary>
    /// <typeparam name="TPage">The type of <see cref="BasePage"/>.</typeparam>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element is visible; otherwise, false.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static Func<TPage, bool> ElementIsVisibleInPage<TPage>(By locator)
        where TPage : BasePage
    {
        return page =>
        {
            try
            {
                return page.FindElement(locator).Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator is hidden (not visible) within the context of the page.
    /// </summary>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element is hidden (not visible); otherwise, false.</returns>
    public static Func<IWebDriver, bool> ElementIsNotVisible(By locator)
    {
        return driver =>
        {
            try
            {
                return !driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                // Returns true because the element is not present.
                return true;
            }
            catch (StaleElementReferenceException)
            {
                // Returns true because a stale element implies it is not present.
                return true;
            }
        };
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator is hidden (not visible) within the context of an element.
    /// </summary>
    /// <typeparam name="TElement">The type of <see cref="IWebElement"/>.</typeparam>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element is hidden (not visible); otherwise, false.</returns>
    public static Func<TElement, bool> ElementIsNotVisibleInElement<TElement>(By locator)
        where TElement : IWebElement
    {
        return element =>
        {
            try
            {
                return !element.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                // Returns true because the element is not present.
                return true;
            }
            catch (StaleElementReferenceException)
            {
                // Returns true because a stale element implies it is not present.
                return true;
            }
        };
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator is hidden (not visible) within the context of an element wrapper.
    /// </summary>
    /// <typeparam name="TElement">The type of <see cref="IWebElement"/>.</typeparam>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element is hidden (not visible); otherwise, false.</returns>
    public static Func<IElementWrapper<TElement>, bool> ElementIsNotVisibleInElementWrapper<TElement>(By locator)
        where TElement : IWebElement
    {
        return wrapper =>
        {
            try
            {
                return !wrapper.Element.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                // Returns true because the element is not present.
                return true;
            }
            catch (StaleElementReferenceException)
            {
                // Returns true because a stale element implies it is not present.
                return true;
            }
        };
    }

    /// <summary>
    /// A condition for validating whether a specified element found by a locator is hidden (not visible) within the context of a page object.
    /// </summary>
    /// <typeparam name="TPage">The type of <see cref="BasePage"/>.</typeparam>
    /// <param name="locator">The locator to find the element.</param>
    /// <returns>True if the element is hidden (not visible); otherwise, false.</returns>
    public static Func<TPage, bool> ElementIsNotVisibleInPage<TPage>(By locator)
        where TPage : BasePage
    {
        return page =>
        {
            try
            {
                return !page.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                // Returns true because the element is not present.
                return true;
            }
            catch (StaleElementReferenceException)
            {
                // Returns true because a stale element implies it is not present.
                return true;
            }
        };
    }

    /// <summary>
    /// A condition for switching to a frame by its name when it is available.
    /// </summary>
    /// <param name="frameName">The name of the frame to switch to.</param>
    /// <returns>The <see cref="IWebDriver"/> for the frame that has been switched to.</returns>
    public static Func<IWebDriver, IWebDriver> FrameAvailableToSwitchTo(string frameName)
    {
        return driver =>
        {
            try
            {
                return driver.SwitchTo().Frame(frameName);
            }
            catch (NoSuchFrameException)
            {
                return null;
            }
        };
    }

    /// <summary>
    /// A condition for switching to a frame by its name when it is available.
    /// </summary>
    /// <param name="frameLocator">The locator of the frame to switch to.</param>
    /// <returns>The <see cref="IWebDriver"/> for the frame that has been switched to.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid.</exception>
    public static Func<IWebDriver, IWebDriver> FrameAvailableToSwitchTo(By frameLocator)
    {
        return driver =>
        {
            try
            {
                var frameElement = driver.FindElement(frameLocator);
                return driver.SwitchTo().Frame(frameElement);
            }
            catch (NoSuchFrameException)
            {
                return null;
            }
        };
    }
}
