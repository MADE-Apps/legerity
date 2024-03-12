namespace Legerity.WinUI.Tests.Pages;

using Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class InfoBarPage : BaseNavigationPage
{
    public InfoBarPage(WebDriver app) : base(app)
    {
    }

    public InfoBar CloseableInfoBar => FindElement(WindowsByExtras.AutomationId("TestInfoBar1"));

    public InfoBarPage CloseClosableInfoBar()
    {
        CloseableInfoBar.Close();
        return this;
    }
}
