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

    public RadioButtonPage(RemoteWebDriver app) : base(app)
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