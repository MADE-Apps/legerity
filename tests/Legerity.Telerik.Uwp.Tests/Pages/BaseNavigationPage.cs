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

    public TextBox SearchBox => FindElement(searchBoxLocator);

    protected override By Trait => searchBoxLocator;

    public TPage NavigateTo<TPage>(string controlName, string sampleName)
        where TPage : BasePage
    {
        SearchBox.SetText(controlName);

        WebElement item = FindElement(By.XPath($".//*[@ClassName='ListViewItem'][@Name='{sampleName}']"));
        item.Click();

        return Activator.CreateInstance(typeof(TPage), App) as TPage;
    }
}