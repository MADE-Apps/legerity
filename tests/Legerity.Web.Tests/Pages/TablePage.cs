using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class TablePage : W3SchoolsBasePage
{
    private readonly By _tableLocator = By.TagName("table");

    public TablePage(WebDriver app) : base(app)
    {
    }

    public Table Table => FindElement(_tableLocator);
}
