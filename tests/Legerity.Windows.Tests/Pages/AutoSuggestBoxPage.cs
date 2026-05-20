
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class AutoSuggestBoxPage : BaseNavigationPage
{
    private readonly By basicAutoSuggestBoxLocator = By.Name("Basic AutoSuggestBox");

    public AutoSuggestBoxPage(WebDriver app) : base(app)
    {
    }

    public AutoSuggestBox BasicAutoSuggestBox => this.FindElement(this.basicAutoSuggestBoxLocator);

    public AutoSuggestBoxPage SetBasicSuggestionText(string text)
    {
        this.BasicAutoSuggestBox.SetText(text);
        return this;
    }

    public AutoSuggestBoxPage SelectBasicSuggestion(string suggestion)
    {
        this.BasicAutoSuggestBox.SelectSuggestion(suggestion);
        return this;
    }

    public AutoSuggestBoxPage SelectBasicSuggestionByValue(string searchValue, string suggestion)
    {
        this.BasicAutoSuggestBox.SelectSuggestion(searchValue, suggestion);
        return this;
    }

    public AutoSuggestBoxPage SelectBasicSuggestionByPartialSuggestion(string searchValue, string partialSuggestion)
    {
        this.BasicAutoSuggestBox.SelectSuggestionByPartialSuggestion(searchValue, partialSuggestion);
        return this;
    }
}