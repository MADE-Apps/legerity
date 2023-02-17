namespace Legerity;

using OpenQA.Selenium;

/// <summary>
/// Defines a collection of extra locator constraints for <see cref="By"/>.
/// </summary>
public static class ByExtras
{
    /// <summary>
    /// Gets a mechanism to find elements by the text content.
    /// </summary>
    /// <param name="text">The text to find.</param>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By Text(string text)
    {
        return By.XPath($".//*[text()='{text}']");
    }

    /// <summary>
    /// Gets a mechanism to find elements by partial text content.
    /// </summary>
    /// <param name="text">The text to find.</param>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By PartialText(string text)
    {
        return By.XPath($".//*[contains(text(),'{text}')]");
    }
}