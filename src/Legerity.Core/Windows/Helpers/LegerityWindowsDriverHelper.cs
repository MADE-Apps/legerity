// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Net;
using Legerity.Windows.Exceptions;

namespace Legerity.Windows.Helpers;

/// <summary>
/// Defines a helper class for the Legerity Windows Driver.
/// </summary>
public static class LegerityWindowsDriverHelper
{
    /// <summary>
    /// Gets or sets the path to the Legerity Windows Driver executable.
    /// <para>
    /// When not set, the helper searches for <c>Legerity.WindowsDriver.exe</c> on the system PATH.
    /// </para>
    /// </summary>
    public static string DriverPath { get; set; }

    private static Process DriverProcess { get; set; }

    /// <summary>
    /// Starts the Legerity Windows Driver server on the specified port.
    /// </summary>
    /// <param name="port">The port to run the driver server on. Default is 4723.</param>
    /// <exception cref="WindowsDriverLoadFailedException">Thrown when the driver fails to start.</exception>
    public static void Run(int port = 4723)
    {
        if (DriverProcess is { HasExited: false })
        {
            return;
        }

        var exePath = ResolveDriverPath();

        try
        {
            DriverProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = $"--port {port}",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            DriverProcess.Start();
            WaitForServerReady(port, TimeSpan.FromSeconds(30));
        }
        catch (Exception ex) when (ex is not WindowsDriverLoadFailedException)
        {
            throw new WindowsDriverLoadFailedException($"The Legerity Windows Driver could not be started: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Stops the running instance of the Legerity Windows Driver process.
    /// </summary>
    public static void Stop()
    {
        try
        {
            if (DriverProcess is { HasExited: false })
            {
                DriverProcess.Kill();
                DriverProcess.WaitForExit(5000);
            }
        }
        catch
        {
            // Best effort cleanup
        }
        finally
        {
            DriverProcess = null;
        }
    }

    private static void WaitForServerReady(int port, TimeSpan timeout)
    {
        using var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(2) };
        var deadline = DateTime.UtcNow + timeout;

        while (DateTime.UtcNow < deadline)
        {
            try
            {
                var response = httpClient
                    .GetAsync($"http://localhost:{port}/status")
                    .GetAwaiter().GetResult();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return;
                }
            }
            catch
            {
                // Server not ready yet
            }

            Thread.Sleep(250);
        }

        throw new WindowsDriverLoadFailedException(
            $"Legerity Windows Driver did not become ready on port {port} within {timeout.TotalSeconds}s.");
    }

    private static string ResolveDriverPath()
    {
        const string exeName = "Legerity.WindowsDriver.exe";
        const string packageId = "legerity.windowsdriver";

        // 1. Explicit path set by caller
        if (!string.IsNullOrEmpty(DriverPath))
        {
            if (File.Exists(DriverPath))
            {
                return DriverPath;
            }

            throw new WindowsDriverLoadFailedException(
                $"The Legerity Windows Driver was not found at the specified path: {DriverPath}");
        }

        // 2. Check PATH
        var pathDirs = Environment.GetEnvironmentVariable("PATH")?.Split(Path.PathSeparator) ?? [];
        foreach (var dir in pathDirs)
        {
            var candidate = Path.Combine(dir, exeName);
            if (File.Exists(candidate))
            {
                return candidate;
            }
        }

        // 3. Check local build output (development scenario)
        var assemblyDir = Path.GetDirectoryName(typeof(LegerityWindowsDriverHelper).Assembly.Location);
        if (assemblyDir != null)
        {
            var searchDir = new DirectoryInfo(assemblyDir);
            while (searchDir != null)
            {
                foreach (var config in new[] { "Debug", "Release" })
                {
                    var tfmDir = Path.Combine(searchDir.FullName, "tools", "Legerity.WindowsDriver", "bin", config, "net10.0-windows");
                    if (Directory.Exists(tfmDir))
                    {
                        var matches = Directory.GetFiles(tfmDir, exeName, SearchOption.AllDirectories);
                        if (matches.Length > 0)
                        {
                            return matches[0];
                        }
                    }
                }

                searchDir = searchDir.Parent;
            }
        }

        // 4. Check NuGet global packages folder
        var nugetDir = Environment.GetEnvironmentVariable("NUGET_PACKAGES")
            ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget", "packages");
        var packageDir = Path.Combine(nugetDir, packageId);
        if (Directory.Exists(packageDir))
        {
            var versions = Directory.GetDirectories(packageDir)
                .OrderByDescending(d => d)
                .ToArray();

            foreach (var versionDir in versions)
            {
                var toolsDir = Path.Combine(versionDir, "tools");
                if (Directory.Exists(toolsDir))
                {
                    var matches = Directory.GetFiles(toolsDir, exeName, SearchOption.AllDirectories);
                    if (matches.Length > 0)
                    {
                        return matches[0];
                    }
                }
            }
        }

        throw new WindowsDriverLoadFailedException(
            $"The Legerity Windows Driver executable ({exeName}) could not be found. " +
            "Install the Legerity.WindowsDriver NuGet package, set LegerityWindowsDriverHelper.DriverPath, " +
            "or ensure it is on your PATH.");
    }
}
