namespace Legerity
{
    using OpenQA.Selenium.Appium;

    /// <summary>
    /// Defines a base model that represents Appium specific configuration options for the <see cref="AppManager"/>.
    /// </summary>
    public abstract class AppiumManagerOptions : AppManagerOptions
    {
        /// <summary>
        /// Gets or sets the options to configure the Appium driver.
        /// </summary>
        public AppiumOptions AppiumOptions { get; set; }
    }
}
