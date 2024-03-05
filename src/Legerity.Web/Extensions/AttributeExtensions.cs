namespace Legerity.Web.Extensions;

/// <summary>
/// Defines a collection of extensions for retrieving element attributes.
/// </summary>
public static class AttributeExtensions
{
    /// <summary>
    /// Retrieves the name attribute from the specified element.
    /// </summary>
    /// <param name="element">The <see cref="IWebElement"/> to retrieve a name from.</param>
    /// <returns>The name of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetName(this IWebElement element)
    {
        return element.GetAttribute("name");
    }

    /// <summary>
    /// Retrieves the name attribute from the specified element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="WebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a name from.</param>
    /// <returns>The name of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetName<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetName(element.Element);
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

    /// <summary>
    /// Retrieves the class attribute from the specified element.
    /// </summary>
    /// <param name="element">The <see cref="IWebElement"/> to retrieve a class from.</param>
    /// <returns>The class of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetClass(this IWebElement element)
    {
        return element.GetAttribute("class");
    }

    /// <summary>
    /// Retrieves the class attribute from the specified element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="WebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a class from.</param>
    /// <returns>The class of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static string GetClass<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetClass(element.Element);
    }

    /// <summary>
    /// Retrieves the width attribute from the specified element.
    /// </summary>
    /// <param name="element">The <see cref="IWebElement"/> to retrieve a width from.</param>
    /// <returns>The width of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static double GetWidth(this IWebElement element)
    {
        return double.Parse(element.GetAttribute("width"));
    }

    /// <summary>
    /// Retrieves the width attribute from the specified element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="WebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a width from.</param>
    /// <returns>The width of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static double GetWidth<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetWidth(element.Element);
    }

    /// <summary>
    /// Retrieves the height attribute from the specified element.
    /// </summary>
    /// <param name="element">The <see cref="IWebElement"/> to retrieve a height from.</param>
    /// <returns>The height of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static double GetHeight(this IWebElement element)
    {
        return double.Parse(element.GetAttribute("height"));
    }

    /// <summary>
    /// Retrieves the height attribute from the specified element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="WebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a height from.</param>
    /// <returns>The height of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static double GetHeight<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetHeight(element.Element);
    }

    /// <summary>
    /// Retrieves the minimum attribute from the specified element.
    /// </summary>
    /// <param name="element">The <see cref="IWebElement"/> to retrieve a minimum value from.</param>
    /// <returns>The minimum value of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static double GetMinimum(this IWebElement element)
    {
        return double.Parse(element.GetAttribute("min"));
    }

    /// <summary>
    /// Retrieves the minimum attribute from the specified element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="WebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a minimum from.</param>
    /// <returns>The minimum value of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static double GetMinimum<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetMinimum(element.Element);
    }

    /// <summary>
    /// Retrieves the maximum attribute from the specified element.
    /// </summary>
    /// <param name="element">The <see cref="IWebElement"/> to retrieve a maximum value from.</param>
    /// <returns>The maximum value of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static double GetMaximum(this IWebElement element)
    {
        return double.Parse(element.GetAttribute("max"));
    }

    /// <summary>
    /// Retrieves the maximum attribute from the specified element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="WebElement"/>.
    /// </typeparam>
    /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a maximum from.</param>
    /// <returns>The maximum value of the element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static double GetMaximum<TElement>(this IElementWrapper<TElement> element)
        where TElement : IWebElement
    {
        return GetMaximum(element.Element);
    }
}