namespace Legerity
{
    using System;

    using Legerity.Android;
    using Legerity.Exceptions;
    using Legerity.Windows;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a manager for the application under test.
    /// </summary>
    public static class AppManager
    {
        private static WindowsDriver<WindowsElement> windowsApp;

        private static AndroidDriver<AndroidElement> androidApp;

        /// <summary>
        /// Gets the instance of the started Windows application.
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// Thrown if the <see cref="WindowsApp"/> is null as a result of not calling <see cref="StartApp"/>.
        /// </exception>
        public static WindowsDriver<WindowsElement> WindowsApp
        {
            get
            {
                if (windowsApp == null)
                {
                    throw new DriverNotInitializedException(
                        "'AppManager.WindowsApp' not set. Call 'AppManager.StartApp()' with WindowsAppManagerOptions before trying to access it.");
                }

                return windowsApp;
            }
        }

        /// <summary>
        /// Gets the instance of the started Android application.
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// Thrown if the <see cref="AndroidApp"/> is null as a result of not calling <see cref="StartApp"/>.
        /// </exception>
        public static AndroidDriver<AndroidElement> AndroidApp
        {
            get
            {
                if (androidApp == null)
                {
                    throw new DriverNotInitializedException(
                        "'AppManager.AndroidApp' not set. Call 'AppManager.StartApp()' with AndroidAppManagerOptions before trying to access it.");
                }

                return androidApp;
            }
        }

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
            if (windowsApp != null)
            {
                return;
            }

            StopApp();

            switch (opts)
            {
                case WindowsAppManagerOptions winOpts:
                {
                    windowsApp = new WindowsDriver<WindowsElement>(
                        new Uri(winOpts.AppiumDriverUrl),
                        winOpts.AppiumOptions);

                    if (windowsApp?.SessionId == null)
                    {
                        throw new DriverLoadFailedException(opts);
                    }

                    // Set implicit timeout to 2 seconds to make element search to retry every 500 ms for at most three times
                    windowsApp.Manage().Timeouts().ImplicitWait = winOpts.ImplicitWait;
                    break;
                }

                case AndroidAppManagerOptions androidOpts:
                {
                    androidApp = new AndroidDriver<AndroidElement>(
                        new Uri(androidOpts.AppiumDriverUrl),
                        androidOpts.AppiumOptions);

                    if (androidApp?.SessionId == null)
                    {
                        throw new DriverLoadFailedException(opts);
                    }

                    // Set implicit timeout to 2 seconds to make element search to retry every 500 ms for at most three times
                    androidApp.Manage().Timeouts().ImplicitWait = androidOpts.ImplicitWait;
                    break;
                }
            }
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void StopApp()
        {
            if (windowsApp != null)
            {
                windowsApp.Quit();
                windowsApp = null;
            }

            if (androidApp != null)
            {
                androidApp.Quit();
                androidApp = null;
            }
        }
    }
}