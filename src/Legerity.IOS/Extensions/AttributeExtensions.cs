namespace Legerity.IOS.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

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
        public static string GetLabel(this IWebElement element)
        {
            return element.GetAttribute("label");
        }

        /// <summary>
        /// Retrieves the label attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a label from.</param>
        /// <returns>The label of the element.</returns>
        public static string GetLabel<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetLabel(element.Element);
        }
    }
}
