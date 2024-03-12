namespace Legerity.Windows.Elements.Core;

using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP TextBox control.
/// </summary>
public class TextBox : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public TextBox(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text box.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.GetValue();

    /// <summary>
    /// Gets a value indicating whether the text box is in a readonly state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsReadonly => this.IsReadonly();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="TextBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextBox"/>.
    /// </returns>
    public static implicit operator TextBox(WebElement element)
    {
        return new TextBox(element);
    }
    
    /// <summary>
    /// Sets the text of the text box to the specified text.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void SetText(string text)
    {
        ClearText();
        AppendText(text);
    }

    /// <summary>
    /// Appends the specified text to the text box.
    /// </summary>
    /// <param name="text">The text to append.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void AppendText(string text)
    {
        Element.SendKeys(text);
    }

    /// <summary>
    /// Clears the text from the text box.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClearText()
    {
        Element.Clear();
    }
}