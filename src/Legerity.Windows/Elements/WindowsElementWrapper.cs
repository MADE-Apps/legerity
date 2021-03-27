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
        public WindowsDriver<WindowsElement> Driver => AppManager.WindowsApp;

        /// <summary>
        /// Gets a value indicating whether the element is enabled.
        /// </summary>
        public bool IsEnabled => this.Element.Enabled;

        /// <summary>
        /// Determines whether the specified element is shown with the specified timeout.
        /// </summary>
        /// <param name="query">The query to find a specific element.</param>
        /// <param name="timeout">
        /// The amount of time the driver should wait when searching for the <paramref name="query"/> if it is not immediately present.
        /// </param>
        protected void VerifyDriverElementShown(By query, TimeSpan? timeout)
        {
            if (timeout == null)
            {
                if (this.Driver.FindElement(query) == null)
                {
                    throw new ElementNotShownException(query.ToString());
                }
            }
            else
            {
                var wait = new WebDriverWait(this.Driver, timeout.Value);
                wait.Until(driver => driver.FindElement(query) != null);
            }
        }

        /// <summary>
        /// Determines whether the specified elements are shown with the specified timeout.
        /// </summary>
        /// <param name="query">
        /// The query to find a collection of elements.
        /// </param>
        /// <param name="timeout">
        /// The amount of time the driver should wait when searching for the <paramref name="query"/> if it is not immediately present.
        /// </param>
        protected void VerifyDriverElementsShown(By query, TimeSpan? timeout)
        {
            if (timeout == null)
            {
                if (this.Driver.FindElements(query).Count == 0)
                {
                    throw new ElementNotShownException(query.ToString());
                }
            }
            else
            {
                var wait = new WebDriverWait(this.Driver, timeout.Value);
                wait.Until(driver => driver.FindElements(query).Count != 0);
            }
        }
    }
}