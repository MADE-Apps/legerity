namespace Legerity;

using System;
using System.Collections.Generic;
using Legerity.Android;
using Legerity.Exceptions;
using Legerity.Extensions;
using Legerity.Helpers;
using Legerity.IOS;
using Legerity.Web;
using Legerity.Windows;
using Legerity.Windows.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

/// <summary>
/// Defines a manager for the application under test.
/// </summary>
public static class AppManager
{
    private static readonly List<RemoteWebDriver> StartedApps = new();

    /// <summary>
    /// Gets the instance of the started Windows application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static WindowsDriver<WindowsElement> WindowsApp => App as WindowsDriver<WindowsElement>;

    /// <summary>
    /// Gets the instance of the started Android application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static AndroidDriver<AndroidElement> AndroidApp => App as AndroidDriver<AndroidElement>;

    /// <summary>
    /// Gets the instance of the started iOS application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static IOSDriver<IOSElement> IOSApp => App as IOSDriver<IOSElement>;

    /// <summary>
    /// Gets the instance of the started web application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static RemoteWebDriver WebApp => App;

    /// <summary>
    /// Gets or sets the instance of the started application.
    /// <para>
    /// This could be a <see cref="WindowsDriver{W}"/>, <see cref="AndroidDriver{W}"/>, <see cref="IOSDriver{W}"/>, or web driver.
    /// </para>
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static RemoteWebDriver App { get; set; }

    /// <summary>
    /// Gets the instances of started applications.
    /// </summary>
    public static IReadOnlyCollection<RemoteWebDriver> Apps => StartedApps;

    /// <summary>
    /// Starts the application ready for testing.
    /// </summary>
    /// <param name="opts">
    /// The options to configure the driver with.
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
    /// <exception cref="DriverLoadFailedException">
    /// Thrown when the application is null, the session ID is null once initialized, or the driver fails to configure correctly before returning.
    /// </exception>
    /// <exception cref="WebDriverException">Thrown when the wait until condition is not met in the allocated timeout period if provided.</exception>
    /// <returns>The configured and running application driver.</returns>
    /// <exception cref="LegerityException">
    /// Thrown when:
    /// - The Appium server could not be found when running with <see cref="AndroidAppManagerOptions.LaunchAppiumServer"/> or <see cref="IOSAppManagerOptions.LaunchAppiumServer"/> true.
    /// - The WinAppDriver could not be found when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// - The WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// </exception>
    public static RemoteWebDriver StartApp(
        AppManagerOptions opts,
        Func<IWebDriver, bool> waitUntil = default,
        TimeSpan? waitUntilTimeout = default,
        int waitUntilRetries = 0)
    {
        RemoteWebDriver app = null;

        if (opts is AppiumManagerOptions appiumOpts)
        {
            appiumOpts.Configure();
        }

        try
        {
            switch (opts)
            {
                case WebAppManagerOptions webOpts:
                {
                    app = webOpts.DriverType switch
                    {
                        WebAppDriverType.Chrome => new ChromeDriver(
                            webOpts.DriverUri,
                            webOpts.DriverOptions as ChromeOptions ?? new ChromeOptions()),
                        WebAppDriverType.Firefox => new FirefoxDriver(
                            webOpts.DriverUri,
                            webOpts.DriverOptions as FirefoxOptions ?? new FirefoxOptions()),
                        WebAppDriverType.Opera => new ChromeDriver(
                            webOpts.DriverUri,
                            webOpts.DriverOptions as ChromeOptions ?? new ChromeOptions()),
                        WebAppDriverType.Safari => new SafariDriver(
                            webOpts.DriverUri,
                            webOpts.DriverOptions as SafariOptions ?? new SafariOptions()),
                        WebAppDriverType.Edge => new EdgeDriver(
                            webOpts.DriverUri,
                            webOpts.DriverOptions as EdgeOptions ?? new EdgeOptions()),
                        WebAppDriverType.InternetExplorer => new InternetExplorerDriver(
                            webOpts.DriverUri,
                            webOpts.DriverOptions as InternetExplorerOptions ?? new InternetExplorerOptions()),
                        WebAppDriverType.EdgeChromium => new EdgeDriver(
                            webOpts.DriverUri,
                            webOpts.DriverOptions as EdgeOptions ?? new EdgeOptions()),
                        _ => null
                    };

                    VerifyAppDriver(app, webOpts);

                    if (webOpts.Maximize)
                    {
                        app.Manage().Window.Maximize();
                    }
                    else
                    {
                        app.Manage().Window.Size = webOpts.DesiredSize;
                    }

                    app.Url = webOpts.Url;
                    break;
                }

                case WindowsAppManagerOptions winOpts:
                {
                    if (winOpts.LaunchWinAppDriver)
                    {
                        WinAppDriverHelper.Run();
                    }

                    app = new WindowsDriver<WindowsElement>(
                        new Uri(winOpts.DriverUri),
                        winOpts.AppiumOptions);

                    VerifyAppDriver(app, winOpts);

                    if (winOpts.Maximize)
                    {
                        app.Manage().Window.Maximize();
                    }

                    break;
                }

                case AndroidAppManagerOptions androidOpts:
                {
                    if (androidOpts.LaunchAppiumServer)
                    {
                        AppiumServerHelper.Run();
                    }

                    app = new AndroidDriver<AndroidElement>(
                        new Uri(androidOpts.DriverUri),
                        androidOpts.AppiumOptions);

                    VerifyAppDriver(app, androidOpts);
                    break;
                }

                case IOSAppManagerOptions iosOpts:
                {
                    if (iosOpts.LaunchAppiumServer)
                    {
                        AppiumServerHelper.Run();
                    }

                    app = new IOSDriver<IOSElement>(new Uri(iosOpts.DriverUri), iosOpts.AppiumOptions);

                    VerifyAppDriver(app, iosOpts);
                    break;
                }

                default:
                    VerifyAppDriver(null, opts);
                    break;
            }
        }
        catch (Exception ex)
        {
            app?.Quit();

            if (ex is LegerityException le)
            {
                throw le;
            }

            throw new DriverLoadFailedException(opts, ex);
        }

        if (waitUntil != null)
        {
            app.WaitUntil(waitUntil, waitUntilTimeout, waitUntilRetries);
        }

        App = app;
        StartedApps.Add(app);
        return app;
    }

