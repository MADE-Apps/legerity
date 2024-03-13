namespace Legerity.WinUI.Tests.Pages;

using Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

internal class MenuBarPage : BaseNavigationPage
{
    public MenuBarPage(WebDriver app) : base(app)
    {
    }

    public MenuBar SimpleMenuBar => FindElement(WindowsByExtras.AutomationId("Example1"));

    public MenuBarPage SelectSimpleMenuBarOption(string name, string child = null)
    {
        var option = SimpleMenuBar.ClickOption(name);
        if (!string.IsNullOrWhiteSpace(child))
        {
            option.ClickChildOption(child);
        }

        return this;
    }

    public MenuBarPage SelectSimpleMenuBarOptionPartial(string name, string child = null)
    {
        var option = SimpleMenuBar.ClickOptionByPartialName(name);
        if (!string.IsNullOrWhiteSpace(child))
        {
            option.ClickChildOptionByPartialName(child);
        }

        return this;
    }
}
