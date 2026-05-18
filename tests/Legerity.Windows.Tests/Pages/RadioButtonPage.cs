
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class RadioButtonPage : BaseNavigationPage
{
    public RadioButtonPage(WebDriver app) : base(app)
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