using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class TextInputPage : W3SchoolsBasePage
{
    private readonly By _firstNameInputLocator = By.Id("fname");

    public TextInputPage(WebDriver app) : base(app)
    {
    }

    public TextInput FirstNameInput => FindElement(_firstNameInputLocator);

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
