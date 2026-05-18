using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class DatePickerPage : BaseNavigationPage
{
    private readonly By simpleDatePicker = By.XPath(".//*[@ClassName='DatePicker'][@Name='Pick a date']");

    public DatePickerPage(WebDriver app) : base(app)
    {
    }

    public DatePicker SimpleDatePicker => this.FindElement(this.simpleDatePicker);

    public DatePickerPage SetSimpleDatePickerDate(DateTime date)
    {
        this.SimpleDatePicker.SetDate(date);
        return this;
    }
}