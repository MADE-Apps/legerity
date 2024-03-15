namespace Legerity.Android.Elements;

using System;
using Exceptions;

/// <summary>
/// Defines an element wrapper for an Android <see cref="WebElement"/>.
/// </summary>
public class AndroidElementWrapper : ElementWrapper<WebElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AndroidElementWrapper"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public AndroidElementWrapper(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the instance of the Appium driver for the Android application.
    /// </summary>
    public AndroidDriver Driver => ElementDriver as AndroidDriver;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="AndroidElementWrapper"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="AndroidElementWrapper"/>.
    /// </returns>
    public static implicit operator AndroidElementWrapper(WebElement element)
    {
        return new AndroidElementWrapper(element);
    }

    /// <summary>
    /// Determines whether the specified element is shown with the specified timeout.
    /// </summary>
    /// <param name="locator">The locator to find a specific element.</param>
    /// <param name="timeout">
    /// The amount of time the driver should wait when searching for the <paramref name="locator"/> if it is not immediately present.
    /// </param>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    protected void VerifyDriverElementShown(By locator, TimeSpan? timeout)
    {
        if (timeout == null)
        {
            try
            {
                if (Driver.FindElement(locator) == null)
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
    /// Determines whether the specified elements are shown with the specified timeout.
    /// </summary>
    /// <param name="locator">
    /// The locator to find a collection of elements.
    /// </param>
    /// <param name="timeout">
    /// The amount of time the driver should wait when searching for the <paramref name="locator"/> if it is not immediately present.
    /// </param>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    protected void VerifyDriverElementsShown(By locator, TimeSpan? timeout)
    {
        if (timeout == null)
        {
            if (Driver.FindElements(locator).Count == 0)
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
