namespace Legerity.Pages
{
    using System;

    using Legerity.Android;
    using Legerity.Exceptions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;
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
        /// Gets the instance of the started Android application.
        /// </summary>
        protected AndroidDriver<AndroidElement> AndroidApp => AppManager.AndroidApp;

        /// <summary>
        /// Gets the instance of the started iOS application.
        /// </summary>
        protected IOSDriver<IOSElement> IOSApp => AppManager.IOSApp;

        /// <summary>
        /// Gets the instance of the started web application.
        /// <para>
        /// The <see cref="WebApp"/> instance also serves as base for the Appium drivers and can be referenced for basic Selenium functions.
        /// </para>
        /// </summary>
        protected RemoteWebDriver WebApp => AppManager.WebApp;

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
            if (this.WebApp == null)
            {
                throw new DriverNotInitializedException(
                    $"An app driver has not been initialized. Call 'AppManager.StartApp()' with an instance of an {nameof(AppManagerOptions)} to setup for testing.");
            }

            if (timeout == null)
            {
                if (this.WebApp != null && this.WebApp.FindElement(this.Trait) == null)
                {
                    throw new PageNotShownException(this.GetType().Name);
                }
            }
            else
            {
                if (this.WebApp != null)
                {
                    this.AttemptWaitForDriverElement(this.WebApp, timeout.Value);
                }
            }
        }

        private void AttemptWaitForDriverElement(IWebDriver appDriver, TimeSpan timeout)
        {
            var wait = new WebDriverWait(appDriver, timeout);
            wait.Until(driver => driver.FindElement(this.Trait) != null);
        }
    }
}