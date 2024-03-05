namespace Legerity.Android;

using OpenQA.Selenium.Appium.Android.UiAutomator;

/// <summary>
/// Defines a collection of extra locator constraints for <see cref="By"/>.
/// </summary>
public static class AndroidByExtras
{
    /// <summary>
    /// Gets a mechanism to find elements by an Android content description.
    /// </summary>
    /// <param name="contentDesc">The content description to match exactly on.</param>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By ContentDescription(string contentDesc)
    {
        return new ByAndroidUIAutomator(new AndroidUiSelector().DescriptionEquals(contentDesc));
    }

    /// <summary>
    /// Gets a mechanism to find elements by an Android partial content description.
    /// </summary>
    /// <param name="contentDesc">The partial content description to match on.</param>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By PartialContentDescription(string contentDesc)
    {
        return new ByAndroidUIAutomator(new AndroidUiSelector().DescriptionContains(contentDesc));
    }
}