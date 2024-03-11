namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class AppBarButtonPage : BaseNavigationPage
{
    public AppBarButtonPage(WebDriver app) : base(app)
    {
    }

    public AppBarButton SymbolButton => this.FindElement(By.Name("SymbolIcon"));

    public AppBarButtonPage ClickSymbolButton()
    {
        this.SymbolButton.Click();
        return this;
    }
}