using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class SelectPage : W3SchoolsBasePage
{
    private readonly By _carsSelectLocator = By.Id("cars");

    public SelectPage(WebDriver app) : base(app)
    {
    }

    public Select CarsSelect => FindElement(_carsSelectLocator);

    public SelectPage SelectCarByDisplayValue(string car)
    {
        CarsSelect.SelectOptionByDisplayValue(car);
        return this;
    }

    public SelectPage SelectCarByValue(string car)
    {
        CarsSelect.SelectOptionByValue(car);
        return this;
    }

    public SelectPage SelectCarByPartialDisplayValue(string car)
    {
        CarsSelect.SelectOptionByPartialDisplayValue(car);
        return this;
    }

    public SelectPage SelectCarByPartialValue(string car)
    {
        CarsSelect.SelectOptionByPartialValue(car);
        return this;
    }
}
