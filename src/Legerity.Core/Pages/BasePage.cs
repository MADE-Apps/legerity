namespace Legerity.Pages
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Legerity.Exceptions;
    using Legerity.Extensions;
    using OpenQA.Selenium;
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
        /// Initializes a new instance of the <see cref="BasePage"/> class using the <see cref="AppManager.App"/> instance that verifies the page has loaded within 2 seconds.
        /// </summary>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in 2 seconds.</exception>
        protected BasePage()
            : this(AppManager.App, TimeSpan.FromSeconds(2))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class using a <see cref="RemoteWebDriver"/> instance that verifies the page has loaded within 2 seconds.
        /// </summary>
        /// <param name="app">
        /// The instance of the started application driver that will be used to drive the page interaction.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in 2 seconds.</exception>
        protected BasePage(RemoteWebDriver app)
            : this(app, TimeSpan.FromSeconds(2))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class using the <see cref="AppManager.App"/> instance that verifies the page has loaded within the given timeout.
        /// </summary>
        /// <param name="traitTimeout">
        /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in the given timeout.</exception>
        protected BasePage(TimeSpan? traitTimeout)
            : this(AppManager.App, traitTimeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class using a <see cref="RemoteWebDriver"/> instance that verifies the page has loaded within the given timeout.
        /// </summary>
        /// <param name="app">
        /// The instance of the started application driver that will be used to drive the page interaction.
        /// </param>
        /// <param name="traitTimeout">
        /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in the given timeout.</exception>
        protected BasePage(RemoteWebDriver app, TimeSpan? traitTimeout)
        {
            this.App = app;
            this.VerifyPageShown(traitTimeout ?? TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Gets the instance of the started application.
        /// <para>
        /// The <see cref="App"/> instance serves as base for the drivers and can be referenced for basic Selenium functions.
        /// </para>
        /// <para>
        /// This could be a <see cref="WindowsDriver{W}"/>, <see cref="AndroidDriver{W}"/>, <see cref="IOSDriver{W}"/>, or web driver.
        /// </para>
        /// </summary>
        public RemoteWebDriver App { get; }

        /// <summary>
        /// Gets the instance of the started Windows application.
        /// </summary>
        protected WindowsDriver<WindowsElement> WindowsApp => this.App as WindowsDriver<WindowsElement>;

        /// <summary>
        /// Gets the instance of the started Android application.
        /// </summary>
        protected AndroidDriver<AndroidElement> AndroidApp => this.App as AndroidDriver<AndroidElement>;

        /// <summary>
        /// Gets the instance of the started iOS application.
        /// </summary>
        protected IOSDriver<IOSElement> IOSApp => this.App as IOSDriver<IOSElement>;

        /// <summary>
        /// Gets the instance of the started web application.
        /// </summary>
        protected RemoteWebDriver WebApp => this.App;

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected abstract By Trait { get; }

        /// <summary>
        /// Finds the first element in the page that matches the <see cref="By" /> locator.
        /// </summary>
        /// <param name="locator">The locator to find the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public RemoteWebElement FindElement(By locator)
        {
            return this.App.FindWebElement(locator);
        }

        /// <summary>
        /// Finds all the elements in the page that matches the <see cref="By" /> locator.
        /// </summary>
        /// <param name="locator">The locator to find the elements.</param>
        /// <returns>A readonly collection of <see cref="RemoteWebElement"/>.</returns>
        public ReadOnlyCollection<RemoteWebElement> FindElements(By locator)
        {
            return this.App.FindWebElements(locator);
        }

        /// <summary>
        /// Finds the first element in the page that matches the specified XPath.
        /// </summary>
        /// <param name="xpath">The XPath to find the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public RemoteWebElement FindElementByXPath(string xpath)
        {
            return this.App.FindElementByXPath(xpath) as RemoteWebElement;
        }

        /// <summary>
        /// Finds all the elements in the page that matches the specified XPath.
        /// </summary>
        /// <param name="xpath">The XPath to find the elements.</param>
        /// <returns>A readonly collection of <see cref="RemoteWebElement"/>.</returns>
        public ReadOnlyCollection<RemoteWebElement> FindElementsByXPath(string xpath)
        {
            return this.App.FindElementsByXPath(xpath).Cast<RemoteWebElement>().ToList().AsReadOnly();
        }

        /// <summary>
        /// Finds the first element in the page that matches the specified ID.
        /// </summary>
        /// <param name="id">The ID of the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public RemoteWebElement FindElementById(string id)
        {
            return this.App.FindElementById(id) as RemoteWebElement;
        }

        /// <summary>
        /// Finds the first of element in the page that matches the specified name.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <returns>A <see cref="RemoteWebElement"/>.</returns>
        public RemoteWebElement FindElementByName(string name)
        {
            return this.App.FindElementByName(name) as RemoteWebElement;
        }

        /// <summary>
        /// Determines whether the current page is shown immediately.
        /// </summary>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown.</exception>
        public void VerifyPageShown()
        {
            this.VerifyPageShown(null);
        }

        /// <summary>
        /// Determines whether the current page is shown with the specified timeout.
        /// </summary>
        /// <param name="timeout">
        /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown.</exception>
        public void VerifyPageShown(TimeSpan? timeout)
        {
            if (this.App == null)
            {
                throw new DriverNotInitializedException(
                    $"An app driver has not been initialized. Call 'AppManager.StartApp()' with an instance of an {nameof(AppManagerOptions)} to setup for testing.");
            }

            if (timeout == null)
            {
                if (this.App != null && this.App.FindElement(this.Trait) == null)
                {
                    throw new PageNotShownException(this.GetType().Name);
                }
            }
            else
            {
                if (this.App != null)
                {
                    AttemptWaitForDriverElement(this.Trait, timeout.Value, this.App);
                }
            }
        }

        /// <summary>
        /// Determines whether the given element is shown.
        /// </summary>
        /// <param name="locator">
        /// The locator for the element to find.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the element is not shown.</exception>
        public void VerifyElementShown(By locator)
        {
            this.VerifyElementShown(locator, null);
        }

        /// <summary>
        /// Determines whether the given element is shown with the specified timeout.
        /// </summary>
        /// <param name="locator">
        /// The locator for the element to find.
        /// </param>
        /// <param name="timeout">
        /// The amount of time the driver should wait when searching for the <paramref name="locator"/> element if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.ElementNotShownException">Thrown if the element is not shown.</exception>
        public void VerifyElementShown(By locator, TimeSpan? timeout)
        {
            if (this.App == null)
            {
                throw new DriverNotInitializedException(
                    $"An app driver has not been initialized. Call 'AppManager.StartApp()' with an instance of an {nameof(AppManagerOptions)} to setup for testing.");
            }

            if (timeout == null)
            {
                if (this.App != null && this.App.FindElement(locator) == null)
                {
                    throw new ElementNotShownException(locator.ToString());
                }
            }
            else
            {
                if (this.App != null)
                {
                    AttemptWaitForDriverElement(locator, timeout.Value, this.App);
                }
            }
        }

        /// <summary>
        /// Determines whether the given element is not shown.
        /// </summary>
        /// <param name="locator">
        /// The locator for the element to locate.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        public void VerifyElementNotShown(By locator)
        {
            if (this.App == null)
            {
                throw new DriverNotInitializedException(
                    $"An app driver has not been initialized. Call 'AppManager.StartApp()' with an instance of an {nameof(AppManagerOptions)} to setup for testing.");
            }

            try
            {
                this.VerifyElementShown(locator);
            }
            catch (ElementNotShownException)
            {
            }
            catch (WebDriverException wde) when (wde.Message.Contains("element could not be located"))
            {
            }
        }

        private static void AttemptWaitForDriverElement(By locator, TimeSpan timeout, IWebDriver appDriver)
        {
            var wait = new WebDriverWait(appDriver, timeout);
            wait.Until(driver => driver.FindElement(locator) != null);
        }
    }
}