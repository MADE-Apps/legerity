namespace Legerity.Android.Elements
{
    using System;

    using Legerity.Exceptions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Defines an element wrapper for a <see cref="AndroidElement"/>.
    /// </summary>
    public abstract class AndroidElementWrapper : ElementWrapper<AndroidElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AndroidElementWrapper"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/> reference.
        /// </param>
        protected AndroidElementWrapper(AndroidElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the instance of the Appium driver for the Android application.
        /// </summary>
        public AndroidDriver<AndroidElement> Driver => this.ElementDriver as AndroidDriver<AndroidElement>;

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