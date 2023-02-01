namespace Legerity.WinUI.Tests.Pages;

using Legerity.Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium.Remote;

internal class NumberBoxPage : BaseNavigationPage
{
    public NumberBoxPage(RemoteWebDriver app) : base(app)
    {
    }

    public NumberBox SpinnerNumberBox => this.FindElement(WindowsByExtras.AutomationId("NumberBoxSpinButtonPlacementExample"));

    public NumberBoxPage SetSpinnerNumberBoxValue(double value)
    {
        this.SpinnerNumberBox.SetValue(value);
        return this;
    }

    public NumberBoxPage IncrementSpinnerNumberBoxValue()
    {
        this.SpinnerNumberBox.Increment();
        return this;
    }

    public NumberBoxPage DecrementSpinnerNumberBoxValue()
    {
        this.SpinnerNumberBox.Decrement();
        return this;
    }
}