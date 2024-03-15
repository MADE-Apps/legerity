using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class ImagePage : W3SchoolsBasePage
{
    private readonly By _imageLocator = By.TagName("img");

    public ImagePage(WebDriver app) : base(app)
    {
    }

    public Image Image => FindElement(_imageLocator);
}
