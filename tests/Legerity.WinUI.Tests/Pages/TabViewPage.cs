namespace Legerity.WinUI.Tests.Pages;

using Windows.Elements.Core;
using Legerity.Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TabViewPage : BaseNavigationPage
{
    public TabViewPage(WebDriver app) : base(app)
    {
    }

    public ScrollViewer ScrollViewer => FindElement(WindowsByExtras.AutomationId("svPanel"));

    public TabView TabView => FindElement(WindowsByExtras.AutomationId("TabView1"));
    
    public TabViewPage SelectTab(string name)
    {
        ScrollViewer.ScrollToTop();
        TabView.SelectTab(name);
        return this;
    }

    public TabViewPage SelectTabByPartialName(string name)
    {
        ScrollViewer.ScrollToTop();
        TabView.SelectTabByPartialName(name);
        return this;
    }

    public TabViewPage CloseTab(string name)
    {
        ScrollViewer.ScrollToTop();
        TabView.CloseTab(name);
        return this;
    }

    public TabViewPage CloseTabByPartialName(string name)
    {
        ScrollViewer.ScrollToTop();
        TabView.CloseTabByPartialName(name);
        return this;
    }

    public TabViewPage CreateTab()
    {
        ScrollViewer.ScrollToTop();
        TabView.CreateTab();
        return this;
    }
}