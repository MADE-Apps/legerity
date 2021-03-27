namespace Legerity.IOS
{
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
            this.Configure(additionalOptions);
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

            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, this.OSVersion);
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, this.DeviceName);
            options.AddAdditionalCapability(MobileCapabilityType.Udid, this.DeviceId);
            options.AddAdditionalCapability(MobileCapabilityType.App, this.AppId);

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
            return $"{base.ToString()}, App ID [{this.AppId}]";
        }
    }
}
