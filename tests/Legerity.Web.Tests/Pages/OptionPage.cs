using System.Collections.Generic;
using System.Linq;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class OptionPage : W3SchoolsBasePage
{
    private readonly By _carOptionLocator = By.TagName("option");

    public OptionPage(WebDriver app) : base(app)
    {
    }

    public IEnumerable<Option> CarOptions => FindElements(_carOptionLocator).Select(e => (Option)e);

    public OptionPage SelectCarOptionByDisplayValue(string option)
    {
        CarOptions.FirstOrDefault(o => o.DisplayValue == option).Select();
        return this;
    }

    public OptionPage SelectCarOptionByValue(string option)
    {
        CarOptions.FirstOrDefault(o => o.Value == option).Select();
        return this;
    }
}
