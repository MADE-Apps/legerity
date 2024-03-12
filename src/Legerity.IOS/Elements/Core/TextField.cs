namespace Legerity.IOS.Elements.Core;

using Elements;
using Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core iOS TextField control.
/// </summary>
public class TextField : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextField"/> class.
    /// </summary>
    /// <param name="element">The <see cref="WebElement"/> representing the <see cref="TextField"/> element.</param>
    public TextField(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text field.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.GetValue();

    /// <summary>
    /// Gets the element associated with the clear text button, if shown.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button ClearTextButton => FindElement(IOSByExtras.Label("Clear text"));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="TextField"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextField"/>.
    /// </returns>
    public static implicit operator TextField(WebElement element)
    {
        return new TextField(element);
    }
    
    /// <summary>
    /// Sets the text of the text field to the specified text.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SetText(string text)
    {
        ClearText();
        AppendText(text);
    }

    /// <summary>
    /// Appends the specified text to the text field.
    /// </summary>
    /// <param name="text">The text to append.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void AppendText(string text)
    {
        Click();
        Element.SendKeys(text);
    }

    /// <summary>
    /// Clears the text from the text field.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClearText()
    {
        Click();
        Element.Clear();
    }
}
