// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity;
/// <summary>
/// Specifies that a test class or method should be excluded when running against apps whose identifier contains any of the specified values.
/// <para>
/// The matching is case-insensitive and uses substring comparison, so <c>"Microsoft.WinUI3ControlsGallery"</c>
/// will match an app ID of <c>"Microsoft.WinUI3ControlsGallery_8wekyb3d8bbwe!App"</c>.
/// </para>
/// </summary>
/// <remarks>
/// <para>
/// This attribute works with <see cref="LegerityTestClass"/> to automatically check for exclusions when <see cref="LegerityTestClass.StartApp()"/> is called.
/// When an exclusion matches, <see cref="LegerityTestClass.IgnoreTest(string)"/> is invoked.
/// </para>
/// <para>
/// Test framework-specific base classes should override <see cref="LegerityTestClass.IgnoreTest(string)"/> to call the appropriate
/// test framework ignore/skip method (e.g. <c>Assert.Ignore(reason)</c> for NUnit).
/// </para>
/// </remarks>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class AppExclusionAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppExclusionAttribute"/> class.
    /// </summary>
    /// <param name="appIds">
    /// One or more app identifier substrings. If the current app's identifier contains any of these values, the test will be excluded.
    /// </param>
    public AppExclusionAttribute(params string[] appIds)
    {
        this.AppIds = appIds;
    }

    /// <summary>
    /// Gets the app identifier substrings that trigger exclusion.
    /// </summary>
    public string[] AppIds { get; }

    /// <summary>
    /// Determines whether the specified app identifier matches any of the exclusion patterns.
    /// </summary>
    /// <param name="appIdentifier">The app identifier to check.</param>
    /// <returns><c>true</c> if the app should be excluded; otherwise, <c>false</c>.</returns>
    public bool IsExcluded(string appIdentifier)
    {
        if (string.IsNullOrEmpty(appIdentifier))
        {
            return false;
        }

        return this.AppIds.Any(id => appIdentifier.Contains(id, StringComparison.OrdinalIgnoreCase));
    }
}
