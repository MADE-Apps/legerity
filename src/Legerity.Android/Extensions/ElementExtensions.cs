namespace Legerity.Android.Extensions;

public static class ElementExtensions
{
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static WebElement FindElementByAndroidUIAutomator(this WebElement element, string selector)
    {
        return element.FindElement(MobileBy.AndroidUIAutomator(selector)) as WebElement;
    }
}