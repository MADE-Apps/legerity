namespace Legerity.Exceptions;

using System;

/// <summary>
/// Defines an exception for when an element is not shown.
/// </summary>
public class ElementNotShownException : LegerityException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ElementNotShownException"/> class.
    /// </summary>
    /// <param name="locator">
    /// The locator used to locate the element.
    /// </param>
    public ElementNotShownException(string locator)
        : this(locator, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ElementNotShownException"/> class.
    /// </summary>
    /// <param name="locator">
    /// The locator used to locate the element.
    /// </param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ElementNotShownException(string locator, Exception innerException)
        : base($"No element could be located using locator: {locator}", innerException)
    {
        this.Locator = locator;
    }

    /// <summary>
    /// Gets the locator used to locate the element.
    /// </summary>
    public string Locator { get; }
}