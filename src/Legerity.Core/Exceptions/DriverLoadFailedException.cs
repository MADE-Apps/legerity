namespace Legerity.Exceptions
{
    /// <summary>
    /// Defines an exception thrown if the Appium driver fails to load the requested application.
    /// </summary>
    public class DriverLoadFailedException : LegerityException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DriverLoadFailedException"/> class.
        /// </summary>
        /// <param name="opts">
        /// The app manager options used to initialize the driver.
        /// </param>
        internal DriverLoadFailedException(AppManagerOptions opts)
            : base($"The application driver could not be initialized with the specified app manager options. {opts}")
        {
            this.AppManagerOptions = opts;
        }

        /// <summary>
        /// Gets the app manager options used to initialize the driver.
        /// </summary>
        internal AppManagerOptions AppManagerOptions { get; }
    }
}