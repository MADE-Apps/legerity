
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

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