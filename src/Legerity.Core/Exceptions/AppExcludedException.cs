// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Exceptions;
/// <summary>
/// Defines an exception thrown when a test is excluded for the current application based on an <see cref="AppExclusionAttribute"/>.
/// </summary>
/// <remarks>
/// This is the default exception thrown by <see cref="LegerityTestClass.IgnoreTest(string)"/>.
/// Test framework-specific base classes should override <see cref="LegerityTestClass.IgnoreTest(string)"/>
/// to convert this into a framework-specific skip/ignore call.
/// </remarks>
public class AppExcludedException : LegerityException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppExcludedException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    internal AppExcludedException(string message)
        : base(message)
    {
    }
}
