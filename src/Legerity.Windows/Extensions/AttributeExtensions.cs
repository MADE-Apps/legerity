namespace Legerity.Windows.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a collection of extensions for retrieving element attributes.
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// Retrieves the AutomationId attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve an AutomationId from.</param>
        /// <returns>The AutomationId of the element.</returns>
        public static string GetAutomationId(this IWebElement element)
        {
            return element.GetAttribute("AutomationId");
        }

        /// <summary>
        /// Retrieves the AutomationId attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve an AutomationId from.</param>
        /// <returns>The AutomationId of the element.</returns>
        public static string GetAutomationId<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetAutomationId(element.Element);
        }
    }
}
