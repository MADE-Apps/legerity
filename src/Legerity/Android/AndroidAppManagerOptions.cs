namespace Legerity.Android
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Enums;

    /// <summary>
    /// Defines a specific <see cref="AppManagerOptions"/> for an Android application.
    /// </summary>
    public class AndroidAppManagerOptions : AppManagerOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AndroidAppManagerOptions"/> class.
        /// </summary>
        /// <param name="appId">
        /// The ID of the application under test, e.g. com.instagram.android.
        /// </param>
        /// <param name="appActivity">
        /// The activity of the application to start, e.g. com.instagram.android.activity.MainTabActivity.
        /// </param>
        /// <param name="androidVersion">
        /// The version of Android to run the application on.
        /// </param>
        /// <param name="deviceName">
        /// The name of the Android device to run the application on.
        /// </param>
        public AndroidAppManagerOptions(string appId, string appActivity, string androidVersion, string deviceName)
            : this(appId, appActivity, androidVersion, deviceName, null)
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
        /// <param name="androidVersion">
        /// The version of Android to run the application on.
        /// </param>
        /// <param name="deviceName">
        /// The name of the Android device to run the application on.
        /// </param>
        /// <param name="additionalOptions">
        /// The additional options to apply to the <see cref="AppiumOptions"/>.
        /// </param>
        public AndroidAppManagerOptions(
            string appId,
            string appActivity,
            string androidVersion,
            string deviceName,
            params (string, object)[] additionalOptions)
        {
            this.AppId = appId;
            this.AppActivity = appActivity;
            this.AndroidVersion = androidVersion;
            this.DeviceName = deviceName;
            this.Configure(additionalOptions);
        }

        /// <summary>
        /// Gets the ID of the application under test.
        /// </summary>
        public string AppId { get; }

        /// <summary>
        /// Gets the activity of the application to start, e.g. com.instagram.android.activity.MainTabActivity.
        /// </summary>
        public string AppActivity { get; }

        /// <summary>
        /// Gets the version of Android to run the application on.
        /// </summary>
        public string AndroidVersion { get; }

        /// <summary>
        /// Gets the name of the Android device to run the application on.
        /// </summary>
        public string DeviceName { get; }

        /// <summary>
        /// Configures the <see cref="AppManagerOptions.AppiumOptions"/> with the specified additional options.
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
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, this.AndroidVersion);
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, this.DeviceName);
            options.AddAdditionalCapability("appPackage", this.AppId);
            options.AddAdditionalCapability("appActivity", this.AppActivity);

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
            return $"{base.ToString()}, AppId [{this.AppId}]";
        }
    }
}