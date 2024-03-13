namespace Legerity.Windows.Tests.Pages;

using System;
using Elements.Core;
using OpenQA.Selenium;

internal class DatePickerPage : BaseNavigationPage
{
    private readonly By _simpleDatePicker = By.XPath(".//*[@ClassName='DatePicker'][@Name='Pick a date']");

    public DatePickerPage(WebDriver app) : base(app)
    {
    }

    public DatePicker SimpleDatePicker => FindElement(_simpleDatePicker);

    public DatePickerPage SetSimpleDatePickerDate(DateTime date)
    {
        SimpleDatePicker.SetDate(date);
        return this;
    }
}
