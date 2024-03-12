namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class RadioButtonPage : BaseNavigationPage
{
    public RadioButtonPage(WebDriver app) : base(app)
    {
    }

    public RadioButton OptionOneRadioButton => FindElement(By.Name("Option 1"));

    public RadioButton OptionTwoRadioButton => FindElement(By.Name("Option 2"));

    public RadioButtonPage ClickOptionOneRadioButton()
    {
        OptionOneRadioButton.Click();
        return this;
    }

    public RadioButtonPage ClickOptionTwoRadioButton()
    {
        OptionTwoRadioButton.Click();
        return this;
    }
}