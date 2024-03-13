namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using Elements.WinUI;
using OpenQA.Selenium;

internal class ProgressRingPage : BaseNavigationPage
{
    public ProgressRingPage(WebDriver app) : base(app)
    {
    }

    public ProgressRing IndeterminateProgressRing => FindElement(By.Name("Busy Progress image"));

    public ProgressRing DeterminateProgressRing => FindElement(WindowsByExtras.AutomationId("ProgressRing2"));

    public NumberBox DeterminateProgressRingValue => FindElement(WindowsByExtras.AutomationId("ProgressValue"));

    public ProgressRingPage SetDeterminateProgressRingValue(int value)
    {
        DeterminateProgressRingValue.SetValue(value);
        return this;
    }
}
