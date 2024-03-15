using Legerity.Helpers;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Tests;

internal abstract class W3SchoolsBaseTestClass : BaseTestClass
{
    protected W3SchoolsBaseTestClass()
    {
    }

    protected W3SchoolsBaseTestClass(AppManagerOptions options)
        : base(options)
    {
    }

    protected WebDriver StartApp(AppManagerOptions options = default)
    {
        return StartApp(options ?? Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);
    }
}
