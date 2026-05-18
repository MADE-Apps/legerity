// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Extensions;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class ButtonPage : W3SchoolsBasePage
{
    private readonly By buttonLocator = By.TagName("button").WithText("Click Me!");

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