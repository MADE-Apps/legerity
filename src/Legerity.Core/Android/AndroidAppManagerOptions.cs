namespace Legerity.Android
{
    using System;
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
        /// <param name="osVersion">
        /// The version of Android to run the application on.
        /// </param>
        /// <param name="deviceName">
        /// The name of the Android device to run the application on.
        /// </param>
        /// <param name="deviceId">
        /// The ID of the Android device to run the application on.
        /// </param>
        [Obsolete("This constructor will be removed in a future major release. Please use the (string appId, string appActivity) instead and provide optional parameters for configuring for the device needed.")]
        public AndroidAppManagerOptions(
            string appId,
            string appActivity,
            string osVersion,
            string deviceName,
            string deviceId)
            : this(appId, appActivity, null, osVersion, deviceName, deviceId, null)
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
        [Obsolete("This constructor will be removed in a future major release. Please use the (string appId, string appActivity, params (string, object)[] additionalOptions) instead and provide optional parameters for configuring for the device needed.")]
        public AndroidAppManagerOptions(
            string appId,
            string appActivity,
            string osVersion,
            string deviceName,
            string deviceId,
            params (string, object)[] additionalOptions) : this(appId, appActivity, null, osVersion, deviceName, deviceId, additionalOptions)
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
            this.AppId = appId;
            this.AppActivity = appActivity;
            this.AppPath = appPath;
            this.OSVersion = osVersion;
            this.DeviceName = deviceName;
            this.DeviceId = deviceId;
            this.Configure(additionalOptions);
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
        /// Configures the <see cref="AppiumOptions"/> with the specified additional options.
        /// <para>
        /// By default, the <see cref="AppId"/> will be added to the options as capability 'app'.
        /// </para>
        /// </summary>
        /// <param name="additionalOptions">
        /// The additional options to apply to the <see cref="AppiumOptions"/>.
        /// </param>
        public void Configure((string, object)[] additionalOptions)
        {
            var options = new AppiumOptions();

            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");

            if (!string.IsNullOrWhiteSpace(this.OSVersion))
            {
                options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, this.OSVersion);
            }

            if (!string.IsNullOrWhiteSpace(this.DeviceName))
            {
                options.AddAdditionalCapability(MobileCapabilityType.DeviceName, this.DeviceName);
            }

            if (!string.IsNullOrWhiteSpace(this.DeviceId))
            {
                options.AddAdditionalCapability(MobileCapabilityType.Udid, this.DeviceId);
            }

            if (!string.IsNullOrWhiteSpace(this.AppId))
            {
                options.AddAdditionalCapability("appPackage", this.AppId);
            }

            if (!string.IsNullOrWhiteSpace(this.AppActivity))
            {
                options.AddAdditionalCapability("appActivity", this.AppActivity);
            }

            if (!string.IsNullOrWhiteSpace(this.AppPath))
            {
                options.AddAdditionalCapability("app", this.AppPath);
            }

            if (additionalOptions != null)
            {
                foreach ((string capabilityName, object capabilityValue) in additionalOptions)
                {
                    options.AddAdditionalCapability(capabilityName, capabilityValue);
                }
            }

            this.AppiumOptions = options;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Platform [Android], {base.ToString()}, {this.GetOptionDetails()}";
        }

        private string GetOptionDetails()
        {
            var options = new List<string>();

            if (!string.IsNullOrWhiteSpace(this.AppId))
            {
                options.Add($"App ID [{this.AppId}]");
            }

            if (!string.IsNullOrWhiteSpace(this.AppPath))
            {
                options.Add($"App Path [{this.AppPath}]");
            }

            if (!string.IsNullOrWhiteSpace(this.DeviceId))
            {
                options.Add($"Device ID [{this.DeviceId}]");
            }

            if (!string.IsNullOrWhiteSpace(this.DeviceName))
            {
                options.Add($"Device Name [{this.DeviceName}]");
            }

            return string.Join(", ", options);
        }
    }
}
