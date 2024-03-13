namespace Legerity.Windows.Extensions;

using System;
using Legerity.Exceptions;

/// <summary>
/// Defines a collection of extensions for <see cref="LegerityTestClass"/> instances.
/// </summary>
public static class LegerityTestClassExtensions
{
    /// <summary>
    /// Starts the Windows application ready for testing.
    /// </summary>
    /// <param name="testClass">
    /// The test class to launch an Android application for.
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
    /// <returns>The configured and running application driver.</returns>
    /// <exception cref="WebDriverException">Thrown when the wait until condition is not met in the allocated timeout period if provided.</exception>
    /// <exception cref="DriverLoadFailedException">Thrown when the application is null, the session ID is null once initialized, or the driver fails to configure correctly before returning.</exception>
    /// <exception cref="LegerityException">Thrown when:
    /// - The WinAppDriver could not be found when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// - The WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// </exception>
    public static WindowsDriver StartWindowsApp(
        this LegerityTestClass testClass,
        Func<IWebDriver, bool> waitUntil = default,
        TimeSpan? waitUntilTimeout = default,
        int waitUntilRetries = 0)
    {
        return testClass.StartApp(waitUntil, waitUntilTimeout, waitUntilRetries) as WindowsDriver;
    }

    /// <summary>
    /// Starts the Windows application ready for testing.
    /// </summary>
    /// <param name="testClass">
    /// The test class to launch an Android application for.
    /// </param>
    /// <param name="options">
    /// The optional options to configure the driver with.
    /// <para>
    /// Settings this will override the <see cref="LegerityTestClass.Options"/> if previously set.
    /// </para>
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
    /// <returns>The configured and running application driver.</returns>
    /// <exception cref="DriverLoadFailedException">Thrown when the application is null, the session ID is null once initialized, or the driver fails to configure correctly before returning.</exception>
    /// <exception cref="LegerityException">Thrown when:
    /// - The WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// </exception>
    /// <exception cref="WebDriverException">Thrown when the wait until condition is not met in the allocated timeout period if provided.</exception>
    public static WindowsDriver StartWindowsApp(
        this LegerityTestClass testClass,
        WindowsAppManagerOptions options,
        Func<IWebDriver, bool> waitUntil = default,
        TimeSpan? waitUntilTimeout = default,
        int waitUntilRetries = 0)
    {
        return testClass.StartApp(options, waitUntil, waitUntilTimeout, waitUntilRetries) as
            WindowsDriver;
    }
}
