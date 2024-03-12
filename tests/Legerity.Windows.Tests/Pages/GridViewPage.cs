namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class GridViewPage : BaseNavigationPage
{
    public GridViewPage(WebDriver app) : base(app)
    {
    }

    public GridView BasicGridView => FindElement(WindowsByExtras.AutomationId("BasicGridView"));

    public GridViewPage ClickBasicGridViewItem(string name)
    {
        BasicGridView.ClickItem(name);
        return this;
    }

    public GridViewPage ClickBasicGridViewItemByPartialName(string name)
    {
        BasicGridView.ClickItemByPartialName(name);
        return this;
    }

    public GridViewPage ClickBasicGridViewItemByIndex(int index)
    {
        BasicGridView.ClickItemByIndex(index);
        return this;
    }
}