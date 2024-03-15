namespace Legerity;

using System;

/// <summary>
/// Defines an interface for a Selenium/Appium element wrapper.
/// </summary>
/// <typeparam name="TElement">
/// The type of <see cref="IWebElement"/>.
/// </typeparam>
public interface IElementWrapper<out TElement>
    where TElement : IWebElement
{
    /// <summary>Gets the original <typeparamref name="TElement"/> reference object.</summary>
    TElement Element { get; }

    /// <summary>
    /// Gets the driver used to find this element.
    /// </summary>
    IWebDriver ElementDriver { get; }

    /// <summary>
    /// Gets a value indicating whether the element is visible.
    /// </summary>
    bool IsVisible { get; }

    /// <summary>
    /// Gets a value indicating whether the element is enabled.
    /// </summary>
    bool IsEnabled { get; }

    /// <summary>
    /// Clicks the element.
    /// </summary>
    void Click();

    /// <summary>
    /// Gets the value of the specified attribute for this element.
    /// </summary>
    /// <param name="attributeName">The name of the attribute.</param>
    /// <returns>The attribute's current value if it exists; otherwise, null.</returns>
    string GetAttribute(string attributeName);

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
