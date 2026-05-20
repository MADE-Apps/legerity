
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class ProgressBarPage : BaseNavigationPage
{
    public ProgressBarPage(WebDriver app) : base(app)
    {
    }

    public ProgressBar IndeterminateProgressBar => this.FindElement(By.Name("Busy"));

    public ProgressBar DeterminateProgressBar => this.FindElement(WindowsByExtras.AutomationId("ProgressBar2"));

    public NumberBox DeterminateProgressBarValue => this.FindElement(WindowsByExtras.AutomationId("ProgressValue"));

    public ProgressBarPage SetDeterminateProgressBarValue(int value)
    {
        this.DeterminateProgressBarValue.SetValue(value);
        return this;
    }
}