using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

namespace Legerity.WinUI.Tests.Pages;

internal class InfoBarPage : BaseNavigationPage
{
    public InfoBarPage(WebDriver app) : base(app)
    {
    }

    public InfoBar CloseableInfoBar => this.FindElement(WindowsByExtras.AutomationId("TestInfoBar1"));

    public InfoBarPage CloseClosableInfoBar()
    {
        this.CloseableInfoBar.Close();
        return this;
    }
}