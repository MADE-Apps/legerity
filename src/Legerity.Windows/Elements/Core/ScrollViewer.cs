namespace Legerity.Windows.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Windows ScrollViewer control.
/// </summary>
public class ScrollViewer : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScrollViewer"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public ScrollViewer(WebElement element)
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
        return new ScrollViewer(element);
    }
    
    /// <summary>
    /// Scrolls the scroll viewer to the top.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ScrollToTop()
    {
        Element.SendKeys(Keys.Home);
    }

    /// <summary>
    /// Scrolls the scroll viewer to the bottom.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ScrollToBottom()
    {
        Element.SendKeys(Keys.End);
    }
}
