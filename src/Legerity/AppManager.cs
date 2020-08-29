namespace Legerity
{
    using System;

    using Legerity.Android;
    using Legerity.Exceptions;
    using Legerity.IOS;
    using Legerity.Web;
    using Legerity.Windows;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
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
        public static WindowsDriver<WindowsElement> WindowsApp => WebApp as WindowsDriver<WindowsElement>;

        /// <summary>
        /// Gets the instance of the started Android application.
        /// </summary>
        public static AndroidDriver<AndroidElement> AndroidApp => WebApp as AndroidDriver<AndroidElement>;

        /// <summary>
        /// Gets the instance of the started iOS application.
        /// </summary>
        public static IOSDriver<IOSElement> IOSApp => WebApp as IOSDriver<IOSElement>;

        /// <summary>
        /// Get the instance of the started web application.
        /// </summary>
        public static RemoteWebDriver WebApp { get; set; }

        /// <summary>
        /// Starts the application ready for testing.
        /// </summary>
        /// <param name="opts">
        /// The options to configure the driver with.
        /// </param>
        /// <exception cref="DriverLoadFailedException">
        /// Thrown if the application is null or the session ID is null once initialized.
        /// </exception>
        public static void StartApp(AppManagerOptions opts)
        {
            StopApp();

            switch (opts)
            {
                case WebAppManagerOptions webOpts:
                    {
                        switch (webOpts.DriverType)
                        {
                            case WebAppDriverType.Chrome:
                                WebApp = new ChromeDriver(webOpts.DriverUri);
                                break;
                            case WebAppDriverType.Firefox:
                                WebApp = new FirefoxDriver(webOpts.DriverUri);
                                break;
                            case WebAppDriverType.Opera:
                                WebApp = new OperaDriver(webOpts.DriverUri);
                                break;
                            case WebAppDriverType.Safari:
                                WebApp = new SafariDriver(webOpts.DriverUri);
                                break;
                            case WebAppDriverType.Edge:
                                WebApp = new EdgeDriver(webOpts.DriverUri);
                                break;
                            case WebAppDriverType.InternetExplorer:
                                WebApp = new InternetExplorerDriver(webOpts.DriverUri);
                                break;
                        }

                        VerifyAppDriver(WebApp, webOpts);

                        if (webOpts.Maximize)
                        {
                            WebApp.Manage().Window.Maximize();
                        }
                        else
                        {
                            WebApp.Manage().Window.Size = webOpts.DesiredSize;
                        }

                        WebApp.Url = webOpts.Url;
                        break;
                    }
                case WindowsAppManagerOptions winOpts:
                    {
                        WebApp = new WindowsDriver<WindowsElement>(
                            new Uri(winOpts.DriverUri),
                            winOpts.AppiumOptions);

                        VerifyAppDriver(WindowsApp, winOpts);
                        break;
                    }

                case AndroidAppManagerOptions androidOpts:
                    {
                        WebApp = new AndroidDriver<AndroidElement>(
                            new Uri(androidOpts.DriverUri),
                            androidOpts.AppiumOptions);

                        VerifyAppDriver(AndroidApp, androidOpts);
                        break;
                    }

                case IOSAppManagerOptions iosOpts:
                    {
                        WebApp = new IOSDriver<IOSElement>(new Uri(iosOpts.DriverUri), iosOpts.AppiumOptions);

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
            if (WebApp != null)
            {
                WebApp.Quit();
                WebApp = null;
            }
        }

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