namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class CheckBoxPage : BaseNavigationPage
{
    public CheckBoxPage(WebDriver app) : base(app)
    {
    }

    public CheckBox TwoStateCheckBox => FindElement(By.Name("Two-state CheckBox"));

    public CheckBox ThreeStateCheckBox => FindElement(By.Name("Three-state CheckBox"));

    public CheckBoxPage CheckOnTwoStateCheckBox()
    {
        TwoStateCheckBox.CheckOn();
        return this;
    }

    public CheckBoxPage CheckOffTwoStateCheckBox()
    {
        TwoStateCheckBox.CheckOff();
        return this;
    }

    public CheckBoxPage CheckIndeterminateThreeStateCheckBox()
    {
        while (!ThreeStateCheckBox.IsIndeterminate)
        {
            ThreeStateCheckBox.Click();
        }

        return this;
    }
}