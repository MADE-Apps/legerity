namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class ImagePage : W3SchoolsBasePage
{
    private readonly By imageLocator = By.TagName("img");

    public ImagePage(RemoteWebDriver app) : base(app)
    {
    }

    public Image Image => this.FindElement(this.imageLocator);
}