namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class GridViewPage : BaseNavigationPage
{
    public GridViewPage(WebDriver app) : base(app)
    {
    }

    public GridView BasicGridView => this.FindElement(WindowsByExtras.AutomationId("BasicGridView"));

    public GridViewPage ClickBasicGridViewItem(string name)
    {
        this.BasicGridView.ClickItem(name);
        return this;
    }

    public GridViewPage ClickBasicGridViewItemByPartialName(string name)
    {
        this.BasicGridView.ClickItemByPartialName(name);
        return this;
    }

    public GridViewPage ClickBasicGridViewItemByIndex(int index)
    {
        this.BasicGridView.ClickItemByIndex(index);
        return this;
    }
}