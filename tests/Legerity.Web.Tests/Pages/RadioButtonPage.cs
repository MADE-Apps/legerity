namespace Legerity.Web.Tests.Pages;

using System.Collections.Generic;
using System.Linq;
using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class RadioButtonPage : W3SchoolsBasePage
{
    private readonly By languageGroupRadioButtonLocator = By.XPath("//input[@name='fav_language']");

    private readonly By cssRadioButtonLocator = By.Id("css");

    public RadioButtonPage(WebDriver app) : base(app)
    {
    }

    public IEnumerable<RadioButton> LanguageGroupRadioButtons =>
        FindElements(languageGroupRadioButtonLocator).Select(e => (RadioButton)e);

    public RadioButton CssRadioButton => FindElement(cssRadioButtonLocator);

    public RadioButtonPage SelectCssRadioButton()
    {
        CssRadioButton.Click();
        return this;
    }
}