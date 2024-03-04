namespace Legerity;

using System;
using System.Collections.Generic;
using Android;
using Exceptions;
using IOS;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using Windows;

/// <summary>
/// Defines a base class for running tests with the Legerity framework.
/// </summary>
public abstract class LegerityTestClass
{
    private readonly List<WebDriver> apps = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="LegerityTestClass"/> class.
    /// <para>
    /// The <see cref="Options"/> will need to be set before calling <see cref="StartApp(Func{IWebDriver,bool},TimeSpan?,int)"/>.
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
    /// This could be a <see cref="WindowsDriver"/>, <see cref="AndroidDriver"/>, <see cref="IOSDriver"/>, or web driver.
    /// </para>
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp(Func{IWebDriver,bool},TimeSpan?,int)"/> or <see cref="StartApp(AppManagerOptions,Func{IWebDriver,bool},TimeSpan?,int)"/> method.
    /// </remarks>
    protected WebDriver App { get; private set; }

    /// <summary>
    /// Gets or sets the instances of started applications.
    /// </summary>
    /// <remarks>
    /// This is useful for accessing drivers in parallelized tests.
    /// </remarks>
    protected IReadOnlyCollection<WebDriver> Apps => this.apps;

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
    /// <exception cref="WebDriverException">Thrown when the wait until condition is not met in the allocated timeout period if provided.</exception>
    /// <exception cref="DriverLoadFailedException">Thrown when the application is null, the session ID is null once initialized, or the driver fails to configure correctly before returning.</exception>
    /// <exception cref="LegerityException">Thrown when:
    /// - The Appium server could not be found when running with <see cref="AndroidAppManagerOptions.LaunchAppiumServer"/> or <see cref="IOSAppManagerOptions.LaunchAppiumServer"/> true.
    /// - The WinAppDriver could not be found when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// - The WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// </exception>
    public virtual WebDriver StartApp(
        Func<IWebDriver, bool> waitUntil = default,
        TimeSpan? waitUntilTimeout = default,
        int waitUntilRetries = 0)
    {
        return this.StartApp(this.Options, waitUntil, waitUntilTimeout, waitUntilRetries);
    }

    /// <summary>
    /// Starts the application ready for testing.
    /// </summary>
    /// <param name="options">
    /// The optional options to configure the driver with.
    /// <para>
    /// Settings this will override the <see cref="Options"/> if previously set.
    /// </para>
    /// </param>
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
    /// <exception cref="DriverLoadFailedException">Thrown when the application is null, the session ID is null once initialized, or the driver fails to configure correctly before returning.</exception>
    /// <exception cref="LegerityException">Thrown when:
    /// - The Appium server could not be found when running with <see cref="AndroidAppManagerOptions.LaunchAppiumServer"/> or <see cref="IOSAppManagerOptions.LaunchAppiumServer"/> true.
    /// - The WinAppDriver could not be found when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// - The WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// </exception>
    /// <exception cref="WebDriverException">Thrown when the wait until condition is not met in the allocated timeout period if provided.</exception>
    public virtual WebDriver StartApp(
        AppManagerOptions options,
        Func<IWebDriver, bool> waitUntil = default,
        TimeSpan? waitUntilTimeout = default,
        int waitUntilRetries = 0)
    {
        if (options != default && this.Options != options)
        {
            this.Options = options;
        }

        WebDriver app = AppManager.StartApp(this.Options, waitUntil, waitUntilTimeout, waitUntilRetries);
        this.App = app;
        this.apps.Add(app);
        return app;
    }

    /// <summary>
    /// Stops the <see cref="App"/> and any running Appium or WinAppDriver server.
    /// </summary>
    public virtual void StopApp()
    {
        this.StopApp(true);
    }

    /// <summary>
    /// Stops the <see cref="App"/>, with an option to stop the running Appium or WinAppDriver server.
    /// </summary>
    /// <param name="stopServer">
    /// An optional value indicating whether to stop the running Appium or WinAppDriver server.
    /// </param>
    public virtual void StopApp(bool stopServer)
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
    public virtual void StopApp(WebDriver app, bool stopServer = false)
    {
        this.StopAppManagerApp(app, stopServer, true);
    }

    /// <summary>
    /// Stops all running application drivers, with an option to stop the running Appium or WinAppDriver server.
    /// </summary>
    /// <param name="stopServer">
    /// An optional value indicating whether to stop the running Appium or WinAppDriver server. Default, <b>true</b>.
    /// </param>
    public virtual void StopApps(bool stopServer = true)
    {
        this.apps.ForEach(app => this.StopAppManagerApp(app, stopServer, false));
        this.apps.Clear();
    }

    private void StopAppManagerApp(WebDriver app, bool stopServer, bool removeApp)
    {
        if (removeApp)
        {
            this.apps.Remove(app);
        }

        AppManager.StopApp(app, stopServer);
    }
}