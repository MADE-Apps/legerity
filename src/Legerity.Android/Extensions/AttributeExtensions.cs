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
    }
}