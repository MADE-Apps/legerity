namespace Legerity.Web.Elements.Core;

using Legerity.Web.Elements;
using Legerity.Web.Extensions;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Input file control.
/// </summary>
public class FileInput : WebElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public FileInput(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public FileInput(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the file path for the selected file.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string FilePath => this.GetValue();

    /// <summary>
    /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="FileInput"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="FileInput"/>.
    /// </returns>
    public static implicit operator FileInput(WebElement element)
    {
        return new FileInput(element);
    }

    /// <summary>
    /// Sets the selected file by an absolute file path.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SetAbsoluteFilePath(string filePath)
    {
        this.ClearFile();
        this.Element.SendKeys(filePath);
    }

    /// <summary>
    /// Clears the selected file.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClearFile()
    {
        this.Element.Clear();
    }
}