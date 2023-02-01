namespace Legerity.Web.Tests.Tests;

using Legerity.Helpers;
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

    protected RemoteWebDriver StartApp(AppManagerOptions options = default)
    {
        return this.StartApp(options ?? this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);
    }
}