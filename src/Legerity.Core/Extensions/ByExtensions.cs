// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;

namespace Legerity.Extensions;
/// <summary>
/// Defines fluent chaining extensions for <see cref="By"/> locators.
/// </summary>
/// <example>
/// <code>
/// // Same-element constraints via builder
/// By.TagName("button").That(by => by.HasText("Accept"))
/// By.TagName("div").That(by => by.HasAttribute("role", "dialog").HasAttribute("aria-modal", "true"))
///
/// // Nested scope - find children within matched parents
/// By.Id("nav").ThenFind(by => by.TagName("a").HasText("Home"))
///
/// // Complex composition
/// By.TagName("form").That(by => by.HasAttribute("id", "login"))
///     .ThenFind(by => by.TagName("input").HasAttribute("type", "email"))
///
/// // Simple shortcut methods still work
/// By.TagName("button").WithText("Accept")
/// By.ClassName("card").WithPartialText("Welcome")
/// </code>
/// </example>
public static class ByExtensions
{
    /// <summary>
    /// Adds same-element constraints via a builder. The element must match both the
    /// original locator and all constraints defined in the builder.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="configure">A delegate to configure additional constraints on the same element.</param>
    /// <returns>A <see cref="ByBuilder"/> that finds elements matching all constraints.</returns>
    public static ByBuilder That(this By by, Action<ByBuilder> configure)
    {
        _ = new ByBuilder(by);
        var additional = new ByBuilder();
        configure(additional);
        return new ByBuilder(new ByAll(by, additional));
    }

    /// <summary>
    /// Scopes into child elements within elements matched by the base locator.
    /// The builder defines what to find within the matched parents.
    /// </summary>
    /// <param name="by">The parent locator.</param>
    /// <param name="configure">A delegate to configure the child element query.</param>
    /// <returns>A <see cref="ByBuilder"/> that finds child elements within matched parents.</returns>
    public static ByBuilder ThenFind(this By by, Action<ByBuilder> configure)
    {
        var parent = new ByBuilder(by);
        var child = new ByBuilder();
        configure(child);
        parent.SetNested(child);
        return parent;
    }

    /// <summary>
    /// Adds an exact text content constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="text">The exact text content to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the text.</returns>
    public static By WithText(this By by, string text)
    {
        return new ByAll(by, ByExtras.Text(text));
    }

    /// <summary>
    /// Adds a partial text content constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="text">The partial text content to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the partial text.</returns>
    public static By WithPartialText(this By by, string text)
    {
        return new ByAll(by, ByExtras.PartialText(text));
    }

    /// <summary>
    /// Adds an exact attribute value constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="attributeName">The name of the attribute to match.</param>
    /// <param name="attributeValue">The exact value of the attribute to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the attribute value.</returns>
    public static By WithAttribute(this By by, string attributeName, string attributeValue)
    {
        return new ByAll(by, By.XPath($".//*[@{attributeName}='{attributeValue}']"));
    }

    /// <summary>
    /// Adds a partial attribute value constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="attributeName">The name of the attribute to match.</param>
    /// <param name="partialValue">The partial value of the attribute to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the partial attribute value.</returns>
    public static By WithPartialAttribute(this By by, string attributeName, string partialValue)
    {
        return new ByAll(by, By.XPath($".//*[contains(@{attributeName},'{partialValue}')]"));
    }

    /// <summary>
    /// Adds a constraint that the element must also match the specified locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="other">The additional locator the element must also match.</param>
    /// <returns>A <see cref="ByAll"/> locator requiring both constraints to be satisfied.</returns>
    public static By And(this By by, By other)
    {
        return new ByAll(by, other);
    }

    /// <summary>
    /// Finds child elements within elements matched by the base locator.
    /// </summary>
    /// <param name="by">The parent locator.</param>
    /// <param name="childLocator">The locator for child elements within the parent.</param>
    /// <returns>A <see cref="ByNested"/> locator that scopes the child search within matched parents.</returns>
    public static By ThenFind(this By by, By childLocator)
    {
        return new ByNested(by, childLocator);
    }
}