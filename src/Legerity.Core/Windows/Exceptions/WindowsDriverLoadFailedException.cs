// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Windows.Exceptions;

/// <summary>
/// Defines an exception for when the Legerity Windows Driver could not be loaded.
/// </summary>
public class WindowsDriverLoadFailedException : LegerityException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowsDriverLoadFailedException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="exception">The inner exception thrown by the failure to load the driver.</param>
    internal WindowsDriverLoadFailedException(string message, Exception exception)
        : base(message, exception)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowsDriverLoadFailedException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    internal WindowsDriverLoadFailedException(string message)
        : base(message)
    {
    }
}
