namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using Elements.WinUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class ProgressRingPage : BaseNavigationPage
{
    public ProgressRingPage(RemoteWebDriver app) : base(app)
    {
    }

    public ProgressRing IndeterminateProgressRing => this.FindElement(By.Name("Busy Progress image"));

    public ProgressRing DeterminateProgressRing => this.FindElement(WindowsByExtras.AutomationId("ProgressRing2"));

    public NumberBox DeterminateProgressRingValue => this.FindElement(WindowsByExtras.AutomationId("ProgressValue"));

    public ProgressRingPage SetDeterminateProgressRingValue(int value)
    {
        this.DeterminateProgressRingValue.SetValue(value);
        return this;
    }
}