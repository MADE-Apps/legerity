namespace Legerity.IOS.Elements;

using System;

using Legerity.Exceptions;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

/// <summary>
/// Defines an element wrapper for a <see cref="IOSElement"/>.
/// </summary>
public class IOSElementWrapper : ElementWrapper<IOSElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IOSElementWrapper"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOSElement"/> reference.
    /// </param>
    public IOSElementWrapper(IOSElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the instance of the Appium driver for the iOS application.
    /// </summary>
    public IOSDriver<IOSElement> Driver => this.ElementDriver as IOSDriver<IOSElement>;

    /// <summary>
    /// Allows conversion of a <see cref="IOSElement"/> to the <see cref="IOSElementWrapper"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOSElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="IOSElementWrapper"/>.
    /// </returns>
    public static implicit operator IOSElementWrapper(IOSElement element)
    {
        return new IOSElementWrapper(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="IOSElementWrapper"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="IOSElementWrapper"/>.
    /// </returns>
    public static implicit operator IOSElementWrapper(AppiumWebElement element)
    {
        return new IOSElementWrapper(element as IOSElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="IOSElementWrapper"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="IOSElementWrapper"/>.
    /// </returns>
    public static implicit operator IOSElementWrapper(RemoteWebElement element)
    {
        return new IOSElementWrapper(element as IOSElement);
    }

    /// <summary>
    /// Determines whether the specified element is shown with the specified timeout.
    /// </summary>
    /// <param name="locator">The locator to find a specific element.</param>
    /// <param name="timeout">
    /// The amount of time the driver should wait when searching for the <paramref name="locator"/> if it is not immediately present.
    /// </param>
    protected void VerifyDriverElementShown(By locator, TimeSpan? timeout)
    {
        if (timeout == null)
        {
            if (this.Driver.FindElement(locator) == null)
            {
                throw new ElementNotShownException(locator.ToString());
            }
        }
        else
        {
            var wait = new WebDriverWait(this.Driver, timeout.Value);
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
    protected void VerifyDriverElementsShown(By locator, TimeSpan? timeout)
    {
        if (timeout == null)
        {
            if (this.Driver.FindElements(locator).Count == 0)
            {
                throw new ElementNotShownException(locator.ToString());
            }
        }
        else
        {
            var wait = new WebDriverWait(this.Driver, timeout.Value);
            wait.Until(driver => driver.FindElements(locator).Count != 0);
        }
    }
}