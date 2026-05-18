
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

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