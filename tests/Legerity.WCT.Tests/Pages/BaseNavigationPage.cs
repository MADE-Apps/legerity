namespace Legerity.WCT.Tests.Pages;

using System;
using System.Linq;
using Extensions;
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;

internal class BaseNavigationPage : BasePage
{
    private readonly By navigationViewLocator = WindowsByExtras.AutomationId("NavView");

    public BaseNavigationPage(WebDriver app)
        : base(app)
    {
    }

    public NavigationView NavigationView => this.FindElement(this.navigationViewLocator);

    public AutoSuggestBox SampleSearchBox => this.NavigationView.FindElement(WindowsByExtras.AutomationId("SearchBox"));

    public GridView SamplePicker => this.FindElement(WindowsByExtras.AutomationId("SamplePickerGridView"));

    protected override By Trait => this.navigationViewLocator;

    public TPage NavigateTo<TPage>(string sampleName)
        where TPage : BasePage
    {
        this.SampleSearchBox.SetText(sampleName);

        this.WaitUntil(p => p.SamplePicker.Items.Any(), this.WaitTimeout);

        WebElement item = this.SamplePicker.Items.FirstOrDefault(i =>
            i.FindElement(By.XPath($".//*[@ClassName='TextBlock'][@Name='{sampleName}']")) != null);
        item.Click();

        return Activator.CreateInstance(typeof(TPage), this.App) as TPage;
    }
}