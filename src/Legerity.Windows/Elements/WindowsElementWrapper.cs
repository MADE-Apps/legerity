namespace Legerity.Windows.Elements;

using System;
using Legerity.Exceptions;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

/// <summary>
/// Defines an element wrapper for a <see cref="WindowsElement"/>.
/// </summary>
public class WindowsElementWrapper : ElementWrapper<WindowsElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowsElementWrapper"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public WindowsElementWrapper(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the instance of the Appium driver for the Windows application.
    /// </summary>
    public WindowsDriver<WindowsElement> Driver => this.ElementDriver as WindowsDriver<WindowsElement>;

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="WindowsElementWrapper"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="WindowsElementWrapper"/>.
    /// </returns>
    public static implicit operator WindowsElementWrapper(WindowsElement element)
    {
        return new WindowsElementWrapper(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="WindowsElementWrapper"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="WindowsElementWrapper"/>.
    /// </returns>
    public static implicit operator WindowsElementWrapper(AppiumWebElement element)
    {
        return new WindowsElementWrapper(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="WindowsElementWrapper"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="WindowsElementWrapper"/>.
    /// </returns>
    public static implicit operator WindowsElementWrapper(RemoteWebElement element)
    {
        return new WindowsElementWrapper(element as WindowsElement);
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
                if (this.Driver.FindElement(locator) == null)
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
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    protected void VerifyDriverElementsShown(By locator, TimeSpan? timeout)
    {
        if (timeout == null)
        {
            if (this.Driver.FindElements(locator).Count == 0)
            {
                throw new ElementsNotShownException(locator.ToString());
            }
        }
        else
        {
            var wait = new WebDriverWait(this.Driver, timeout.Value);
            wait.Until(driver => driver.FindElements(locator).Count != 0);
        }
    }
}