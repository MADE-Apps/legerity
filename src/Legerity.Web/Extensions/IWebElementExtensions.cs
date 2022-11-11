namespace Legerity.Web.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a collection of extensions for the <see cref="IWebElement"/> class.
    /// </summary>
    public static class IWebElementExtensions
    {
        /// <summary>
        /// Retrieves the inner HTML of the specified <see cref="IWebElement"/>.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve the inner HTML from.</param>
        /// <returns>A string representing the inner HTML.</returns>
        public static string GetInnerHtml(this IWebElement element)
        {
            return element.GetAttribute("innerHTML");
        }

        /// <summary>
        /// Retrieves the value attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the inner HTML from.</param>
        /// <returns>The inner HTML of the element.</returns>
        public static string GetInnerHtml<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetInnerHtml(element.Element);
        }

        /// <summary>
        /// Determines whether the specified <see cref="IWebElement"/> has the specified <paramref name="className">class</paramref>.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to check.</param>
        /// <param name="className">The name of the class the element should have.</param>
        /// <returns>True if the element has the class; otherwise, false.</returns>
        public static bool HasClass(this IWebElement element, string className)
        {
            return element.GetClass().Contains(className);
        }

        /// <summary>
        /// Determines whether the specified <see cref="IElementWrapper{TElement}"/> has the specified <paramref name="className">class</paramref>.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to check.</param>
        /// <param name="className">The name of the class the element should have.</param>
        /// <returns>True if the element has the class; otherwise, false.</returns>
        public static bool HasClass<TElement>(this IElementWrapper<TElement> element, string className)
            where TElement : IWebElement
        {
            return HasClass(element.Element, className);
        }
    }
}