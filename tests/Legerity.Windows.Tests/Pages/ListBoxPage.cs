namespace Legerity.Windows.Tests.Pages;

using Windows;
using Elements.Core;
using OpenQA.Selenium;

internal class ListBoxPage : BaseNavigationPage
{
    public ListBoxPage(WebDriver app) : base(app)
    {
    }

    public ListBox ColorListBox => FindElement(WindowsByExtras.AutomationId("ListBox1"));

    public ListBoxPage ClickColorItem(string color)
    {
        ColorListBox.ClickItem(color);
        return this;
    }

    public ListBoxPage ClickColorItemByPartialName(string color)
    {
        ColorListBox.ClickItemByPartialName(color);
        return this;
    }
}
