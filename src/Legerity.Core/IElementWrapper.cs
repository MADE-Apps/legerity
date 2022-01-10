namespace Legerity
{
    using System;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines an interface for a Selenium/Appium element wrapper.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="IWebElement"/>.
    /// </typeparam>
    public interface IElementWrapper<TElement>
        where TElement : IWebElement
    {
        /// <summary>Gets the original <typeparamref name="TElement"/> reference object.</summary>
        TElement Element { get; }

        /// <summary>
        /// Gets a value indicating whether the element is visible.
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// Determines whether the given element is shown.
        /// </summary>
        /// <param name="locator">
        /// The locator for the element to find.
        /// </param>
        void VerifyElementShown(By locator);

        /// <summary>
        /// Determines whether the specified element is shown with the specified timeout.
        /// </summary>
        /// <param name="locator">The locator to find a specific element.</param>
        /// <param name="timeout">
        /// The amount of time the driver should wait when searching for the <paramref name="locator"/> if it is not immediately present.
        /// </param>
        void VerifyElementShown(By locator, TimeSpan? timeout);

        /// <summary>
        /// Determines whether the given element is not shown.
        /// </summary>
        /// <param name="locator">
        /// The locator for the element to locate.
        /// </param>
        void VerifyElementNotShown(By locator);

        /// <summary>
        /// Determines whether the specified elements are shown.
        /// </summary>
        /// <param name="locator">
        /// The locator for the element to find.
        /// </param>
        void VerifyElementsShown(By locator);

        /// <summary>
        /// Determines whether the specified elements are shown with the specified timeout.
        /// </summary>
        /// <param name="locator">
        /// The locator to find a collection of elements.
        /// </param>
        /// <param name="timeout">
        /// The amount of time the driver should wait when searching for the <paramref name="locator"/> if it is not immediately present.
        /// </param>
        void VerifyElementsShown(By locator, TimeSpan? timeout);
    }
}