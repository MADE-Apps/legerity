using System;
using System.Linq;
using Legerity.Extensions;
using Legerity.Pages;
using Legerity.Windows;
using Legerity.Windows.Elements.Core;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

namespace Legerity.WCT.Tests.Pages;

internal class BaseNavigationPage : BasePage
{
    private readonly By _navigationViewLocator = WindowsByExtras.AutomationId("NavView");

    public BaseNavigationPage(WebDriver app)
        : base(app)
    {
    }

    public NavigationView NavigationView => FindElement(_navigationViewLocator);

    public AutoSuggestBox SampleSearchBox => NavigationView.FindElement(WindowsByExtras.AutomationId("SearchBox"));

    public GridView SamplePicker => FindElement(WindowsByExtras.AutomationId("SamplePickerGridView"));

    protected override By Trait => _navigationViewLocator;

    public TPage NavigateTo<TPage>(string sampleName)
        where TPage : BasePage
    {
        SampleSearchBox.SetText(sampleName);

        this.WaitUntil(p => p.SamplePicker.Items.Any(), WaitTimeout);

        var item = SamplePicker.Items.FirstOrDefault(i =>
            i.FindElement(By.XPath($".//*[@ClassName='TextBlock'][@Name='{sampleName}']")) != null);
        item.Click();

        return Activator.CreateInstance(typeof(TPage), App) as TPage;
    }
}
