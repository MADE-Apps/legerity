namespace Legerity.Android.Elements.Core;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="AndroidElement"/> wrapper for the core Android EditText control.
/// </summary>
public class EditText : AndroidElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EditText"/> class.
    /// </summary>
    /// <param name="element">The <see cref="AndroidElement"/> representing the <see cref="EditText"/> element.</param>
    public EditText(AndroidElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text box.
    /// </summary>
    public virtual string Text => this.Element.Text;

    /// <summary>
    /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="EditText"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="EditText"/>.
    /// </returns>
    public static implicit operator EditText(AndroidElement element)
    {
        return new EditText(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="EditText"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="EditText"/>.
    /// </returns>
    public static implicit operator EditText(AppiumWebElement element)
    {
        return new EditText(element as AndroidElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="EditText"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="EditText"/>.
    /// </returns>
    public static implicit operator EditText(RemoteWebElement element)
    {
        return new EditText(element as AndroidElement);
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