// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class CheckBoxPage : W3SchoolsBasePage
{
    private readonly By bikeCheckBoxLocator = By.Id("vehicle1");

    public CheckBoxPage(WebDriver app) : base(app)
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