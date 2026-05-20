
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class ComboBoxPage : BaseNavigationPage
{
    private readonly By colorComboBox = By.Name("Colors");

    public ComboBoxPage(WebDriver app) : base(app)
    {
    }

    public ComboBox ColorComboBox => this.FindElement(this.colorComboBox);

    public ComboBoxPage SelectColorByName(string name)
    {
        this.ColorComboBox.SelectItem(name);
        return this;
    }

    public ComboBoxPage SelectColorByPartialName(string name)
    {
        this.ColorComboBox.SelectItemByPartialName(name);
        return this;
    }
}