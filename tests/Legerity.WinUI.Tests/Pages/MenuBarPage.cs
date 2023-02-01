namespace Legerity.WinUI.Tests.Pages;

using Legerity.Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium.Remote;

internal class MenuBarPage : BaseNavigationPage
{
    public MenuBarPage(RemoteWebDriver app) : base(app)
    {
    }

    public MenuBar SimpleMenuBar => this.FindElement(WindowsByExtras.AutomationId("Example1"));

    public MenuBarPage SelectSimpleMenuBarOption(string name, string child = null)
    {
        MenuBarItem option = this.SimpleMenuBar.ClickOption(name);
        if (!string.IsNullOrWhiteSpace(child))
        {
            option.ClickChildOption(child);
        }

        return this;
    }

    public MenuBarPage SelectSimpleMenuBarOptionPartial(string name, string child = null)
    {
        MenuBarItem option = this.SimpleMenuBar.ClickOptionByPartialName(name);
        if (!string.IsNullOrWhiteSpace(child))
        {
            option.ClickChildOptionByPartialName(child);
        }

        return this;
    }
}