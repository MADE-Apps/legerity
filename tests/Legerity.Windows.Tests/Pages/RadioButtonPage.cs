namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class RadioButtonPage : BaseNavigationPage
{
    public RadioButtonPage(RemoteWebDriver app) : base(app)
    {
    }

    public RadioButton OptionOneRadioButton => this.FindElement(By.Name("Option 1"));

    public RadioButton OptionTwoRadioButton => this.FindElement(By.Name("Option 2"));

    public RadioButtonPage ClickOptionOneRadioButton()
    {
        this.OptionOneRadioButton.Click();
        return this;
    }

    public RadioButtonPage ClickOptionTwoRadioButton()
    {
        this.OptionTwoRadioButton.Click();
        return this;
    }
}