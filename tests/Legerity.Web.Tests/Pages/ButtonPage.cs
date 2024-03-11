namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class ButtonPage : W3SchoolsBasePage
{
    private readonly By buttonLocator = By.TagName("button");

    public ButtonPage(WebDriver app)
        : base(app)
    {
    }

    public Button Button => this.FindElement(this.buttonLocator);

    public ButtonPage ClickButton()
    {
        this.Button.Click();
        return this;
    }
}