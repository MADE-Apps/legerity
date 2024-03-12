namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class AppBarToggleButtonPage : BaseNavigationPage
{
    public AppBarToggleButtonPage(WebDriver app) : base(app)
    {
    }
    
    public AppBarToggleButton SymbolToggleButton => FindElement(By.Name("SymbolIcon"));

    protected override By Trait => By.XPath(".//*[@Name='AppBarToggleButton'][@AutomationId='TitleTextBlock']");

    public AppBarToggleButtonPage ToggleSymbolOn()
    {
        SymbolToggleButton.ToggleOn();
        return this;
    }

    public AppBarToggleButtonPage ToggleSymbolOff()
    {
        SymbolToggleButton.ToggleOff();
        return this;
    }
}
