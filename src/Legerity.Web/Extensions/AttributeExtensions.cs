namespace Legerity.Web.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

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
        public static string GetName(this IWebElement element)
        {
            return element.GetAttribute("name");
        }

        /// <summary>
        /// Retrieves the name attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a name from.</param>
        /// <returns>The name of the element.</returns>
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
        public static string GetValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        /// <summary>
        /// Retrieves the value attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a value from.</param>
        /// <returns>The value of the element.</returns>
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
        public static string GetClass(this IWebElement element)
        {
            return element.GetAttribute("class");
        }

        /// <summary>
        /// Retrieves the class attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a class from.</param>
        /// <returns>The class of the element.</returns>
        public static string GetClass<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetClass(element.Element);
        }
    }
}
