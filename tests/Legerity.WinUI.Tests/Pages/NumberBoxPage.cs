namespace Legerity.WinUI.Tests.Pages;

using Legerity.Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class NumberBoxPage : BaseNavigationPage
{
    public NumberBoxPage(WebDriver app) : base(app)
    {
    }

    public NumberBox SpinnerNumberBox => FindElement(WindowsByExtras.AutomationId("NumberBoxSpinButtonPlacementExample"));

    public NumberBoxPage SetSpinnerNumberBoxValue(double value)
    {
        SpinnerNumberBox.SetValue(value);
        return this;
    }

    public NumberBoxPage IncrementSpinnerNumberBoxValue()
    {
        SpinnerNumberBox.Increment();
        return this;
    }

    public NumberBoxPage DecrementSpinnerNumberBoxValue()
    {
        SpinnerNumberBox.Decrement();
        return this;
    }
}