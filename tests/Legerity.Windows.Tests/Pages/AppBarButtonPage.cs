namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;

internal class AppBarButtonPage : BaseNavigationPage
{
    public AppBarButtonPage(WebDriver app) : base(app)
    {
    }

    public AppBarButton SymbolButton => FindElement(By.Name("SymbolIcon"));

    public AppBarButtonPage ClickSymbolButton()
    {
        SymbolButton.Click();
        return this;
    }
}
