namespace Legerity.Extensions
{
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a collection of extensions for elements.
    /// </summary>
    public static class ElementExtensions
    {
        /// <summary>
        /// Determines the bounding rectangle for the specified element.
        /// </summary>
        /// <param name="element">The element to determine the rect for.</param>
        /// <returns>The elements bounding rectangle.</returns>
        public static Rectangle GetBoundingRect(this IWebElement element)
        {
            Point location = element.Location;
            Size size = element.Size;
            return new Rectangle(location.X, location.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Finds the first element in the page that matches the <see cref="By" /> query.
        /// </summary>
        /// <param name="element">The remote web element.</param>
        /// <param name="by">The query to find the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public static RemoteWebElement FindWebElement(this IWebElement element, By by)
        {
            return element.FindElement(by) as RemoteWebElement;
        }

        /// <summary>
        /// Finds all the elements in the page that matches the <see cref="By" /> query.
        /// </summary>
        /// <param name="element">The remote web element.</param>
        /// <param name="by">The query to find the elements.</param>
        /// <returns>A readonly collection of <see cref="RemoteWebElement"/>.</returns>
        public static ReadOnlyCollection<RemoteWebElement> FindWebElements(this IWebElement element, By by)
        {
            return element.FindElements(by).Cast<RemoteWebElement>().ToList().AsReadOnly();
        }
    }
}