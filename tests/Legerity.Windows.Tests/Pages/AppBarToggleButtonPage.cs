
using Legerity.Extensions;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class AppBarToggleButtonPage : BaseNavigationPage
{
    public AppBarToggleButtonPage(WebDriver app) : base(app)
    {
    }

    public AppBarToggleButton SymbolToggleButton => this.FindElement(Trait);

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