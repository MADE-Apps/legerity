namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class CheckBoxPage : BaseNavigationPage
{
    public CheckBoxPage(WebDriver app) : base(app)
    {
    }

    public CheckBox TwoStateCheckBox => this.FindElement(By.Name("Two-state CheckBox"));

    public CheckBox ThreeStateCheckBox => this.FindElement(By.Name("Three-state CheckBox"));

    public CheckBoxPage CheckOnTwoStateCheckBox()
    {
        this.TwoStateCheckBox.CheckOn();
        return this;
    }

    public CheckBoxPage CheckOffTwoStateCheckBox()
    {
        this.TwoStateCheckBox.CheckOff();
        return this;
    }

    public CheckBoxPage CheckIndeterminateThreeStateCheckBox()
    {
        while (!this.ThreeStateCheckBox.IsIndeterminate)
        {
            this.ThreeStateCheckBox.Click();
        }

        return this;
    }
}