using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class ListBoxPage : BaseNavigationPage
{
    public ListBoxPage(WebDriver app) : base(app)
    {
    }

    public ListBox ColorListBox => this.FindElement(WindowsByExtras.AutomationId("ListBox1"));

    public ListBoxPage ClickColorItem(string color)
    {
        this.ColorListBox.ClickItem(color);
        return this;
    }

    public ListBoxPage ClickColorItemByPartialName(string color)
    {
        this.ColorListBox.ClickItemByPartialName(color);
        return this;
    }
}