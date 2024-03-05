namespace Legerity.IOS.Extensions;

/// <summary>
/// Defines a collection of extensions for retrieving element attributes.
/// </summary>
public static class AttributeExtensions
{
    /// <summary>
    /// Retrieves the label attribute from the specified element.
    /// </summary>
    /// <param name="element">The <see cref="IWebElement"/> to retrieve a label from.</param>
    /// <returns>The label of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetLabel(this IWebElement element)
    {
        return element.GetAttribute("label");
    }

    /// <summary>
    /// Retrieves the label attribute from the specified element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="WebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a label from.</param>
    /// <returns>The label of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetLabel<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetLabel(element.Element);
    }

    /// <summary>
    /// Retrieves the value attribute from the specified element.
    /// </summary>
    /// <param name="element">The <see cref="IWebElement"/> to retrieve a value from.</param>
    /// <returns>The value of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetValue(this IWebElement element)
    {
        return element.GetAttribute("value");
    }

    /// <summary>
    /// Retrieves the value attribute from the specified element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="WebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a value from.</param>
    /// <returns>The value of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetValue<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetValue(element.Element);
    }
}