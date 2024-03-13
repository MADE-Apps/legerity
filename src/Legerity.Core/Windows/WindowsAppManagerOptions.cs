namespace Legerity.Windows;

using System.Collections.Generic;
using Helpers;

/// <summary>
/// Defines a specific <see cref="AppiumManagerOptions"/> for a Windows application.
/// </summary>
public class WindowsAppManagerOptions : AppiumManagerOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowsAppManagerOptions"/> class.
    /// </summary>
    public WindowsAppManagerOptions()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowsAppManagerOptions"/> class.
    /// </summary>
    /// <param name="appId">
    /// The ID of the application under test.
    /// </param>
    public WindowsAppManagerOptions(string appId)
        : this(appId, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowsAppManagerOptions"/> class.
    /// </summary>
    /// <param name="appId">
    /// The ID of the application under test.
    /// </param>
    /// <param name="additionalOptions">
    /// The additional options to apply to the <see cref="AppiumOptions"/>.
    /// </param>
    public WindowsAppManagerOptions(string appId, params (string, object)[] additionalOptions)
    {
        AppId = appId;
        AdditionalOptions = additionalOptions;
    }

    /// <summary>
    /// Gets or sets the ID of the application under test.
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to launch the WinAppDriver if it is not already running.
    /// </summary>
    public bool LaunchWinAppDriver { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to maximize the window for the application.
    /// </summary>
    public bool Maximize { get; set; }

    /// <summary>
    /// Gets or sets the path to the WinAppDriver installation for launch.
    /// <para>
    /// By default, the path will be the default install location; C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe.
    /// </para>
    /// </summary>
    public string WinAppDriverPath { get; set; } = WinAppDriverHelper.DefaultInstallLocation;

    /// <summary>
    /// Configures the <see cref="AppiumManagerOptions.AppiumOptions"/> with the specified additional options.
    /// </summary>
    public override void Configure()
    {
        base.Configure();
        AppiumOptions.AddAdditionalAppiumOption("app", AppId);
    }

    /// <summary>
    /// Configures the <see cref="AppiumOptions"/> with the specified additional options.
    /// </summary>
    /// <param name="additionalOptions">
    /// The additional options to apply to the <see cref="AppiumOptions"/>.
    /// </param>
    public void Configure((string, object)[] additionalOptions)
    {
        AdditionalOptions = additionalOptions;
        Configure();
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"Platform [Windows], {base.ToString()}, {GetOptionDetails()}";
    }

    private string GetOptionDetails()
    {
        var options = new List<string>();

        if (!string.IsNullOrWhiteSpace(AppId))
        {
            options.Add($"App ID [{AppId}]");
        }

        if (AdditionalOptions == null)
        {
            return string.Join(", ", options);
        }

        foreach (var (name, value) in AdditionalOptions)
        {
            options.Add($"{name} [{value}]");
        }

        return string.Join(", ", options);
    }
}
