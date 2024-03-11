namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using Elements.WinUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

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