namespace Legerity.Windows.Elements.Telerik;

using System;
using Legerity.Exceptions;
using Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Telerik UWP RadAutoCompleteBox control.
/// </summary>
public class RadAutoCompleteBox : WindowsElementWrapper
{
    private readonly By _suggestionsControlLocator = WindowsByExtras.AutomationId("PART_SuggestionsControl");

    /// <summary>
    /// Initializes a new instance of the <see cref="RadAutoCompleteBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public RadAutoCompleteBox(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the text box.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextBox TextBox => FindElement(By.ClassName("TextBox"));

    /// <summary>
    /// Gets the value of the auto-suggest box.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => TextBox.Text;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="RadAutoCompleteBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="RadAutoCompleteBox"/>.
    /// </returns>
    public static implicit operator RadAutoCompleteBox(WebElement element)
    {
        return new RadAutoCompleteBox(element);
    }
    
    /// <summary>
    /// Selects a suggestion from the auto-suggest box.
    /// </summary>
    /// <param name="suggestion">The suggestion to select.</param>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SelectSuggestion(string suggestion)
    {
        SelectSuggestion(suggestion, suggestion);
    }

    /// <summary>
    /// Selects a suggestion from the auto-suggest box.
    /// </summary>
    /// <param name="value">The initial value to set.</param>
    /// <param name="suggestion">The suggestion to select.</param>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SelectSuggestion(string value, string suggestion)
    {
        SetText(value);

        VerifyElementShown(_suggestionsControlLocator, TimeSpan.FromSeconds(2));

        ListBox suggestionList = FindElement(_suggestionsControlLocator);
        suggestionList.ClickItem(suggestion);
    }

    /// <summary>
    /// Selects a suggestion from the auto-suggest box.
    /// </summary>
    /// <param name="value">The initial value to set.</param>
    /// <param name="partialSuggestion">The partial suggestion match to select.</param>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SelectSuggestionByPartialSuggestion(string value, string partialSuggestion)
    {
        SetText(value);

        VerifyElementShown(_suggestionsControlLocator, TimeSpan.FromSeconds(2));

        ListBox suggestionList = FindElement(_suggestionsControlLocator);
        suggestionList.ClickItemByPartialName(partialSuggestion);
    }

    /// <summary>
    /// Sets the value of the auto-suggest box.
    /// </summary>
    /// <param name="value">The value to set.</param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void SetText(string value)
    {
        TextBox.SetText(value);
    }
}
