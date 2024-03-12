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

    public NavigationView NavigationView => FindElement(navigationViewLocator);

    public AutoSuggestBox SampleSearchBox => NavigationView.FindElement(WindowsByExtras.AutomationId("SearchBox"));

    public GridView SamplePicker => FindElement(WindowsByExtras.AutomationId("SamplePickerGridView"));

    protected override By Trait => navigationViewLocator;

    public TPage NavigateTo<TPage>(string sampleName)
        where TPage : BasePage
    {
        SampleSearchBox.SetText(sampleName);

        this.WaitUntil(p => p.SamplePicker.Items.Any(), WaitTimeout);

        WebElement item = SamplePicker.Items.FirstOrDefault(i =>
            i.FindElement(By.XPath($".//*[@ClassName='TextBlock'][@Name='{sampleName}']")) != null);
        item.Click();

        return Activator.CreateInstance(typeof(TPage), App) as TPage;
    }
}