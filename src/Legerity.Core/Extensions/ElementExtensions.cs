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
        /// Finds the first element in the given element that matches the <see cref="By" /> locator.
        /// </summary>
        /// <param name="element">The remote web element.</param>
        /// <param name="locator">The locator to find the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public static RemoteWebElement FindWebElement(this IWebElement element, By locator)
        {
            return element.FindElement(locator) as RemoteWebElement;
        }

        /// <summary>
        /// Finds all the elements in the given element that matches the <see cref="By" /> locator.
        /// </summary>
        /// <param name="element">The remote web element.</param>
        /// <param name="locator">The locator to find the elements.</param>
        /// <returns>A readonly collection of <see cref="RemoteWebElement"/>.</returns>
        public static ReadOnlyCollection<RemoteWebElement> FindWebElements(this IWebElement element, By locator)
        {
            return element.FindElements(locator).Cast<RemoteWebElement>().ToList().AsReadOnly();
        }

        /// <summary>
        /// Finds the first element in the given element that matches the specified text.
        /// </summary>
        /// <param name="element">The remote web element.</param>
        /// <param name="text">The text to find.</param>
        /// <returns>A <see cref="IWebElement"/>.</returns>
        public static IWebElement FindElementByText(this IWebElement element, string text)
        {
            return element.FindElement(ByExtras.Text(text));
        }

        /// <summary>
        /// Finds all the elements in the given element that matches the specified text.
        /// </summary>
        /// <param name="element">The remote web element.</param>
        /// <param name="text">The text to find.</param>
        /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByText(this IWebElement element, string text)
        {
            return element.FindElements(ByExtras.Text(text));
        }

        /// <summary>
        /// Finds the first element in the given element that matches the specified text partially.
        /// </summary>
        /// <param name="element">The remote web element.</param>
        /// <param name="text">The partial text to find.</param>
        /// <returns>A <see cref="IWebElement"/>.</returns>
        public static IWebElement FindElementByPartialText(this IWebElement element, string text)
        {
            return element.FindElement(ByExtras.PartialText(text));
        }

        /// <summary>
        /// Finds all the elements in the given element that matches the specified text partially.
        /// </summary>
        /// <param name="element">The remote web element.</param>
        /// <param name="text">The partial text to find.</param>
        /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByPartialText(this IWebElement element, string text)
        {
            return element.FindElements(ByExtras.PartialText(text));
        }

        /// <summary>
        /// Retrieves all elements that can be located by the driver for the given element.
        /// </summary>
        /// <param name="element">The remote web driver.</param>
        /// <returns>A readonly collection of <see cref="IWebElement"/>.</returns>
        public static ReadOnlyCollection<IWebElement> GetAllElements(this IWebElement element)
        {
            return element.FindElements(By.XPath("//*"));
        }
    }
}