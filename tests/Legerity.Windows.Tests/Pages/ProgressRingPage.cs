
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class ProgressRingPage : BaseNavigationPage
{
    public ProgressRingPage(WebDriver app) : base(app)
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