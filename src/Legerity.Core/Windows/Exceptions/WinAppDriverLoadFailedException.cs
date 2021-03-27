namespace Legerity.Windows.Exceptions
{
    using System;

    /// <summary>
    /// Defines an exception for when the WinAppDriver could not be loaded.
    /// </summary>
    public class WinAppDriverLoadFailedException : LegerityException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WinAppDriverLoadFailedException"/> class.
        /// </summary>
        internal WinAppDriverLoadFailedException(string path, Exception exception) : base($"The WinAppDriver could not be loaded at {path}.")
        {
            this.Path = path;
        }

        /// <summary>
        /// Gets or sets the path where the WinAppDriver should have loaded from.
        /// </summary>
        public string Path { get; set; }
    }
}