namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TextBoxPage : BaseNavigationPage
{
    public TextBoxPage(WebDriver app) : base(app)
    {
    }

    public TextBox SimpleTextBox => FindElement(By.Name("simple TextBox"));

    public TextBox ReadonlyTextBox => FindElement(By.Name("customized TextBox"));

    public TextBoxPage SetSimpleTextBox(string text)
    {
        SimpleTextBox.SetText(text);
        return this;
    }

    public TextBoxPage AppendSimpleTextBoxText(string text)
    {
        SimpleTextBox.AppendText(text);
        return this;
    }

    public TextBoxPage ClearSimpleTextBox()
    {
        SimpleTextBox.ClearText();
        return this;
    }
}