namespace Legerity.Android;

using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

/// <summary>
/// Defines a specific <see cref="AppiumManagerOptions"/> for an Android application.
/// </summary>
public class AndroidAppManagerOptions : AppiumManagerOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AndroidAppManagerOptions"/> class.
    /// </summary>
    public AndroidAppManagerOptions()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AndroidAppManagerOptions"/> class.
    /// </summary>
    /// <param name="appPath">
    /// The path of the application under test, e.g. c:/users/legerity/source/myapp/com.instagram.android.apk.
    /// </param>
    public AndroidAppManagerOptions(string appPath)
        : this(null, null, appPath, null, null, null, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AndroidAppManagerOptions"/> class.
    /// </summary>
    /// <param name="appPath">
    /// The path of the application under test, e.g. c:/users/legerity/source/myapp/com.instagram.android.apk.
    /// </param>
    /// <param name="additionalOptions">
    /// The additional options to apply to the <see cref="AppiumOptions"/>.
    /// </param>
    public AndroidAppManagerOptions(
        string appPath,
        params (string, object)[] additionalOptions)
        : this(null, null, appPath, null, null, null, additionalOptions)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AndroidAppManagerOptions"/> class.
    /// </summary>
    /// <param name="appId">
    /// The ID of the application under test, e.g. com.instagram.android.
    /// </param>
    /// <param name="appActivity">
    /// The activity of the application to start, e.g. com.instagram.android.activity.MainTabActivity.
    /// </param>
    public AndroidAppManagerOptions(
        string appId,
        string appActivity)
        : this(appId, appActivity, null, null, null, null, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AndroidAppManagerOptions"/> class.
    /// </summary>
    /// <param name="appId">
    /// The ID of the application under test, e.g. com.instagram.android.
    /// </param>
    /// <param name="appActivity">
    /// The activity of the application to start, e.g. com.instagram.android.activity.MainTabActivity.
    /// </param>
    /// <param name="additionalOptions">
    /// The additional options to apply to the <see cref="AppiumOptions"/>.
    /// </param>
    public AndroidAppManagerOptions(
        string appId,
        string appActivity,
        params (string, object)[] additionalOptions)
        : this(appId, appActivity, null, null, null, null, additionalOptions)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AndroidAppManagerOptions"/> class.
    /// </summary>
    /// <param name="appId">
    /// The ID of the application under test, e.g. com.instagram.android.
    /// </param>
    /// <param name="appActivity">
    /// The activity of the application to start, e.g. com.instagram.android.activity.MainTabActivity.
    /// </param>
    /// <param name="appPath">
    /// The path of the application under test, e.g. c:/users/legerity/source/myapp/com.instagram.android.apk.
    /// </param>
    /// <param name="osVersion">
    /// The version of Android to run the application on.
    /// </param>
    /// <param name="deviceName">
    /// The name of the Android device to run the application on.
    /// </param>
    /// <param name="deviceId">
    /// The ID of the Android device to run the application on.
    /// </param>
    /// <param name="additionalOptions">
    /// The additional options to apply to the <see cref="AppiumOptions"/>.
    /// </param>
    public AndroidAppManagerOptions(
        string appId,
        string appActivity,
        string appPath,
        string osVersion,
        string deviceName,
        string deviceId,
        params (string, object)[] additionalOptions)
    {
        AppId = appId;
        AppActivity = appActivity;
        AppPath = appPath;
        OSVersion = osVersion;
        DeviceName = deviceName;
        DeviceId = deviceId;
        AdditionalOptions = additionalOptions;
    }

    /// <summary>
    /// Gets or sets the ID of the application under test.
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// Gets or sets the activity of the application to start, e.g. com.instagram.android.activity.MainTabActivity.
    /// </summary>
    public string AppActivity { get; set; }

    /// <summary>
    /// Gets or sets the path of the application under test, e.g. c:/users/legerity/source/myapp/com.instagram.android.apk.
    /// </summary>
    public string AppPath { get; set; }

    /// <summary>
    /// Gets or sets the version of Android to run the application on.
    /// </summary>
    public string OSVersion { get; set; }

    /// <summary>
    /// Gets or sets the name of the Android device to run the application on.
    /// </summary>
    public string DeviceName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the Android device to run the application on.
    /// </summary>
    public string DeviceId { get; set; }

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

        AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformName, "Android");

        if (!string.IsNullOrWhiteSpace(OSVersion))
        {
            AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformVersion, OSVersion);
        }

        if (!string.IsNullOrWhiteSpace(DeviceName))
        {
            AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.DeviceName, DeviceName);
        }

        if (!string.IsNullOrWhiteSpace(DeviceId))
        {
            AppiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.Udid, DeviceId);
        }

        if (!string.IsNullOrWhiteSpace(AppId))
        {
            AppiumOptions.AddAdditionalAppiumOption("appPackage", AppId);
        }

        if (!string.IsNullOrWhiteSpace(AppActivity))
        {
            AppiumOptions.AddAdditionalAppiumOption("appActivity", AppActivity);
        }

        if (!string.IsNullOrWhiteSpace(AppPath))
        {
            AppiumOptions.AddAdditionalAppiumOption("app", AppPath);
        }
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
        return $"Platform [Android], {base.ToString()}, {GetOptionDetails()}";
    }

    private string GetOptionDetails()
    {
        var options = new List<string>();

        if (!string.IsNullOrWhiteSpace(AppId))
        {
            options.Add($"App ID [{AppId}]");
        }

        if (!string.IsNullOrWhiteSpace(AppPath))
        {
            options.Add($"App Path [{AppPath}]");
        }

        if (!string.IsNullOrWhiteSpace(DeviceId))
        {
            options.Add($"Device ID [{DeviceId}]");
        }

        if (!string.IsNullOrWhiteSpace(DeviceName))
        {
            options.Add($"Device Name [{DeviceName}]");
        }

        if (AdditionalOptions != null)
        {
            foreach ((var name, var value) in AdditionalOptions)
            {
                options.Add($"{name} [{value}]");
            }
        }

        return string.Join(", ", options);
    }
}
