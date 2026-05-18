// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class SelectPage : W3SchoolsBasePage
{
    private readonly By carsSelectLocator = By.Id("cars");

    public SelectPage(WebDriver app) : base(app)
    {
    }

    public Select CarsSelect => this.FindElement(this.carsSelectLocator);

    public SelectPage SelectCarByDisplayValue(string car)
    {
        this.CarsSelect.SelectOptionByDisplayValue(car);
        return this;
    }

    public SelectPage SelectCarByValue(string car)
    {
        this.CarsSelect.SelectOptionByValue(car);
        return this;
    }

    public SelectPage SelectCarByPartialDisplayValue(string car)
    {
        this.CarsSelect.SelectOptionByPartialDisplayValue(car);
        return this;
    }

    public SelectPage SelectCarByPartialValue(string car)
    {
        this.CarsSelect.SelectOptionByPartialValue(car);
        return this;
    }
}