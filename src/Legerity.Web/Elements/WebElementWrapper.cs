namespace Legerity.Web.Elements;

using System;
using System.Collections.ObjectModel;
using Exceptions;
using Legerity.Extensions;

/// <summary>
/// Defines an element wrapper for a <see cref="WebElement"/>.
/// </summary>
public class WebElementWrapper : IElementWrapper<WebElement>
{
    private readonly WeakReference _elementReference;

    /// <summary>
    /// Initializes a new instance of the <see cref="WebElementWrapper"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public WebElementWrapper(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WebElementWrapper"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public WebElementWrapper(WebElement element)
    {
        _elementReference = new WeakReference(element);
    }

    /// <summary>Gets the original <see cref="WebElement"/> reference object.</summary>
    public WebElement Element =>
        _elementReference is { IsAlive: true }
            ? _elementReference.Target as WebElement
            : null;

    /// <summary>
    /// Gets the driver used to find this element.
    /// </summary>
    public IWebDriver ElementDriver => Element.WrappedDriver;

    /// <summary>
    /// Gets the instance of the driver for the web application.
    /// </summary>
    public WebDriver Driver => ElementDriver as WebDriver;

    /// <summary>
    /// Gets a value indicating whether the element is enabled.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsEnabled => Element.Enabled;

    /// <summary>
    /// Gets a value indicating whether the element is visible.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsVisible => Element.Displayed;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="WebElementWrapper"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="WebElementWrapper"/>.
    /// </returns>
    public static implicit operator WebElementWrapper(WebElement element)
    {
        return new WebElementWrapper(element);
    }

    /// <summary>
    /// Finds a child element by the specified locator.
    /// </summary>
    /// <param name="locator">The locator to find a child element by.</param>
    /// <returns>The <see cref="WebElement"/>.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public WebElement FindElement(By locator)
    {
        return Element.FindWebElement(locator);
    }

    /// <summary>
    /// Finds a collection of child elements by the specified locator.
    /// </summary>
    /// <param name="locator">The locator to find a child element by.</param>
    /// <returns>The readonly collection of <see cref="WebElement"/>.</returns>
    public ReadOnlyCollection<WebElement> FindElements(By locator)
    {
        return Element.FindWebElements(locator);
    }

    /// <summary>
    /// Determines whether the given element is not shown.
    /// </summary>
    /// <param name="locator">
    /// The locator for the element to locate.
    /// </param>
    public void VerifyElementNotShown(By locator)
    {
        try
        {
            VerifyElementShown(locator);
        }
        catch (ElementNotShownException)
        {
        }
        catch (NoSuchElementException)
        {
        }
    }

    /// <summary>
    /// Clicks the element.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Click()
    {
        Element.Click();
    }

    /// <summary>
    /// Gets the value of the specified attribute for this element.
    /// </summary>
    /// <param name="attributeName">The name of the attribute.</param>
    /// <returns>The attribute's current value if it exists; otherwise, null.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public string GetAttribute(string attributeName)
    {
        return Element.GetAttribute(attributeName);
    }

    /// <summary>
    /// Determines whether the given element is shown.
    /// </summary>
    /// <param name="locator">
    /// The locator for the element to find.
    /// </param>
    /// <exception cref="ElementNotShownException">Thrown when the element is not shown.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public void VerifyElementShown(By locator)
    {
        VerifyElementShown(locator, null);
    }

    /// <summary>
    /// Determines whether the specified element is shown with the specified timeout.
    /// </summary>
    /// <param name="locator">The locator to find a specific element.</param>
    /// <param name="timeout">
    /// The amount of time the driver should wait when searching for the <paramref name="locator"/> if it is not immediately present.
    /// </param>
    /// <exception cref="ElementNotShownException">Thrown when the element is not shown.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public void VerifyElementShown(By locator, TimeSpan? timeout)
    {
        if (timeout == null)
        {
            try
            {
                if (Element.FindElement(locator) == null)
                {
                    throw new ElementNotShownException(locator.ToString());
                }
            }
            catch (NoSuchElementException ex)
            {
                throw new ElementNotShownException(locator.ToString(), ex);
            }
        }
        else
        {
            var wait = new WebDriverWait(Driver, timeout.Value);
            wait.Until(driver => driver.FindElement(locator) != null);
        }
    }

    /// <summary>
    /// Determines whether the specified elements are shown.
    /// </summary>
    /// <param name="locator">
    /// The locator for the element to find.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public void VerifyElementsShown(By locator)
    {
        VerifyElementsShown(locator, null);
    }

    /// <summary>
    /// Determines whether the specified elements are shown with the specified timeout.
    /// </summary>
    /// <param name="locator">
    /// The locator to find a collection of elements.
    /// </param>
    /// <param name="timeout">
    /// The amount of time the driver should wait when searching for the <paramref name="locator"/> if it is not immediately present.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public void VerifyElementsShown(By locator, TimeSpan? timeout)
    {
        if (timeout == null)
        {
            if (Element.FindElements(locator).Count == 0)
            {
                throw new ElementsNotShownException(locator.ToString());
            }
        }
        else
        {
            var wait = new WebDriverWait(Driver, timeout.Value);
            wait.Until(driver => driver.FindElements(locator).Count != 0);
        }
    }
}
