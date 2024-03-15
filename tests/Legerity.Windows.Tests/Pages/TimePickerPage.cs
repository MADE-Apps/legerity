namespace Legerity.Windows.Tests.Pages;

using System;
using Elements.Core;
using OpenQA.Selenium;

internal class TimePickerPage : BaseNavigationPage
{
    public TimePickerPage(WebDriver app) : base(app)
    {
    }

    public TimePicker TimePicker => FindElement(By.Name("time picker"));

    public TimePickerPage SetTimePickerTime(TimeSpan time)
    {
        TimePicker.SetTime(time);
        return this;
    }
}
