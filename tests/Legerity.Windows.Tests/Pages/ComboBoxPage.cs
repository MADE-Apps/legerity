namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;

internal class ComboBoxPage : BaseNavigationPage
{
    private readonly By _colorComboBox = By.Name("Colors");

    public ComboBoxPage(WebDriver app) : base(app)
    {
    }

    protected override By Trait => By.XPath(".//*[@Name='ComboBox'][@AutomationId='TitleTextBlock']");

    public ComboBox ColorComboBox => FindElement(_colorComboBox);

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
