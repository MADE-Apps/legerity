namespace Legerity.Windows.Elements.Core;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the Windows ScrollViewer control.
/// </summary>
public class ScrollViewer : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScrollViewer"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public ScrollViewer(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="ScrollViewer"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ScrollViewer"/>.
    /// </returns>
    public static implicit operator ScrollViewer(WindowsElement element)
    {
        return new ScrollViewer(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ScrollViewer"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ScrollViewer"/>.
    /// </returns>
    public static implicit operator ScrollViewer(AppiumWebElement element)
    {
        return new ScrollViewer(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ScrollViewer"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ScrollViewer"/>.
    /// </returns>
    public static implicit operator ScrollViewer(RemoteWebElement element)
    {
        return new ScrollViewer(element as WindowsElement);
    }

    /// <summary>
    /// Scrolls the scroll viewer to the top.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ScrollToTop()
    {
        this.Element.SendKeys(Keys.Home);
    }

    /// <summary>
    /// Scrolls the scroll viewer to the bottom.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ScrollToBottom()
    {
        this.Element.SendKeys(Keys.End);
    }
}