namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using Elements.WinUI;
using OpenQA.Selenium;

internal class ProgressBarPage : BaseNavigationPage
{
    public ProgressBarPage(WebDriver app) : base(app)
    {
    }

    public ProgressBar IndeterminateProgressBar => FindElement(By.Name("Busy"));

    public ProgressBar DeterminateProgressBar => FindElement(WindowsByExtras.AutomationId("ProgressBar2"));

    public NumberBox DeterminateProgressBarValue => FindElement(WindowsByExtras.AutomationId("ProgressValue"));

    public ProgressBarPage SetDeterminateProgressBarValue(int value)
    {
        DeterminateProgressBarValue.SetValue(value);
        return this;
    }
}
