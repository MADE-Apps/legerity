namespace Legerity.Windows.Exceptions;

/// <summary>
/// Defines an exception for when the WinAppDriver cannot be found.
/// </summary>
public class WinAppDriverNotFoundException : LegerityException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WinAppDriverNotFoundException"/> class.
    /// </summary>
    /// <param name="path">The expected path for the WinAppDriver.</param>
    internal WinAppDriverNotFoundException(string path)
        : base($"The WinAppDriver could not be located at {path}. Please ensure it is installed first.")
    {
        Path = path;
    }

    /// <summary>
    /// Gets or sets the path where the WinAppDriver should be located.
    /// </summary>
    public string Path { get; set; }
}