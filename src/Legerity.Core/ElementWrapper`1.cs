namespace Legerity
{
    using System;

    using Legerity.Exceptions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Defines a base wrapper for elements to expose platform element logic.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="AppiumWebElement"/>.
    /// </typeparam>
    public abstract class ElementWrapper<TElement> : IElementWrapper<TElement>
        where TElement : AppiumWebElement
    {
        private readonly WeakReference elementReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementWrapper{TElement}"/> class.
        /// </summary>
        /// <param name="element">
        /// The <typeparamref name="TElement"/> reference.
        /// </param>
        protected ElementWrapper(TElement element)
        {
            this.elementReference = new WeakReference(element);
        }

        /// <summary>Gets the original <typeparamref name="TElement"/> reference object.</summary>
        public TElement Element =>
            this.elementReference is { IsAlive: true }
                ? this.elementReference.Target as TElement
                : null;

        /// <summary>
        /// Gets a value indicating whether the element is visible.
        /// </summary>
        public virtual bool IsVisible => this.Element.Displayed;

        /// <summary>
        /// Gets a value indicating whether the element is enabled.
        /// </summary>
        public virtual bool IsEnabled => this.Element.Enabled;

        /// <summary>
        /// Clicks the element.
        /// </summary>
        public virtual void Click()
        {
            this.Element.Click();
        }

        /// <summary>
        /// Gets the value of the specified attribute for this element.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The attribute's current value if it exists; otherwise, null.</returns>
        public string GetAttribute(string attributeName)
        {
            return this.Element.GetAttribute(attributeName);
        }

        /// <summary>
        /// Finds a child element by the specified locator.
        /// </summary>
        /// <param name="locator">The locator to find a child element by.</param>
        /// <returns>The <typeparamref name="TElement"/>.</returns>
        public AppiumWebElement FindElement(By locator)
        {
            return this.Element.FindElement(locator);
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
                throw new ElementShownException(locator.ToString());
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
                var wait = new WebDriverWait(this.Element.WrappedDriver, timeout.Value);
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
                var wait = new WebDriverWait(this.Element.WrappedDriver, timeout.Value);
                wait.Until(driver => driver.FindElements(locator).Count != 0);
            }
        }
    }
}