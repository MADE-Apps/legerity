namespace Legerity.Helpers;

using System;
using Exceptions;

/// <summary>
/// Defines a helper class for launching a local Appium server.
/// </summary>
public static class AppiumServerHelper
{
    private static AppiumLocalService AppiumServer { get; set; }

    /// <summary>
    /// Loads an instance of the Appium server process.
    /// </summary>
    /// <exception cref="AppiumServerLoadFailedException">Thrown when the Appium server fails to load.</exception>
    public static void Run()
    {
        if (AppiumServer is { IsRunning: true })
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
            if (AppiumServer is { IsRunning: true })
            {
                AppiumServer.Dispose();
            }
        }
        catch (Exception)
        {
        }
    }
}
