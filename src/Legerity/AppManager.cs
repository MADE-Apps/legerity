namespace Legerity
{
    using System;

    using Legerity.Android;
    using Legerity.Exceptions;
    using Legerity.IOS;
    using Legerity.Windows;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a manager for the application under test.
    /// </summary>
    public static class AppManager
    {
        /// <summary>
        /// Gets the instance of the started Windows application.
        /// </summary>
        public static WindowsDriver<WindowsElement> WindowsApp { get; private set; }

        /// <summary>
        /// Gets the instance of the started Android application.
        /// </summary>
        public static AndroidDriver<AndroidElement> AndroidApp { get; private set; }

        /// <summary>
        /// Gets the instance of the started iOS application.
        /// </summary>
        public static IOSDriver<IOSElement> IOSApp { get; private set; }

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
                case WindowsAppManagerOptions winOpts:
                {
                    WindowsApp = new WindowsDriver<WindowsElement>(
                        new Uri(winOpts.AppiumDriverUrl),
                        winOpts.AppiumOptions);

                    VerifyAppDriver(WindowsApp, winOpts);
                    break;
                }

                case AndroidAppManagerOptions androidOpts:
                {
                    AndroidApp = new AndroidDriver<AndroidElement>(
                        new Uri(androidOpts.AppiumDriverUrl),
                        androidOpts.AppiumOptions);

                    VerifyAppDriver(AndroidApp, androidOpts);
                    break;
                }

                case IOSAppManagerOptions iosOpts:
                {
                    IOSApp = new IOSDriver<IOSElement>(new Uri(iosOpts.AppiumDriverUrl), iosOpts.AppiumOptions);

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
            if (WindowsApp != null)
            {
                WindowsApp.Quit();
                WindowsApp = null;
            }

            if (AndroidApp != null)
            {
                AndroidApp.Quit();
                AndroidApp = null;
            }

            if (IOSApp != null)
            {
                IOSApp.Quit();
                IOSApp = null;
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