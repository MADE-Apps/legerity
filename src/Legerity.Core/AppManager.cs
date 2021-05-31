namespace Legerity
{
    using System;
    using Legerity.Android;
    using Legerity.Exceptions;
    using Legerity.IOS;
    using Legerity.Web;
    using Legerity.Windows;
    using Legerity.Windows.Helpers;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Opera;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Safari;

    /// <summary>
    /// Defines a manager for the application under test.
    /// </summary>
    public static class AppManager
    {
        /// <summary>
        /// Gets the instance of the started Windows application.
        /// </summary>
        public static WindowsDriver<WindowsElement> WindowsApp => App as WindowsDriver<WindowsElement>;

        /// <summary>
        /// Gets the instance of the started Android application.
        /// </summary>
        public static AndroidDriver<AndroidElement> AndroidApp => App as AndroidDriver<AndroidElement>;

        /// <summary>
        /// Gets the instance of the started iOS application.
        /// </summary>
        public static IOSDriver<IOSElement> IOSApp => App as IOSDriver<IOSElement>;

        /// <summary>
        /// Get the instance of the started web application.
        /// </summary>
        public static RemoteWebDriver WebApp => App;

        /// <summary>
        /// Gets the instance of the started application.
        /// <para>
        /// This could be a <see cref="WindowsDriver{W}"/>, <see cref="AndroidDriver{W}"/>, <see cref="IOSDriver{W}"/>, or web driver.
        /// </para>
        /// </summary>
        public static RemoteWebDriver App { get; set; }

        /// <summary>
        /// Starts the application ready for testing.
        /// </summary>
        /// <param name="opts">
        /// The options to configure the driver with.
        /// </param>
        /// <exception cref="DriverLoadFailedException">
        /// Thrown if the application is null or the session ID is null once initialized.
        /// </exception>
        /// <exception cref="T:Legerity.Windows.Exceptions.WinAppDriverNotFoundException">Thrown if the WinAppDriver could not be found when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.</exception>
        /// <exception cref="T:Legerity.Windows.Exceptions.WinAppDriverLoadFailedException">Thrown if the WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.</exception>
        public static void StartApp(AppManagerOptions opts)
        {
            StopApp();

            switch (opts)
            {
                case WebAppManagerOptions webOpts:
                    {
                        App = webOpts.DriverType switch
                        {
                            WebAppDriverType.Chrome => new ChromeDriver(webOpts.DriverUri),
                            WebAppDriverType.Firefox => new FirefoxDriver(webOpts.DriverUri),
                            WebAppDriverType.Opera => new OperaDriver(webOpts.DriverUri),
                            WebAppDriverType.Safari => new SafariDriver(webOpts.DriverUri),
                            WebAppDriverType.Edge => new EdgeDriver(webOpts.DriverUri),
                            WebAppDriverType.InternetExplorer => new InternetExplorerDriver(webOpts.DriverUri),
                            _ => App
                        };

                        VerifyAppDriver(App, webOpts);

                        if (webOpts.Maximize)
                        {
                            App.Manage().Window.Maximize();
                        }
                        else
                        {
                            App.Manage().Window.Size = webOpts.DesiredSize;
                        }

                        App.Url = webOpts.Url;
                        break;
                    }
                case WindowsAppManagerOptions winOpts:
                    {
                        if (winOpts.LaunchWinAppDriver)
                        {
                            WinAppDriverHelper.Run();
                        }

                        App = new WindowsDriver<WindowsElement>(
                            new Uri(winOpts.DriverUri),
                            winOpts.AppiumOptions);

                        VerifyAppDriver(WindowsApp, winOpts);

                        if (winOpts.Maximize)
                        {
                            App.Manage().Window.Maximize();
                        }

                        break;
                    }

                case AndroidAppManagerOptions androidOpts:
                    {
                        App = new AndroidDriver<AndroidElement>(
                            new Uri(androidOpts.DriverUri),
                            androidOpts.AppiumOptions);

                        VerifyAppDriver(AndroidApp, androidOpts);
                        break;
                    }

                case IOSAppManagerOptions iosOpts:
                    {
                        App = new IOSDriver<IOSElement>(new Uri(iosOpts.DriverUri), iosOpts.AppiumOptions);

                        VerifyAppDriver(IOSApp, iosOpts);
                        break;
                    }
            }
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void StopApp()
        {
            if (App != null)
            {
                App.Quit();
                App = null;
            }

            WinAppDriverHelper.Stop();
        }

        /// <exception cref="T:Legerity.Exceptions.DriverLoadFailedException">Condition.</exception>
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
}