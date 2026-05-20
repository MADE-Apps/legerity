using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

namespace Legerity.WinUI.Tests.Pages;

internal class NavigationViewPage : BaseNavigationPage
{
    public NavigationViewPage(WebDriver app) : base(app)
    {
    }

    public NavigationView NavigationView => this.FindElement(WindowsByExtras.AutomationId("nvSample5"));

    public NavigationViewPage OpenNavigationView()
    {
        this.NavigationView.OpenNavigationPane();
        return this;
    }

    public NavigationViewPage CloseNavigationView()
    {
        this.NavigationView.CloseNavigationPane();
        return this;
    }

    public NavigationViewPage SelectNavigationViewMenuOption(string name)
    {
        this.NavigationView.ClickMenuOption(name);
        return this;
    }

    public NavigationViewPage SelectNavigationViewMenuOptionByPartialName(string name)
    {
        this.NavigationView.ClickMenuOptionByPartialName(name);
        return this;
    }

    public NavigationViewPage OpenNavigationViewSettings()
    {
        this.NavigationView.OpenSettings();
        return this;
    }

    public NavigationViewPage GoBackInNavigationView()
    {
        this.NavigationView.GoBack();
        return this;
    }
}