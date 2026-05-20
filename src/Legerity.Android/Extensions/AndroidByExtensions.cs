// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;

namespace Legerity.Android.Extensions;
/// <summary>
/// Defines Android-specific fluent chaining extensions for <see cref="By"/> locators and <see cref="ByBuilder"/>.
/// </summary>
public static class AndroidByExtensions
{
    /// <summary>
    /// Adds a content description constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="contentDescription">The exact content description to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the content description.</returns>
    public static By WithContentDescription(this By by, string contentDescription)
    {
        return new ByAll(by, AndroidByExtras.ContentDescription(contentDescription));
    }

    /// <summary>
    /// Adds a partial content description constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="contentDescription">The partial content description to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the partial content description.</returns>
    public static By WithPartialContentDescription(this By by, string contentDescription)
    {
        return new ByAll(by, AndroidByExtras.PartialContentDescription(contentDescription));
    }

    /// <summary>
    /// Adds a content description constraint to the builder.
    /// </summary>
    /// <param name="builder">The builder instance.</param>
    /// <param name="contentDescription">The exact content description to match.</param>
    /// <returns>The builder instance for chaining.</returns>
    public static ByBuilder HasContentDescription(this ByBuilder builder, string contentDescription)
    {
        return builder.Matching(AndroidByExtras.ContentDescription(contentDescription));
    }

    /// <summary>
    /// Adds a partial content description constraint to the builder.
    /// </summary>
    /// <param name="builder">The builder instance.</param>
    /// <param name="contentDescription">The partial content description to match.</param>
    /// <returns>The builder instance for chaining.</returns>
    public static ByBuilder HasPartialContentDescription(this ByBuilder builder, string contentDescription)
    {
        return builder.Matching(AndroidByExtras.PartialContentDescription(contentDescription));
    }
}