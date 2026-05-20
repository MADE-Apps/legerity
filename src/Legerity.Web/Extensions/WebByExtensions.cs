// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;

namespace Legerity.Web.Extensions;
/// <summary>
/// Defines web-specific fluent chaining extensions for <see cref="By"/> locators and <see cref="ByBuilder"/>.
/// </summary>
public static class WebByExtensions
{
    /// <summary>
    /// Finds child input elements of a specific type within elements matched by the base locator.
    /// </summary>
    /// <param name="by">The parent locator.</param>
    /// <param name="inputType">The input type to find (e.g. "text", "email", "password").</param>
    /// <returns>A <see cref="ByNested"/> locator that scopes the input type search within matched parents.</returns>
    public static By ThenFindByInputType(this By by, string inputType)
    {
        return new ByNested(by, WebByExtras.InputType(inputType));
    }

    /// <summary>
    /// Finds child list item elements within elements matched by the base locator.
    /// </summary>
    /// <param name="by">The parent locator.</param>
    /// <returns>A <see cref="ByNested"/> locator that scopes the list item search within matched parents.</returns>
    public static By ThenFindListItems(this By by)
    {
        return new ByNested(by, WebByExtras.ListItem());
    }

    /// <summary>
    /// Finds child option elements within elements matched by the base locator.
    /// </summary>
    /// <param name="by">The parent locator.</param>
    /// <returns>A <see cref="ByNested"/> locator that scopes the option search within matched parents.</returns>
    public static By ThenFindOptions(this By by)
    {
        return new ByNested(by, WebByExtras.Option());
    }

    /// <summary>
    /// Finds child table row elements within elements matched by the base locator.
    /// </summary>
    /// <param name="by">The parent locator.</param>
    /// <returns>A <see cref="ByNested"/> locator that scopes the row search within matched parents.</returns>
    public static By ThenFindTableRows(this By by)
    {
        return new ByNested(by, WebByExtras.TableRow());
    }

    /// <summary>
    /// Adds an input type constraint to the builder.
    /// </summary>
    /// <param name="builder">The builder instance.</param>
    /// <param name="inputType">The input type to match (e.g. "text", "email", "password").</param>
    /// <returns>The builder instance for chaining.</returns>
    public static ByBuilder HasInputType(this ByBuilder builder, string inputType)
    {
        return builder.Matching(WebByExtras.InputType(inputType));
    }
}