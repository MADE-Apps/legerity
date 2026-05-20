// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Legerity.Windows.Elements.Core;
/// <summary>
/// Defines a <see cref="AppiumElement"/> wrapper for the Windows ScrollViewer control.
/// </summary>
public class ScrollViewer : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScrollViewer"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumElement"/> reference.
    /// </param>
    public ScrollViewer(AppiumElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="ScrollViewer"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ScrollViewer"/>.
    /// </returns>
    public static implicit operator ScrollViewer(WebElement element)
    {
        return new ScrollViewer(element as AppiumElement);
    }

    /// <summary>
    /// Scrolls the scroll viewer to the top.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ScrollToTop()
    {
        this.Element.SendKeys(Keys.Home);
    }

    /// <summary>
    /// Scrolls the scroll viewer to the bottom.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ScrollToBottom()
    {
        this.Element.SendKeys(Keys.End);
    }
}