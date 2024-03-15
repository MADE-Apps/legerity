using System;
using Legerity.Pages;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Telerik.Uwp.Tests.Pages;

internal class BaseNavigationPage : BasePage
{
    private readonly By _searchBoxLocator = By.Name("Search");

    public BaseNavigationPage(WebDriver app)
        : base(app)
    {
    }

    public TextBox SearchBox => FindElement(_searchBoxLocator);

    protected override By Trait => _searchBoxLocator;

    public TPage NavigateTo<TPage>(string controlName, string sampleName)
        where TPage : BasePage
    {
        SearchBox.SetText(controlName);

        var item = FindElement(By.XPath($".//*[@ClassName='ListViewItem'][@Name='{sampleName}']"));
        item.Click();

        return Activator.CreateInstance(typeof(TPage), App) as TPage;
    }
}
