using System.Collections.Generic;
using System.Linq;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class RadioButtonPage : W3SchoolsBasePage
{
    private readonly By _languageGroupRadioButtonLocator = By.XPath("//input[@name='fav_language']");

    private readonly By _cssRadioButtonLocator = By.Id("css");

    public RadioButtonPage(WebDriver app) : base(app)
    {
    }

    public IEnumerable<RadioButton> LanguageGroupRadioButtons =>
        FindElements(_languageGroupRadioButtonLocator).Select(e => (RadioButton)e);

    public RadioButton CssRadioButton => FindElement(_cssRadioButtonLocator);

    public RadioButtonPage SelectCssRadioButton()
    {
        CssRadioButton.Click();
        return this;
    }
}
