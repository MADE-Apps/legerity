namespace Legerity.Telerik.Uwp.Tests.Pages;

using System;
using System.Linq;
using Legerity.Extensions;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;

internal class BaseNavigationPage : BasePage
{
    private readonly By searchBoxLocator = By.Name("Search");

    public BaseNavigationPage(RemoteWebDriver app)
        : base(app)
    {
    }

    public TextBox SearchBox => this.FindElement(this.searchBoxLocator);

    public ListView SuggestionList => this.FindElement(WindowsByExtras.AutomationId("SuggestionList"));

    protected override By Trait => this.searchBoxLocator;

    public TPage NavigateTo<TPage>(string controlName, string sampleName)
        where TPage : BasePage
    {
        this.SearchBox.SetText(controlName);

        this.WaitUntil(p => p.SuggestionList.Items.Any(), this.WaitTimeout);

        AppiumWebElement item = this.SuggestionList.Items.FirstOrDefault(i =>
            i.FindElement(By.XPath($".//*[@ClassName='ListViewItem'][@Name='{sampleName}']")) != null);
        item.Click();

        return Activator.CreateInstance(typeof(TPage), this.App) as TPage;
    }
}