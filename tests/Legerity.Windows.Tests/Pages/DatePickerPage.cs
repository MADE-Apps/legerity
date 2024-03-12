namespace Legerity.Windows.Tests.Pages;

using System;
using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class DatePickerPage : BaseNavigationPage
{
    private readonly By simpleDatePicker = By.XPath(".//*[@ClassName='DatePicker'][@Name='Pick a date']");

    public DatePickerPage(WebDriver app) : base(app)
    {
    }

    public DatePicker SimpleDatePicker => FindElement(simpleDatePicker);

    public DatePickerPage SetSimpleDatePickerDate(DateTime date)
    {
        SimpleDatePicker.SetDate(date);
        return this;
    }
}
