// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class OptionPage : W3SchoolsBasePage
{
    private readonly By carOptionLocator = By.TagName("option");

    public OptionPage(WebDriver app) : base(app)
    {
    }

    public IEnumerable<Option> CarOptions => this.FindElements(this.carOptionLocator).Select(e => (Option)e);

    public OptionPage SelectCarOptionByDisplayValue(string option)
    {
        this.CarOptions.FirstOrDefault(o => o.DisplayValue == option).Select();
        return this;
    }

    public OptionPage SelectCarOptionByValue(string option)
    {
        this.CarOptions.FirstOrDefault(o => o.Value == option).Select();
        return this;
    }
}