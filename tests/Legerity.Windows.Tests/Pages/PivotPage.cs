
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class PivotPage : BaseNavigationPage
{
    public PivotPage(WebDriver app) : base(app)
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