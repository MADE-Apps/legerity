namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;

internal class PivotPage : BaseNavigationPage
{
    public PivotPage(WebDriver app) : base(app)
    {
    }

    public Pivot EmailPivot => FindElement(By.Name("EMAIL"));

    public PivotPage ClickEmailTab(string name)
    {
        EmailPivot.ClickItem(name);
        return this;
    }

    public PivotPage ClickEmailTabByPartialName(string name)
    {
        EmailPivot.ClickItemByPartialName(name);
        return this;
    }
}
