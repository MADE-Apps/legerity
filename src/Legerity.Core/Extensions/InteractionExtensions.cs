namespace Legerity.Extensions;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a collection of extensions for performing interactions with elements.
/// </summary>
public static class InteractionExtensions
{
    /// <summary>
    /// Clicks and holds on the element.
    /// </summary>
    /// <remarks>
    /// The element hold can be released by calling <see cref="ReleaseHold"/>.
    /// </remarks>
    /// <param name="element">The element to click and hold.</param>
    public static void ClickAndHold(this RemoteWebElement element)
    {
        var action = new Actions(element.WrappedDriver);
        action.ClickAndHold(element).Perform();
    }

    /// <summary>
    /// Clicks and holds on the element.
    /// </summary>
    /// <remarks>
    /// The element hold can be released by calling <see cref="ReleaseHold"/>.
    /// </remarks>
    /// <typeparam name="TElement">
    /// The type of wrapped <see cref="IWebElement"/>.
    /// </typeparam>
    /// <param name="element">The element to click and hold.</param>
    public static void ClickAndHold<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        ClickAndHold(element.Element as RemoteWebElement);
    }

    /// <summary>
    /// Releases the hold click from the element.
    /// </summary>
    /// <param name="element">The element to release the hold from.</param>
    public static void ReleaseHold(this RemoteWebElement element)
    {
        var action = new Actions(element.WrappedDriver);
        action.Release(element).Perform();
    }

    /// <summary>
    /// Releases the hold click from the element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of wrapped <see cref="IWebElement"/>.
    /// </typeparam>
    /// <param name="element">The element to release the hold from.</param>
    public static void ReleaseHold<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        ReleaseHold(element.Element as RemoteWebElement);
    }
}