namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TextInputPage : W3SchoolsBasePage
{
    private readonly By firstNameInputLocator = By.Id("fname");

    public TextInputPage(RemoteWebDriver app) : base(app)
    {
    }

    public TextInput FirstNameInput => this.FindElement(this.firstNameInputLocator);

    public TextInputPage SetFirstName(string firstName)
    {
        this.FirstNameInput.SetText(firstName);
        return this;
    }

    public TextInputPage AppendFirstName(string firstName)
    {
        this.FirstNameInput.AppendText(firstName);
        return this;
    }

    public TextInputPage ClearFirstName()
    {
        this.FirstNameInput.ClearText();
        return this;
    }
}