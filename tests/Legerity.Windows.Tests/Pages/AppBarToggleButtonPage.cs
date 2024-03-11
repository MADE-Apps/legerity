namespace Legerity.Windows.Tests.Pages;

using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class AppBarToggleButtonPage : BaseNavigationPage
{
    public AppBarToggleButtonPage(WebDriver app) : base(app)
    {
    }
    
    public AppBarToggleButton SymbolToggleButton => this.FindElement(By.Name("SymbolIcon"));

    protected override By Trait => By.XPath(".//*[@Name='AppBarToggleButton'][@AutomationId='TitleTextBlock']");

    public AppBarToggleButtonPage ToggleSymbolOn()
    {
        this.SymbolToggleButton.ToggleOn();
        return this;
    }

    public AppBarToggleButtonPage ToggleSymbolOff()
    {
        this.SymbolToggleButton.ToggleOff();
        return this;
    }
}