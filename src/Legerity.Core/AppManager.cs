namespace Legerity;

using System;
using System.Collections.Generic;
using Android;
using Exceptions;
using Extensions;
using Helpers;
using IOS;
using Legerity.Windows.Helpers;
using Web;
using Windows;

/// <summary>
/// Defines a manager for the application under test.
/// </summary>
public static class AppManager
{
    private static readonly List<WebDriver> s_startedApps = new();

    /// <summary>
    /// Gets the instance of the started Windows application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static WindowsDriver WindowsApp => App as WindowsDriver;

    /// <summary>
    /// Gets the instance of the started Android application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static AndroidDriver AndroidApp => App as AndroidDriver;

    /// <summary>
    /// Gets the instance of the started iOS application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static IOSDriver IOSApp => App as IOSDriver;

    /// <summary>
    /// Gets the instance of the started web application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static WebDriver WebApp => App;

    /// <summary>
    /// Gets or sets the instance of the started application.
    /// <para>
    /// This could be a <see cref="WindowsDriver"/>, <see cref="AndroidDriver"/>, <see cref="IOSDriver"/>, or web driver.
    /// </para>
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static WebDriver App { get; set; }

    /// <summary>
    /// Gets the instances of started applications.
    /// </summary>
    public static IReadOnlyCollection<WebDriver> Apps => s_startedApps;

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
    public static WebDriver StartApp(
        AppManagerOptions opts,
        Func<IWebDriver, bool> waitUntil = default,
        TimeSpan? waitUntilTimeout = default,
        int waitUntilRetries = 0)
    {
        WebDriver app = null;

        if (opts is AppiumManagerOptions appiumOpts)
        {
            appiumOpts.Configure();
        }

        try
        {
            switch (opts)
            {
                case WebAppManagerOptions webOpts:
                    app = StartWebApp(webOpts);
                    break;
                case WindowsAppManagerOptions winOpts:
                    app = StartWindowsApp(winOpts);
                    break;
                case AndroidAppManagerOptions androidOpts:
                    app = StartAndroidApp(androidOpts);
                    break;
                case IOSAppManagerOptions iosOpts:
                    app = StartIOSApp(iosOpts);
                    break;
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
        s_startedApps.Add(app);
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
    public static void StopApp(WebDriver app, bool stopServer = false)
    {
        app?.Quit();
        s_startedApps.Remove(app);

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
        s_startedApps.ForEach(driver => driver?.Quit());
        s_startedApps.Clear();
    }


    private static WebDriver StartIOSApp(IOSAppManagerOptions iosOpts)
    {
        if (iosOpts.LaunchAppiumServer)
        {
            AppiumServerHelper.Run();
        }

        var app = new IOSDriver(new Uri(iosOpts.DriverUri), iosOpts.AppiumOptions);

        VerifyAppDriver(app, iosOpts);
        return app;
    }

    private static WebDriver StartAndroidApp(AndroidAppManagerOptions androidOpts)
    {
        if (androidOpts.LaunchAppiumServer)
        {
            AppiumServerHelper.Run();
        }

        var app = new AndroidDriver(
            new Uri(androidOpts.DriverUri),
            androidOpts.AppiumOptions);

        VerifyAppDriver(app, androidOpts);
        return app;
    }

    private static WebDriver StartWindowsApp(WindowsAppManagerOptions winOpts)
    {
        if (winOpts.LaunchWinAppDriver)
        {
            WinAppDriverHelper.Run();
        }

        var app = new WindowsDriver(
            new Uri(winOpts.DriverUri),
            winOpts.AppiumOptions);

        VerifyAppDriver(app, winOpts);

        if (winOpts.Maximize)
        {
            app.Manage().Window.Maximize();
        }

        return app;
    }

    private static WebDriver StartWebApp(WebAppManagerOptions webOpts)
    {
        WebDriver app = webOpts.DriverType switch
        {
            WebAppDriverType.Chrome => new ChromeDriver(
                webOpts.DriverUri,
                webOpts.DriverOptions as ChromeOptions ?? new ChromeOptions()),
            WebAppDriverType.Firefox => new FirefoxDriver(
                webOpts.DriverUri,
                webOpts.DriverOptions as FirefoxOptions ?? new FirefoxOptions()),
            WebAppDriverType.Opera => new ChromeDriver(
                webOpts.DriverUri,
                webOpts.DriverOptions as OperaChromiumOptions ?? new OperaChromiumOptions()),
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
            app!.Manage().Window.Maximize();
        }
        else
        {
            app!.Manage().Window.Size = webOpts.DesiredSize;
        }

        app.Url = webOpts.Url;
        return app;
    }

    /// <exception cref="T:Legerity.Exceptions.DriverLoadFailedException">Thrown when the driver could not be verified.</exception>
    private static void VerifyAppDriver(WebDriver app, AppManagerOptions opts)
    {
        if (app?.SessionId == null)
        {
            throw new DriverLoadFailedException(opts);
        }

        // Set implicit timeout to make element search retry every x ms.
        app.Manage().Timeouts().ImplicitWait = opts.ImplicitWait;
    }
}
