// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class DateInputPage : W3SchoolsBasePage
{
    public DateInputPage(WebDriver app) : base(app)
    {
    }

    public DateInput DateInput => this.FindElement(By.Id("birthday"));

    public DateInputPage SetBirthdayDate(DateTime date)
    {
        this.DateInput.SetDate(date);
        return this;
    }
}