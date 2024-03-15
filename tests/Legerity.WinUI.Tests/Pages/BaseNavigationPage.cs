namespace Legerity.WinUI.Tests.Pages;

using System;
using Windows.Elements.Core;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

internal class BaseNavigationPage : BasePage
{
    private readonly By _navigationViewLocator = WindowsByExtras.AutomationId("NavigationViewControl");

    public BaseNavigationPage(WebDriver app)
        : base(app)
    {
    }

    public NavigationView NavigationView => FindElement(_navigationViewLocator);

    public AutoSuggestBox ControlsSearchBox =>
        NavigationView.FindElement(WindowsByExtras.AutomationId("controlsSearchBox"));

    protected override By Trait => _navigationViewLocator;

    public TPage NavigateTo<TPage>(string controlName)
        where TPage : BasePage
    {
        ControlsSearchBox.SetText("J");
        ControlsSearchBox.SelectSuggestion(controlName);
        return Activator.CreateInstance(typeof(TPage), App) as TPage;
    }
}
