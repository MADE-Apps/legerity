// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class TextInputPage : W3SchoolsBasePage
{
    private readonly By firstNameInputLocator = By.Id("fname");

    public TextInputPage(WebDriver app) : base(app)
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