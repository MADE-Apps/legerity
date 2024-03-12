namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class AutoSuggestBoxPage : BaseNavigationPage
{
    private readonly By basicAutoSuggestBoxLocator = By.Name("Basic AutoSuggestBox");

    public AutoSuggestBoxPage(WebDriver app) : base(app)
    {
    }

    public AutoSuggestBox BasicAutoSuggestBox => FindElement(basicAutoSuggestBoxLocator);

    protected override By Trait => By.XPath(".//*[@Name='AutoSuggestBox'][@AutomationId='TitleTextBlock']");

    public AutoSuggestBoxPage SetBasicSuggestionText(string text)
    {
        BasicAutoSuggestBox.SetText(text);
        return this;
    }

    public AutoSuggestBoxPage SelectBasicSuggestion(string suggestion)
    {
        BasicAutoSuggestBox.SelectSuggestion(suggestion);
        return this;
    }

    public AutoSuggestBoxPage SelectBasicSuggestionByValue(string searchValue, string suggestion)
    {
        BasicAutoSuggestBox.SelectSuggestion(searchValue, suggestion);
        return this;
    }

    public AutoSuggestBoxPage SelectBasicSuggestionByPartialSuggestion(string searchValue, string partialSuggestion)
    {
        BasicAutoSuggestBox.SelectSuggestionByPartialSuggestion(searchValue, partialSuggestion);
        return this;
    }
}
