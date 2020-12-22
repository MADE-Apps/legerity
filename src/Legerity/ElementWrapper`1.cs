namespace Legerity
{
    using System;

    using Legerity.Exceptions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Defines a base wrapper for elements to expose platform element logic.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="AppiumWebElement"/>.
    /// </typeparam>
    public abstract class ElementWrapper<TElement>
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
            this.elementReference != null && this.elementReference.IsAlive
                ? this.elementReference.Target as TElement
                : null;

        /// <summary>
        /// Gets a value indicating whether the element is visible.
        /// </summary>
        public bool IsVisible => this.Element.Displayed;

        /// <summary>
        /// Determines whether the given element is shown.
        /// </summary>
        /// <param name="by">
        /// The query for the element to find.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the element is not shown.</exception>
        protected void VerifyElementShown(By by)
        {
            this.VerifyElementShown(by, null);
        }

        /// <summary>
        /// Determines whether the specified element is shown with the specified timeout.
        /// </summary>
        /// <param name="query">The query to find a specific element.</param>
        /// <param name="timeout">
        /// The amount of time the driver should wait when searching for the <paramref name="query"/> if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the element is not shown.</exception>
        protected void VerifyElementShown(By query, TimeSpan? timeout)
        {
            if (timeout == null)
            {
                if (this.Element.FindElement(query) == null)
                {
                    throw new ElementNotShownException(query.ToString());
                }
            }
            else
            {
                var wait = new WebDriverWait(this.Element.WrappedDriver, timeout.Value);
                wait.Until(driver => driver.FindElement(query) != null);
            }
        }

        /// <summary>
        /// Determines whether the specified elements are shown.
        /// </summary>
        /// <param name="by">
        /// The query for the element to find.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the elements are not shown.</exception>
        protected void VerifyElementsShown(By by)
        {
            this.VerifyElementsShown(by, null);
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
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the elements are not shown.</exception>
        protected void VerifyElementsShown(By query, TimeSpan? timeout)
        {
            if (timeout == null)
            {
                if (this.Element.FindElements(query).Count == 0)
                {
                    throw new ElementNotShownException(query.ToString());
                }
            }
            else
            {
                var wait = new WebDriverWait(this.Element.WrappedDriver, timeout.Value);
                wait.Until(driver => driver.FindElements(query).Count != 0);
            }
        }

        /// <summary>
        /// Determines whether the given element is not shown.
        /// </summary>
        /// <param name="by">
        /// The query for the element to locate.
        /// </param>
        public void VerifyElementNotShown(By by)
        {
            try
            {
                this.VerifyElementShown(by);
            }
            catch (ElementNotShownException)
            {
            }
        }
    }
}