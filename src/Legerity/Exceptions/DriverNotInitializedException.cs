namespace Legerity.Exceptions
{
    /// <summary>
    /// Defines an exception thrown when an attempt is made to access a driver which has not been initialized.
    /// </summary>
    public class DriverNotInitializedException : LegerityException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DriverNotInitializedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        internal DriverNotInitializedException(string message)
            : base(message)
        {
        }
    }
}