namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class CheckBoxPage : W3SchoolsBasePage
{
    private readonly By bikeCheckBoxLocator = By.Id("vehicle1");

    public CheckBoxPage(WebDriver app) : base(app)
    {
    }

    public CheckBox BikeCheckBox => FindElement(bikeCheckBoxLocator);

    public CheckBoxPage CheckBikeOn()
    {
        BikeCheckBox.CheckOn();
        return this;
    }

    public CheckBoxPage CheckBikeOff()
    {
        BikeCheckBox.CheckOff();
        return this;
    }
}