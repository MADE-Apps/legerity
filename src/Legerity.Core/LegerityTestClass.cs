namespace Legerity
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a base class for running tests with the Legerity framework.
    /// </summary>
    public abstract class LegerityTestClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegerityTestClass"/> class.
        /// <para>
        /// The <see cref="Options"/> will need to be set before calling <see cref="StartApp"/>.
        /// </para>
        /// </summary>
        protected LegerityTestClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegerityTestClass"/> class with application launch option.
        /// </summary>
        /// <param name="options">The application launch options.</param>
        protected LegerityTestClass(AppManagerOptions options)
        {
            this.Options = options;
        }

        /// <summary>
        /// Gets the instance of the started application.
        /// <para>
        /// This could be a <see cref="WindowsDriver{W}"/>, <see cref="AndroidDriver{W}"/>, <see cref="IOSDriver{W}"/>, or web driver.
        /// </para>
        /// </summary>
        protected RemoteWebDriver App { get; private set; }

        /// <summary>
        /// Gets or sets the model that represents the configuration options for the <see cref="AppManager"/>.
        /// </summary>
        protected AppManagerOptions Options { get; set; }

        /// <summary>
        /// Starts the application ready for testing.
        /// </summary>
        /// <param name="waitUntil">
        /// An optional condition of the driver to wait on until it is met.
        /// </param>
        /// <param name="waitUntilTimeout">
        /// An optional timeout wait on the conditional wait until being true. If not set, the wait will run immediately, and if not valid, will throw an exception.
        /// </param>
        /// <param name="waitUntilRetries">
        /// An optional count of retries after a timeout on the wait until condition before accepting the failure.
        /// </param>
        /// <returns>The configured and running application driver.</returns>
        public virtual RemoteWebDriver StartApp(
            Func<IWebDriver, bool> waitUntil = default,
            TimeSpan? waitUntilTimeout = default,
            int waitUntilRetries = 0)
        {
            RemoteWebDriver app = AppManager.StartApp(this.Options, waitUntil, waitUntilTimeout, waitUntilRetries);
            this.App = app;
            return app;
        }

        /// <summary>
        /// Stops the <see cref="App"/>, with an option to stop the running Appium or WinAppDriver server.
        /// </summary>
        /// <param name="stopServer">
        /// An optional value indicating whether to stop the running Appium or WinAppDriver server. Default, <b>true</b>.
        /// </param>
        public virtual void StopApp(bool stopServer = true)
        {
            this.StopApp(this.App, stopServer);
        }

        /// <summary>
        /// Stops an application, with an option to stop the running Appium or WinAppDriver server.
        /// </summary>
        /// <param name="app">
        /// The <see cref="IWebDriver"/> instance to stop running.
        /// </param>
        /// <param name="stopServer">
        /// An optional value indicating whether to stop the running Appium or WinAppDriver server. Default, <b>false</b>.
        /// </param>
        public virtual void StopApp(IWebDriver app, bool stopServer = false)
        {
            AppManager.StopApp(app, stopServer);
        }
    }
}