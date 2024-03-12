namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TextInputPage : W3SchoolsBasePage
{
    private readonly By firstNameInputLocator = By.Id("fname");

    public TextInputPage(WebDriver app) : base(app)
    {
    }

    public TextInput FirstNameInput => FindElement(firstNameInputLocator);

    public TextInputPage SetFirstName(string firstName)
    {
        FirstNameInput.SetText(firstName);
        return this;
    }

    public TextInputPage AppendFirstName(string firstName)
    {
        FirstNameInput.AppendText(firstName);
        return this;
    }

    public TextInputPage ClearFirstName()
    {
        FirstNameInput.ClearText();
        return this;
    }
}