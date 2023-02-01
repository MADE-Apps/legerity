namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class CheckBoxPage : W3SchoolsBasePage
{
    private readonly By bikeCheckBoxLocator = By.Id("vehicle1");

    public CheckBoxPage(RemoteWebDriver app) : base(app)
    {
    }

    public CheckBox BikeCheckBox => this.FindElement(this.bikeCheckBoxLocator);

    public CheckBoxPage CheckBikeOn()
    {
        this.BikeCheckBox.CheckOn();
        return this;
    }

    public CheckBoxPage CheckBikeOff()
    {
        this.BikeCheckBox.CheckOff();
        return this;
    }
}