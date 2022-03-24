namespace Legerity.Android.Extensions
{
    using OpenQA.Selenium;

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
        public static string GetContentDescription<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetContentDescription(element.Element);
        }
    }
}