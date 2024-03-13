namespace Legerity.Exceptions;

using System;

/// <summary>
/// Defines an exception for when expected elements are not shown.
/// </summary>
public class ElementsNotShownException : LegerityException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ElementsNotShownException"/> class.
    /// </summary>
    /// <param name="locator">
    /// The locator used to locate the element.
    /// </param>
    public ElementsNotShownException(string locator)
        : this(locator, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ElementsNotShownException"/> class.
    /// </summary>
    /// <param name="locator">
    /// The locator used to locate the element.
    /// </param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ElementsNotShownException(string locator, Exception innerException)
        : base($"No elements could be located using locator: {locator}", innerException)
    {
        Locator = locator;
    }

    /// <summary>
    /// Gets the locator used to locate the elements.
    /// </summary>
    public string Locator { get; }
}
