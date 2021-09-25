namespace Legerity.Web.Extensions
{
    using OpenQA.Selenium;

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
        /// Determines whether the specified <see cref="IWebElement"/> has the specified <paramref name="className">class</paramref>.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to check.</param>
        /// <param name="className">The name of the class the element should have.</param>
        /// <returns>True if the element has the class; otherwise, false.</returns>
        public static bool HasClass(this IWebElement element, string className)
        {
            return element.GetAttribute("class").Contains(className);
        }
    }
}
