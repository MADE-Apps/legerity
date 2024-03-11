namespace Legerity.Windows.Tests.Pages;

using System;
using Elements.Core;
using Elements.WinUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class BaseNavigationPage : BasePage
{
    private readonly By navigationViewLocator = WindowsByExtras.AutomationId("NavigationViewControl");

    public BaseNavigationPage(WebDriver app)
        : base(app)
    {
    }

    public NavigationView NavigationView => this.FindElement(this.navigationViewLocator);

    public AutoSuggestBox ControlsSearchBox =>
        this.NavigationView.FindElement(WindowsByExtras.AutomationId("controlsSearchBox"));

    protected override By Trait => this.navigationViewLocator;

    public TPage NavigateTo<TPage>(string controlName)
        where TPage : BasePage
    {
        this.ControlsSearchBox.SetText("J");
        this.ControlsSearchBox.SelectSuggestion(controlName);
        return Activator.CreateInstance(typeof(TPage), this.App) as TPage;
    }
}