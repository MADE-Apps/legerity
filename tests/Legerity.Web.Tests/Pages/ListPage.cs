namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class ListPage : W3SchoolsBasePage
{
    private readonly By orderedListLocator = By.TagName("ol");

    public ListPage(RemoteWebDriver app) : base(app)
    {
    }

    public List OrderedList => this.FindElements(this.orderedListLocator).FirstOrDefault();
}