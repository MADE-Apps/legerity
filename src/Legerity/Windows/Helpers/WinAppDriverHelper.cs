namespace Legerity.Windows.Helpers
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Exceptions;

    /// <summary>
    /// Defines a helper class for the WinAppDriver.
    /// </summary>
    public static class WinAppDriverHelper
    {
        internal const string DefaultInstallLocation =
            @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";

        private static Process WinAppDriverProcess { get; set; }

        /// <summary>
        /// Determines whether the WinAppDriver is installed.
        /// </summary>
        public static bool IsInstalled(string path = DefaultInstallLocation)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Loads an instance of the WinAppDriver process.
        /// </summary>
        /// <exception cref="T:Legerity.Windows.Exceptions.WinAppDriverNotFoundException">Thrown if the WinAppDriver could not be found.</exception>
        /// <exception cref="T:Legerity.Windows.Exceptions.WinAppDriverLoadFailedException">Thrown if the WinAppDriver failed to load.</exception>
        public static void Run(string path = DefaultInstallLocation)
        {
            if (WinAppDriverProcess != null && !WinAppDriverProcess.HasExited)
            {
                return;
            }

            bool isInstalled = IsInstalled(path);
            if (!isInstalled)
            {
                throw new WinAppDriverNotFoundException(path);
            }

            try
            {
                WinAppDriverProcess = Process.Start(path);
            }
            catch (Exception ex)
            {
                throw new WinAppDriverLoadFailedException(path, ex);
            }
        }

        /// <summary>
        /// Stops the running instance of the WinAppDriver process.
        /// </summary>
        public static void Stop()
        {
            try
            {
                if (WinAppDriverProcess != null && !WinAppDriverProcess.HasExited)
                {
                    WinAppDriverProcess.Close();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}