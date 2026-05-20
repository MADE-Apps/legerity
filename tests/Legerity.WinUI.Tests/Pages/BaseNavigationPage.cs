using Legerity.Windows.Elements.Core;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

namespace Legerity.WinUI.Tests.Pages;

internal class BaseNavigationPage : BasePage
{
    private readonly By navigationViewLocator = WindowsByExtras.AutomationId("NavigationViewControl");

    public BaseNavigationPage(WebDriver app)
        : base(app)
    {
    }

    public NavigationView NavigationView => this.FindElement(this.navigationViewLocator);

    public AutoSuggestBox ControlsSearchBox =>
        this.FindElement(WindowsByExtras.AutomationId("controlsSearchBox"));

    protected override By Trait => this.navigationViewLocator;

    public TPage NavigateTo<TPage>(string controlName)
        where TPage : BasePage
    {
        this.ControlsSearchBox.SetText("J");
        this.ControlsSearchBox.SelectSuggestion(controlName);
        return Activator.CreateInstance(typeof(TPage), this.App) as TPage;
    }
}