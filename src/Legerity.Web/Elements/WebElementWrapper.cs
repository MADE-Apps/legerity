namespace Legerity.Web.Elements
{
    using System;
    using System.Collections.ObjectModel;
    using Legerity.Exceptions;
    using Legerity.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Defines an element wrapper for a <see cref="RemoteWebElement"/>.
    /// </summary>
    public abstract class WebElementWrapper : IElementWrapper<RemoteWebElement>
    {
        private readonly WeakReference elementReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebElementWrapper"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        protected WebElementWrapper(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebElementWrapper"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        protected WebElementWrapper(RemoteWebElement element)
        {
            this.elementReference = new WeakReference(element);
        }

        /// <summary>Gets the original <see cref="RemoteWebElement"/> reference object.</summary>
        public RemoteWebElement Element =>
            this.elementReference is { IsAlive: true }
                ? this.elementReference.Target as RemoteWebElement
                : null;

        /// <summary>
        /// Gets the instance of the driver for the web application.
        /// </summary>
        public RemoteWebDriver Driver => AppManager.WebApp;

        /// <summary>
        /// Gets a value indicating whether the element is enabled.
        /// </summary>
        public bool IsEnabled => this.Element.Enabled;

        /// <summary>
        /// Gets a value indicating whether the element is visible.
        /// </summary>
        public bool IsVisible => this.Element.Displayed;

        /// <summary>
        /// Finds a child element by the specified locator.
        /// </summary>
        /// <param name="locator">The locator to find a child element by.</param>
        /// <returns>The <see cref="RemoteWebElement"/>.</returns>
        public RemoteWebElement FindElement(By locator)
        {
            return this.Element.FindWebElement(locator);
        }

        /// <summary>
        /// Finds a collection of child elements by the specified locator.
        /// </summary>
        /// <param name="locator">The locator to find a child element by.</param>
        /// <returns>The readonly collection of <see cref="RemoteWebElement"/>.</returns>
        public ReadOnlyCollection<RemoteWebElement> FindElements(By locator)
        {
            return this.Element.FindWebElements(locator);
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
                this.VerifyElementShown(locator);
            }
            catch (ElementNotShownException)
            {
            }
        }

        /// <summary>
        /// Determines whether the given element is shown.
        /// </summary>
        /// <param name="locator">
        /// The locator for the element to find.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the element is not shown.</exception>
        public void VerifyElementShown(By locator)
        {
            this.VerifyElementShown(locator, null);
        }

        /// <summary>
        /// Determines whether the specified element is shown with the specified timeout.
        /// </summary>
        /// <param name="locator">The locator to find a specific element.</param>
        /// <param name="timeout">
        /// The amount of time the driver should wait when searching for the <paramref name="locator"/> if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the element is not shown.</exception>
        public void VerifyElementShown(By locator, TimeSpan? timeout)
        {
            if (timeout == null)
            {
                if (this.Element.FindElement(locator) == null)
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
        /// Determines whether the specified elements are shown.
        /// </summary>
        /// <param name="locator">
        /// The locator for the element to find.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the elements are not shown.</exception>
        public void VerifyElementsShown(By locator)
        {
            this.VerifyElementsShown(locator, null);
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
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the elements are not shown.</exception>
        public void VerifyElementsShown(By locator, TimeSpan? timeout)
        {
            if (timeout == null)
            {
                if (this.Element.FindElements(locator).Count == 0)
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