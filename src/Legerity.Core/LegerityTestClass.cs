// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Concurrent;
using Legerity.Android;
using Legerity.Exceptions;
using Legerity.IOS;
using Legerity.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;

namespace Legerity;
/// <summary>
/// Defines a base class for running tests with the Legerity framework.
/// </summary>
public abstract class LegerityTestClass
{
    private static readonly AsyncLocal<WebDriver> CurrentApp = new();
    private readonly ConcurrentBag<WebDriver> apps = new();

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
    /// Gets the instance of the started application for the current test.
    /// <para>
    /// This could be a <see cref="WindowsDriver"/>, <see cref="AndroidDriver"/>, <see cref="IOSDriver"/>, or web driver.
    /// </para>
    /// </summary>
    /// <remarks>
    /// This property is thread-safe and returns the driver for the current test execution context,
    /// making it safe for use in parallelized test runs.
    /// </remarks>
    protected static WebDriver App
    {
        get => CurrentApp.Value;
        private set => CurrentApp.Value = value;
    }

    /// <summary>
    /// Gets the instances of all started applications across this fixture.
    /// </summary>
    protected IReadOnlyCollection<WebDriver> Apps => this.apps.ToArray();

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
        App = app;
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
        this.StopApp(App, stopServer);
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
        StopAppManagerApp(app, stopServer);
    }

    /// <summary>
    /// Stops all running application drivers, with an option to stop the running Appium or WinAppDriver server.
    /// </summary>
    /// <param name="stopServer">
    /// An optional value indicating whether to stop the running Appium or WinAppDriver server. Default, <b>true</b>.
    /// </param>
    public virtual void StopApps(bool stopServer = true)
    {
        while (this.apps.TryTake(out WebDriver app))
        {
            AppManager.StopApp(app, stopServer);
        }
    }

    private static void StopAppManagerApp(WebDriver app, bool stopServer)
    {
        AppManager.StopApp(app, stopServer);
    }
}