namespace Legerity.Windows.Extensions;

public static class ElementExtensions
{
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static WebElement FindElementByName(this IWebElement element, string name)
    {
        return element.FindElement(By.Name(name)) as WebElement;
    }
}