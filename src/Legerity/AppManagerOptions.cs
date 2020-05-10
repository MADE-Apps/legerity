namespace Legerity
{
    using System;

    using OpenQA.Selenium.Appium;

    /// <summary>
    /// Defines a base model that represents configuration options for the <see cref="AppManager"/>.
    /// </summary>
    public abstract class AppManagerOptions
    {
        /// <summary>
        /// Gets or sets the URL to the Appium driver.
        /// </summary>
        public string AppiumDriverUrl { get; set; }

        /// <summary>
        /// Gets or sets the options to configure the Appium driver.
        /// </summary>
        public AppiumOptions AppiumOptions { get; set; }

        /// <summary>
        /// Gets or sets the implicit wait timeout, which is the amount of time the driver should wait when searching for an element if it is not immediately present.
        /// <para>
        /// By default, the wait time will be 2 seconds.
        /// </para>
        /// </summary>
        public TimeSpan ImplicitWait { get; set; } = TimeSpan.FromSeconds(2);

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"AppiumDriverUrl [{this.AppiumDriverUrl}]";
        }
    }
}