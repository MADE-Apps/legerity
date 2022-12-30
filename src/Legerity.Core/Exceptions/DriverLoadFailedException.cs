namespace Legerity.Exceptions
{
    using System;

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
        /// Initializes a new instance of the <see cref="DriverLoadFailedException"/> class.
        /// </summary>
        /// <param name="opts">
        /// The app manager options used to initialize the driver.
        /// </param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        internal DriverLoadFailedException(AppManagerOptions opts, Exception innerException)
            : base($"The application driver could not be initialized with the specified app manager options. {opts}", innerException)
        {
            this.AppManagerOptions = opts;
        }

        /// <summary>
        /// Gets the app manager options used to initialize the driver.
        /// </summary>
        internal AppManagerOptions AppManagerOptions { get; }
    }
}