namespace Legerity.WinUI.Tests.Pages;

using System;
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class BaseNavigationPage : BasePage
{
    private readonly By navigationViewLocator = WindowsByExtras.AutomationId("NavigationViewControl");

    public BaseNavigationPage(WebDriver app)
        : base(app)
    {
    }

    public NavigationView NavigationView => FindElement(navigationViewLocator);

    public AutoSuggestBox ControlsSearchBox =>
        NavigationView.FindElement(WindowsByExtras.AutomationId("controlsSearchBox"));

    protected override By Trait => navigationViewLocator;

    public TPage NavigateTo<TPage>(string controlName)
        where TPage : BasePage
    {
        ControlsSearchBox.SetText("J");
        ControlsSearchBox.SelectSuggestion(controlName);
        return Activator.CreateInstance(typeof(TPage), App) as TPage;
    }
}