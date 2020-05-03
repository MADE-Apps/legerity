namespace Legerity
{
    using OpenQA.Selenium.Appium;

    /// <summary>
    /// Defines a specific <see cref="AppManagerOptions"/> for a Windows application.
    /// </summary>
    public class WindowsAppManagerOptions : AppManagerOptions
    {
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
            this.AppId = appId;
            this.Configure(additionalOptions);
        }

        /// <summary>
        /// Gets or sets the ID of the application under test.
        /// </summary>
        public string AppId { get; set; }

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
            options.AddAdditionalCapability("app", this.AppId);
            if (additionalOptions == null)
            {
                return;
            }

            foreach ((string capabilityName, object capabilityValue) in additionalOptions)
            {
                options.AddAdditionalCapability(capabilityName, capabilityValue);
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