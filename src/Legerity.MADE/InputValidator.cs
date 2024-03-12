namespace Legerity.Windows.Elements.MADE;

using Legerity.Windows.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the MADE.NET UWP InputValidator control.
/// </summary>
public class InputValidator : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InputValidator"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public InputValidator(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the <see cref="TextBlock"/> associated with the validation feedback message.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextBlock ValidationFeedback =>
        FindElement(WindowsByExtras.AutomationId("ValidatorFeedbackMessage"));

    /// <summary>
    /// Gets the validation feedback message associated with the <see cref="ValidationFeedback"/> element.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Message => ValidationFeedback?.Text;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="InputValidator"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InputValidator"/>.
    /// </returns>
    public static implicit operator InputValidator(WebElement element)
    {
        return new InputValidator(element);
    }
    
    /// <summary>
    /// Retrieves the input element with the given locator.
    /// </summary>
    /// <param name="locator">The locator to find the input element.</param>
    /// <returns>The <see cref="WebElement"/> if found; otherwise, throws <see cref="WebDriverException"/>.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public WebElement Input(By locator)
    {
        return FindElement(locator);
    }

    /// <summary>
    /// Retrieves the feedback message text if the <see cref="ValidationFeedback"/> is shown.
    /// </summary>
    /// <returns>The feedback message text of the <see cref="ValidationFeedback"/> element.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual string FeedbackMessage()
    {
        string message;

        try
        {
            message = ValidationFeedback.Text;
        }
        catch (WebDriverException ex) when (ex.Message.Contains("element could not be located"))
        {
            message = null;
        }

        return message;
    }
}