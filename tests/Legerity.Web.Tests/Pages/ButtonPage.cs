using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class ButtonPage : W3SchoolsBasePage
{
    private readonly By _buttonLocator = By.TagName("button");

    public ButtonPage(WebDriver app)
        : base(app)
    {
    }

    public Button Button => FindElement(_buttonLocator);

    public ButtonPage ClickButton()
    {
        Button.Click();
        return this;
    }
}
