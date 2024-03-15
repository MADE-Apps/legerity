namespace Legerity.Windows.Exceptions;

using System;

/// <summary>
/// Defines an exception for when the WinAppDriver could not be loaded.
/// </summary>
public class WinAppDriverLoadFailedException : LegerityException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WinAppDriverLoadFailedException"/> class.
    /// </summary>
    /// <param name="path">The expected path for the WinAppDriver.</param>
    /// <param name="exception">The inner exception thrown by the failure to load the WinAppDriver.</param>
    internal WinAppDriverLoadFailedException(string path, Exception exception)
        : base($"The WinAppDriver could not be loaded at {path}.", exception)
    {
        Path = path;
    }

    /// <summary>
    /// Gets or sets the path where the WinAppDriver should have loaded from.
    /// </summary>
    public string Path { get; set; }
}
