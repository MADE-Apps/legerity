namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class PasswordBoxPage : BaseNavigationPage
{
    public PasswordBoxPage(WebDriver app) : base(app)
    {
    }

    public PasswordBox PasswordBox => this.FindElement(By.Name("Password"));

    public PasswordBoxPage SetPassword(string password)
    {
        this.PasswordBox.SetText(password);
        return this;
    }
}