namespace Legerity.Windows.Tests.Pages;

using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class ComboBoxPage : BaseNavigationPage
{
    private readonly By colorComboBox = By.Name("Colors");

    public ComboBoxPage(WebDriver app) : base(app)
    {
    }

    protected override By Trait => By.XPath(".//*[@Name='ComboBox'][@AutomationId='TitleTextBlock']");

    public ComboBox ColorComboBox => FindElement(colorComboBox);

    public ComboBoxPage SelectColorByName(string name)
    {
        ColorComboBox.SelectItem(name);
        return this;
    }

    public ComboBoxPage SelectColorByPartialName(string name)
    {
        ColorComboBox.SelectItemByPartialName(name);
        return this;
    }
}