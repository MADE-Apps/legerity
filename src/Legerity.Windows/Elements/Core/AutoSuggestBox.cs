namespace Legerity.Windows.Elements.Core;

using System;
using Legerity.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP AutoSuggestBox control.
/// </summary>
public class AutoSuggestBox : WindowsElementWrapper
{
    private readonly By suggestionsPopupLocator = WindowsByExtras.AutomationId("SuggestionsPopup");

    /// <summary>
    /// Initializes a new instance of the <see cref="AutoSuggestBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public AutoSuggestBox(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the suggestions popup.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual AppiumWebElement SuggestionsPopup => this.FindElement(this.suggestionsPopupLocator);

    /// <summary>
    /// Gets the element associated with the suggestion list when the <see cref="SuggestionsPopup"/> is shown.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ListView SuggestionList => this.SuggestionsPopup.FindElement(WindowsByExtras.AutomationId("SuggestionsList"));

    /// <summary>
    /// Gets the element associated with the text box.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextBox TextBox => this.FindElement(WindowsByExtras.AutomationId("TextBox"));

    /// <summary>
    /// Gets the value of the auto-suggest box.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.TextBox.Text;

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="AutoSuggestBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="AutoSuggestBox"/>.
    /// </returns>
    public static implicit operator AutoSuggestBox(WindowsElement element)
    {
        return new AutoSuggestBox(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="AutoSuggestBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="AutoSuggestBox"/>.
    /// </returns>
    public static implicit operator AutoSuggestBox(AppiumWebElement element)
    {
        return new AutoSuggestBox(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="AutoSuggestBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="AutoSuggestBox"/>.
    /// </returns>
    public static implicit operator AutoSuggestBox(RemoteWebElement element)
    {
        return new AutoSuggestBox(element as WindowsElement);
    }

    /// <summary>
    /// Selects a suggestion from the auto-suggest box.
    /// </summary>
    /// <param name="suggestion">The suggestion to select.</param>
    /// <exception cref="ElementNotShownException">Thrown when the suggestions popup is not shown.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectSuggestion(string suggestion)
    {
        this.SelectSuggestion(suggestion, suggestion);
    }

    /// <summary>
    /// Selects a suggestion from the auto-suggest box.
    /// </summary>
    /// <param name="value">The initial value to set.</param>
    /// <param name="suggestion">The suggestion to select.</param>
    /// <param name="popupWaitTimeout">The timeout to wait for the suggestions popup to appear. Defaults to 2000ms.</param>
    /// <exception cref="ElementNotShownException">Thrown when the suggestions popup is not shown.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectSuggestion(string value, string suggestion, int popupWaitTimeout = 2000)
    {
        this.SetText(value);

        this.VerifyElementShown(this.suggestionsPopupLocator, TimeSpan.FromMilliseconds(popupWaitTimeout));

        this.SuggestionList.ClickItem(suggestion);
    }

    /// <summary>
    /// Selects a suggestion from the auto-suggest box.
    /// </summary>
    /// <param name="value">The initial value to set.</param>
    /// <param name="partialSuggestion">The partial suggestion match to select.</param>
    /// <param name="popupWaitTimeout">The timeout to wait for the suggestions popup to appear. Defaults to 2000ms.</param>
    /// <exception cref="ElementNotShownException">Thrown when the suggestions popup is not shown.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectSuggestionByPartialSuggestion(string value, string partialSuggestion, int popupWaitTimeout = 2000)
    {
        this.SetText(value);

        this.VerifyElementShown(this.suggestionsPopupLocator, TimeSpan.FromMilliseconds(popupWaitTimeout));

        this.SuggestionList.ClickItemByPartialName(partialSuggestion);
    }

    /// <summary>
    /// Sets the value of the auto-suggest box.
    /// </summary>
    /// <param name="value">The value to set.</param>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SetText(string value)
    {
        this.TextBox.SetText(value);
    }
}