namespace Legerity.Web.Tests.Tests;

using Legerity.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

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