namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TablePage : W3SchoolsBasePage
{
    private readonly By tableLocator = By.TagName("table");

    public TablePage(WebDriver app) : base(app)
    {
    }

    public Table Table => FindElement(tableLocator);
}