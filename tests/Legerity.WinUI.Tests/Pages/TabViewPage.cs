namespace Legerity.WinUI.Tests.Pages;

using Windows.Elements.Core;
using Legerity.Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium.Remote;

internal class TabViewPage : BaseNavigationPage
{
    public TabViewPage(RemoteWebDriver app) : base(app)
    {
    }

    public ScrollViewer ScrollViewer => this.FindElement(WindowsByExtras.AutomationId("svPanel"));

    public TabView TabView => this.FindElement(WindowsByExtras.AutomationId("TabView1"));
    
    public TabViewPage SelectTab(string name)
    {
        this.ScrollViewer.ScrollToTop();
        this.TabView.SelectTab(name);
        return this;
    }

    public TabViewPage SelectTabByPartialName(string name)
    {
        this.ScrollViewer.ScrollToTop();
        this.TabView.SelectTabByPartialName(name);
        return this;
    }

    public TabViewPage CloseTab(string name)
    {
        this.ScrollViewer.ScrollToTop();
        this.TabView.CloseTab(name);
        return this;
    }

    public TabViewPage CloseTabByPartialName(string name)
    {
        this.ScrollViewer.ScrollToTop();
        this.TabView.CloseTabByPartialName(name);
        return this;
    }

    public TabViewPage CreateTab()
    {
        this.ScrollViewer.ScrollToTop();
        this.TabView.CreateTab();
        return this;
    }
}