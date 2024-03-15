namespace Legerity.WinUI.Tests.Pages;

using Windows.Elements.WinUI;
using OpenQA.Selenium;

internal class NavigationViewPage : BaseNavigationPage
{
    public NavigationViewPage(WebDriver app) : base(app)
    {
    }

    public NavigationView NavigationView => FindElement(WindowsByExtras.AutomationId("nvSample5"));

    public NavigationViewPage OpenNavigationView()
    {
        NavigationView.OpenNavigationPane();
        return this;
    }

    public NavigationViewPage CloseNavigationView()
    {
        NavigationView.CloseNavigationPane();
        return this;
    }

    public NavigationViewPage SelectNavigationViewMenuOption(string name)
    {
        NavigationView.ClickMenuOption(name);
        return this;
    }

    public NavigationViewPage SelectNavigationViewMenuOptionByPartialName(string name)
    {
        NavigationView.ClickMenuOptionByPartialName(name);
        return this;
    }

    public NavigationViewPage OpenNavigationViewSettings()
    {
        NavigationView.OpenSettings();
        return this;
    }

    public NavigationViewPage GoBackInNavigationView()
    {
        NavigationView.GoBack();
        return this;
    }
}
