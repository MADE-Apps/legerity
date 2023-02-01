namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TextBoxPage : BaseNavigationPage
{
    public TextBoxPage(RemoteWebDriver app) : base(app)
    {
    }

    public TextBox SimpleTextBox => this.FindElement(By.Name("simple TextBox"));

    public TextBox ReadonlyTextBox => this.FindElement(By.Name("customized TextBox"));

    public TextBoxPage SetSimpleTextBox(string text)
    {
        this.SimpleTextBox.SetText(text);
        return this;
    }

    public TextBoxPage AppendSimpleTextBoxText(string text)
    {
        this.SimpleTextBox.AppendText(text);
        return this;
    }

    public TextBoxPage ClearSimpleTextBox()
    {
        this.SimpleTextBox.ClearText();
        return this;
    }
}