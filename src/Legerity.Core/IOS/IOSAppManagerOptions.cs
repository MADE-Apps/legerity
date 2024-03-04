namespace Legerity.IOS;

using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

/// <summary>
/// Defines a specific <see cref="AppiumManagerOptions"/> for an iOS application.
/// </summary>
public class IOSAppManagerOptions : AppiumManagerOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IOSAppManagerOptions"/> class.
    /// </summary>
    public IOSAppManagerOptions()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IOSAppManagerOptions"/> class.
    /// </summary>
    /// <param name="appId">
    /// The ID of the application under test, e.g. com.instagram.ios.
    /// </param>
    /// <param name="osVersion">
    /// The version of iOS to run the application on.
    /// </param>
    /// <param name="deviceName">
    /// The name of the iOS device to run the application on.
    /// </param>
    /// <param name="deviceId">
    /// The ID of the Android device to run the application on.
    /// </param>
    public IOSAppManagerOptions(string appId, string osVersion, string deviceName, string deviceId)
        : this(appId, osVersion, deviceName, deviceId, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IOSAppManagerOptions"/> class.
    /// </summary>
    /// <param name="appId">
    /// The ID of the application under test, e.g. com.instagram.ios.
    /// </param>
    /// <param name="osVersion">
    /// The version of iOS to run the application on.
    /// </param>
    /// <param name="deviceName">
    /// The name of the iOS device to run the application on.
    /// </param>
    /// <param name="deviceId">
    /// The ID of the iOS device to run the application on.
    /// </param>
    /// <param name="additionalOptions">
    /// The additional options to apply to the <see cref="AppiumOptions"/>.
    /// </param>
    public IOSAppManagerOptions(
        string appId,
        string osVersion,
        string deviceName,
        string deviceId,
        params (string, object)[] additionalOptions)
    {
        this.AppId = appId;
        this.OSVersion = osVersion;
        this.DeviceName = deviceName;
        this.DeviceId = deviceId;
        this.AdditionalOptions = additionalOptions;
    }

    /// <summary>
    /// Gets or sets the ID of the application under test.
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// Gets or sets the version of iOS to run the application on.
    /// </summary>
    public string OSVersion { get; set; }

    /// <summary>
    /// Gets or sets the name of the iOS device to run the application on.
    /// </summary>
    public string DeviceName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the iOS device to run the application on.
    /// </summary>
    public string DeviceId { get; set; }

    /// <summary>
    /// Gets or sets the name of the automation tool to use to run the application. Defaults to <b>XCUITest</b>.
    /// <para>
    /// If a value is provided in the additional options, this value will override it.
    /// </para>
    /// </summary>
    public string AutomationName { get; set; } = "XCUITest";

    /// <summary>
    /// Gets or sets a value indicating whether to launch the Appium server instance.
    /// </summary>
    public bool LaunchAppiumServer { get; set; }

    /// <summary>
    /// Configures the <see cref="AppiumManagerOptions.AppiumOptions"/> with the specified additional options.
    /// </summary>
    public override void Configure()
    {
        base.Configure();

        this.AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformName, "iOS");
        this.AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformVersion, this.OSVersion);
        this.AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.DeviceName, this.DeviceName);
        this.AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.Udid, this.DeviceId);
        this.AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.App, this.AppId);
        this.AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.AutomationName, this.AutomationName);
    }

    /// <summary>
    /// Configures the <see cref="AppiumOptions"/> with the specified additional options.
    /// </summary>
    /// <param name="additionalOptions">
    /// The additional options to apply to the <see cref="AppiumOptions"/>.
    /// </param>
    public void Configure((string, object)[] additionalOptions)
    {
        this.AdditionalOptions = additionalOptions;
        this.Configure();
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"Platform [IOS], {base.ToString()}, {this.GetOptionDetails()}";
    }

    private string GetOptionDetails()
    {
        var options = new List<string>();

        if (!string.IsNullOrWhiteSpace(this.AppId))
        {
            options.Add($"App ID [{this.AppId}]");
        }

        if (!string.IsNullOrWhiteSpace(this.DeviceId))
        {
            options.Add($"Device ID [{this.DeviceId}]");
        }

        if (!string.IsNullOrWhiteSpace(this.DeviceName))
        {
            options.Add($"Device Name [{this.DeviceName}]");
        }

        if (this.AdditionalOptions != null)
        {
            foreach ((string name, object value) in this.AdditionalOptions)
            {
                options.Add($"{name} [{value}]");
            }
        }

        return string.Join(", ", options);
    }
}