namespace Legerity.Windows.Elements
{
    using System;
    using Legerity.Exceptions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Defines an element wrapper for a <see cref="WindowsElement"/>.
    /// </summary>
    public abstract class WindowsElementWrapper : ElementWrapper<WindowsElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsElementWrapper"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        protected WindowsElementWrapper(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the instance of the Appium driver for the Windows application.
        /// </summary>
        public WindowsDriver<WindowsElement> Driver => this.ElementDriver as WindowsDriver<WindowsElement>;

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
}