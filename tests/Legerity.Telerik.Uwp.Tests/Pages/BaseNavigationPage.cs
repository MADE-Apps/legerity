namespace Legerity.Telerik.Uwp.Tests.Pages;

using System;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class BaseNavigationPage : BasePage
{
    private readonly By searchBoxLocator = By.Name("Search");

    public BaseNavigationPage(WebDriver app)
        : base(app)
    {
    }

    public TextBox SearchBox => this.FindElement(this.searchBoxLocator);

    protected override By Trait => this.searchBoxLocator;

    public TPage NavigateTo<TPage>(string controlName, string sampleName)
        where TPage : BasePage
    {
        this.SearchBox.SetText(controlName);

        WebElement item = this.FindElement(By.XPath($".//*[@ClassName='ListViewItem'][@Name='{sampleName}']"));
        item.Click();

        return Activator.CreateInstance(typeof(TPage), this.App) as TPage;
    }
}