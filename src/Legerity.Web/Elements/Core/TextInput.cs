namespace Legerity.Web.Elements.Core;

using Legerity.Web.Elements;
using Legerity.Web.Extensions;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Input text control.
/// </summary>
public class TextInput : WebElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public TextInput(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public TextInput(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text input.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.GetValue();

    /// <summary>
    /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="TextInput"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextInput"/>.
    /// </returns>
    public static implicit operator TextInput(WebElement element)
    {
        return new TextInput(element);
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
        this.ClearText();
        this.AppendText(text);
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
        this.Click();
        this.Element.SendKeys(text);
    }

    /// <summary>
    /// Clears the text from the text box.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClearText()
    {
        this.Click();
        this.Element.Clear();
    }
}