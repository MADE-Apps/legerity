using System.Linq;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class ListPage : W3SchoolsBasePage
{
    private readonly By _orderedListLocator = By.TagName("ol");

    public ListPage(WebDriver app) : base(app)
    {
    }

    public List OrderedList => FindElements(_orderedListLocator).FirstOrDefault();
}
