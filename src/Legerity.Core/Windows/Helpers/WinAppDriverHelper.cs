namespace Legerity.Windows.Helpers;

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Exceptions;

/// <summary>
/// Defines a helper class for the WinAppDriver.
/// </summary>
public static class WinAppDriverHelper
{
    /// <summary>
    /// Defines the default install location for the WinAppDriver.
    /// </summary>
    internal const string DefaultInstallLocation =
        @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";

    private static Process WinAppDriverProcess { get; set; }

    /// <summary>
    /// Determines whether the WinAppDriver is installed.
    /// </summary>
    /// <param name="path">The expected path for the WinAppDriver.</param>
    /// <returns>True if the WinAppDriver exists at the specified <paramref name="path"/>; otherwise, false.</returns>
    public static bool IsInstalled(string path = DefaultInstallLocation)
    {
        return File.Exists(path);
    }

    /// <summary>
    /// Loads an instance of the WinAppDriver process.
    /// </summary>
    /// <param name="path">The expected path for the WinAppDriver.</param>
    /// <exception cref="WinAppDriverNotFoundException">Thrown when the WinAppDriver could not be found.</exception>
    /// <exception cref="WinAppDriverLoadFailedException">Thrown when the WinAppDriver fails to load.</exception>
    public static void Run(string path = DefaultInstallLocation)
    {
        WinAppDriverProcess ??= Process.GetProcessesByName("WinAppDriver").FirstOrDefault();
        if (WinAppDriverProcess is { HasExited: false })
        {
            return;
        }

        var isInstalled = IsInstalled(path);
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
            if (WinAppDriverProcess is { HasExited: false })
            {
                WinAppDriverProcess.Kill();
            }
        }
        catch (Exception)
        {
        }
    }
}
