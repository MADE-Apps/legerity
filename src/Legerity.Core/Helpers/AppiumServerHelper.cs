namespace Legerity.Helpers
{
    using System;
    using Legerity.Exceptions;
    using OpenQA.Selenium.Appium.Service;

    /// <summary>
    /// Defines a helper class for launching a local Appium server.
    /// </summary>
    public static class AppiumServerHelper
    {
        private static AppiumLocalService AppiumServer { get; set; }

        /// <summary>
        /// Loads an instance of the Appium server process.
        /// </summary>
        /// <exception cref="T:Legerity.Exceptions.AppiumServerLoadFailedException">Thrown if the Appium server failed to load.</exception>
        public static void Run()
        {
            if (AppiumServer?.IsRunning ?? false)
            {
                return;
            }

            try
            {
                AppiumServer = AppiumLocalService.BuildDefaultService();
                AppiumServer.Start();
            }
            catch (Exception ex)
            {
                throw new AppiumServerLoadFailedException(ex);
            }
        }

        /// <summary>
        /// Stops the running instance of the WinAppDriver process.
        /// </summary>
        public static void Stop()
        {
            try
            {
                if (AppiumServer.IsRunning)
                {
                    AppiumServer.Dispose();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}