// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;

namespace Legerity.IOS.Extensions;
/// <summary>
/// Defines iOS-specific fluent chaining extensions for <see cref="By"/> locators and <see cref="ByBuilder"/>.
/// </summary>
public static class IOSByExtensions
{
    /// <summary>
    /// Adds an exact label constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="label">The exact label to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the label.</returns>
    public static By WithLabel(this By by, string label)
    {
        return new ByAll(by, IOSByExtras.Label(label));
    }

    /// <summary>
    /// Adds a partial label constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="label">The partial label to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the partial label.</returns>
    public static By WithPartialLabel(this By by, string label)
    {
        return new ByAll(by, IOSByExtras.PartialLabel(label));
    }

    /// <summary>
    /// Adds an exact value constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="value">The exact value to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the value.</returns>
    public static By WithValue(this By by, string value)
    {
        return new ByAll(by, IOSByExtras.Value(value));
    }

    /// <summary>
    /// Adds a partial value constraint to the locator.
    /// </summary>
    /// <param name="by">The base locator.</param>
    /// <param name="value">The partial value to match.</param>
    /// <returns>A <see cref="ByAll"/> locator matching both the original locator and the partial value.</returns>
    public static By WithPartialValue(this By by, string value)
    {
        return new ByAll(by, IOSByExtras.PartialValue(value));
    }

    /// <summary>
    /// Adds an exact label constraint to the builder.
    /// </summary>
    /// <param name="builder">The builder instance.</param>
    /// <param name="label">The exact label to match.</param>
    /// <returns>The builder instance for chaining.</returns>
    public static ByBuilder HasLabel(this ByBuilder builder, string label)
    {
        return builder.Matching(IOSByExtras.Label(label));
    }

    /// <summary>
    /// Adds a partial label constraint to the builder.
    /// </summary>
    /// <param name="builder">The builder instance.</param>
    /// <param name="label">The partial label to match.</param>
    /// <returns>The builder instance for chaining.</returns>
    public static ByBuilder HasPartialLabel(this ByBuilder builder, string label)
    {
        return builder.Matching(IOSByExtras.PartialLabel(label));
    }

    /// <summary>
    /// Adds an exact value constraint to the builder.
    /// </summary>
    /// <param name="builder">The builder instance.</param>
    /// <param name="value">The exact value to match.</param>
    /// <returns>The builder instance for chaining.</returns>
    public static ByBuilder HasValue(this ByBuilder builder, string value)
    {
        return builder.Matching(IOSByExtras.Value(value));
    }

    /// <summary>
    /// Adds a partial value constraint to the builder.
    /// </summary>
    /// <param name="builder">The builder instance.</param>
    /// <param name="value">The partial value to match.</param>
    /// <returns>The builder instance for chaining.</returns>
    public static ByBuilder HasPartialValue(this ByBuilder builder, string value)
    {
        return builder.Matching(IOSByExtras.PartialValue(value));
    }
}