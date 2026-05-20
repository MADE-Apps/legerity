// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class RadioButtonPage : W3SchoolsBasePage
{
    private readonly By languageGroupRadioButtonLocator = By.XPath("//input[@name='fav_language']");

    private readonly By cssRadioButtonLocator = By.Id("css");

    public RadioButtonPage(WebDriver app) : base(app)
    {
    }

    public IEnumerable<RadioButton> LanguageGroupRadioButtons =>
        this.FindElements(this.languageGroupRadioButtonLocator).Select(e => (RadioButton)e);

    public RadioButton CssRadioButton => this.FindElement(this.cssRadioButtonLocator);

    public RadioButtonPage SelectCssRadioButton()
    {
        this.CssRadioButton.Click();
        return this;
    }
}