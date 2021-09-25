namespace Legerity.Web.Extensions
{
    using OpenQA.Selenium;

    /// <summary>
    /// Defines a collection of extensions for the <see cref="By"/> class.
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
    }
}
