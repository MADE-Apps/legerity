namespace Legerity.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a collection of extensions for retrieving element attributes.
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// Retrieves the Name attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve a Name from.</param>
        /// <returns>The Name of the element.</returns>
        public static string GetName(this IWebElement element)
        {
            return element.GetAttribute("Name");
        }

        /// <summary>
        /// Retrieves the Name attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a Name from.</param>
        /// <returns>The Name of the element.</returns>
        public static string GetName<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetName(element.Element);
        }
    }
}
