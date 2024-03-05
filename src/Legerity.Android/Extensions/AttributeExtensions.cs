namespace Legerity.Android.Extensions;

using System;

/// <summary>
/// Defines a collection of extensions for retrieving element attributes.
/// </summary>
public static class AttributeExtensions
{
    /// <summary>
    /// Gets the value of the Android content description for this element.
    /// </summary>
    /// <param name="element">The element to retrieve a content description for.</param>
    /// <returns>The element's content description.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetContentDescription(this IWebElement element)
    {
        return element.GetAttribute("content-desc");
    }

    /// <summary>
    /// Gets the value of the Android content description for this element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="IWebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a content description for.</param>
    /// <returns>The element's content description.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetContentDescription<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetContentDescription(element.Element);
    }

    /// <summary>
    /// Gets the value of the Android checked state for this element.
    /// </summary>
    /// <param name="element">The element to retrieve the value from.</param>
    /// <returns>True if the element is checked; otherwise, false.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static bool GetCheckedState(this IWebElement element)
    {
        return element.GetAttribute("Checked").Equals("True", StringComparison.CurrentCultureIgnoreCase);
    }

    /// <summary>
    /// Gets the value of the Android checked state for this element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="IWebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the value from.</param>
    /// <returns>True if the element is checked; otherwise, false.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static bool GetCheckedState<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetCheckedState(element.Element);
    }
}