namespace Legerity.Windows.Extensions;

using System.Collections.Generic;
using System.Linq;

public static class ElementExtensions
{
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static WebElement FindElementByName(this IWebElement element, string name)
    {
        return element.FindElement(By.Name(name)) as WebElement;
    }

    public static IEnumerable<WebElement> FindElementsByClassName(this IWebElement element, string className)
    {
        return element.FindElements(By.ClassName(className)).Cast<WebElement>();
    }
}
