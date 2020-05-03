namespace Legerity.Pages
{
    using System;

    using Legerity.Exceptions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Defines a base page for creating tests following the page object pattern.
    /// </summary>
    public abstract class BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class.
        /// </summary>
        protected BasePage()
        {
            this.VerifyPageShown(TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Gets the instance of the started Windows application.
        /// </summary>
        protected WindowsDriver<WindowsElement> WindowsApp => AppManager.WindowsApp;

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected abstract By Trait { get; }

        /// <summary>
        /// Determines whether the current page is shown with the specified timeout.
        /// </summary>
        /// <param name="timeout">
        /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
        /// </param>
        public void VerifyPageShown(TimeSpan? timeout)
        {
            if (timeout == null)
            {
                if (this.WindowsApp.FindElement(this.Trait) == null)
                {
                    throw new PageNotShownException(this.GetType().Name);
                }
            }
            else
            {
                var wait = new WebDriverWait(this.WindowsApp, timeout.Value);
                wait.Until(driver => driver.FindElement(this.Trait) != null);
            }
        }
    }
}