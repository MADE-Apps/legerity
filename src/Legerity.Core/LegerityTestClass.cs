namespace Legerity
{
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a base class for running tests with the Legerity framework.
    /// </summary>
    public abstract class LegerityTestClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegerityTestClass"/> class.
        /// <para>
        /// The <see cref="Options"/> will need to be set before calling <see cref="StartApp"/>.
        /// </para>
        /// </summary>
        protected LegerityTestClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegerityTestClass"/> class with application launch option.
        /// </summary>
        /// <param name="options">The application launch options.</param>
        protected LegerityTestClass(AppManagerOptions options)
        {
            this.Options = options;
        }

        /// <summary>
        /// Gets the instance of the started application.
        /// <para>
        /// This could be a <see cref="WindowsDriver{W}"/>, <see cref="AndroidDriver{W}"/>, <see cref="IOSDriver{W}"/>, or web driver.
        /// </para>
        /// </summary>
        protected static RemoteWebDriver App => AppManager.App;

        /// <summary>
        /// Gets or sets the model that represents the configuration options for the <see cref="AppManager"/>.
        /// </summary>
        protected AppManagerOptions Options { get; set; }

        /// <summary>
        /// Starts the application ready for testing.
        /// </summary>
        public virtual void StartApp()
        {
            AppManager.StartApp(this.Options);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public virtual void StopApp()
        {
            AppManager.StopApp();
        }
    }
}
