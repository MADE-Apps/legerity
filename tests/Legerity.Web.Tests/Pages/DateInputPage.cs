using System;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class DateInputPage : W3SchoolsBasePage
{
    public DateInputPage(WebDriver app) : base(app)
    {
    }

    public DateInput DateInput => FindElement(By.Id("birthday"));

    public DateInputPage SetBirthdayDate(DateTime date)
    {
        DateInput.SetDate(date);
        return this;
    }
}
