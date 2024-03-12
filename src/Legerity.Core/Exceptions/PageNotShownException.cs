namespace Legerity.Exceptions;

/// <summary>
/// Defines an exception for when a page is not shown.
/// </summary>
public class PageNotShownException : LegerityException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PageNotShownException"/> class.
    /// </summary>
    /// <param name="pageName">
    /// The name of the page that was not shown.
    /// </param>
    internal PageNotShownException(string pageName)
        : base($"No page could be located for page: {pageName}")
    {
        PageName = pageName;
    }

    /// <summary>
    /// Gets the name of the page that was not shown.
    /// </summary>
    public string PageName { get; }
}