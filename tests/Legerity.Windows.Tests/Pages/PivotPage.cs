namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class PivotPage : BaseNavigationPage
{
    public PivotPage(RemoteWebDriver app) : base(app)
    {
    }

    public Pivot EmailPivot => this.FindElement(By.Name("EMAIL"));

    public PivotPage ClickEmailTab(string name)
    {
        this.EmailPivot.ClickItem(name);
        return this;
    }

    public PivotPage ClickEmailTabByPartialName(string name)
    {
        this.EmailPivot.ClickItemByPartialName(name);
        return this;
    }
}