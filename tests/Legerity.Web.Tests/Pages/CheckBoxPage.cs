using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class CheckBoxPage : W3SchoolsBasePage
{
    private readonly By _bikeCheckBoxLocator = By.Id("vehicle1");

    public CheckBoxPage(WebDriver app) : base(app)
    {
    }

    public CheckBox BikeCheckBox => FindElement(_bikeCheckBoxLocator);

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