    /// <summary>
    /// Stops the <see cref="App"/>, with an option to stop the running Appium or WinAppDriver server.
    /// </summary>
    /// <param name="stopServer">
    /// An optional value indicating whether to stop the running Appium or WinAppDriver server. Default, <b>true</b>.
    /// </param>
    public static void StopApp(bool stopServer = true)
    {
        StopApp(App, stopServer);
        App = null;
    }

    /// <summary>
    /// Stops an application driver, with an option to stop the running Appium or WinAppDriver server.
    /// </summary>
    /// <param name="app">
    /// The <see cref="IWebDriver"/> instance to stop running.
    /// </param>
    /// <param name="stopServer">
    /// An optional value indicating whether to stop the running Appium or WinAppDriver server. Default, <b>false</b>.
    /// </param>
    public static void StopApp(RemoteWebDriver app, bool stopServer = false)
    {
        app?.Quit();
        StartedApps.Remove(app);

        if (!stopServer)
        {
            return;
        }

        WinAppDriverHelper.Stop();
        AppiumServerHelper.Stop();
    }

    /// <summary>
    /// Stops all running application drivers.
    /// </summary>
    public static void StopApps()
    {
        StartedApps.ForEach(driver => driver?.Quit());
        StartedApps.Clear();
    }

    /// <exception cref="T:Legerity.Exceptions.DriverLoadFailedException">Thrown when the driver could not be verified.</exception>
    private static void VerifyAppDriver(RemoteWebDriver app, AppManagerOptions opts)
    {
        if (app?.SessionId == null)
        {
            throw new DriverLoadFailedException(opts);
        }

        // Set implicit timeout to 2 seconds to make element search to retry every 500 ms for at most three times.
        app.Manage().Timeouts().ImplicitWait = opts.ImplicitWait;
    }
}