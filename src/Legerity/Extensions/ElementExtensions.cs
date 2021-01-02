namespace Legerity.Extensions
{
    using System.Drawing;
    using OpenQA.Selenium;

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
    }
}