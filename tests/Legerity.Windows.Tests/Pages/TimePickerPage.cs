namespace Legerity.Windows.Tests.Pages;

using System;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TimePickerPage : BaseNavigationPage
{
    public TimePickerPage(RemoteWebDriver app) : base(app)
    {
    }

    public TimePicker TimePicker => this.FindElement(By.Name("time picker"));

    public TimePickerPage SetTimePickerTime(TimeSpan time)
    {
        this.TimePicker.SetTime(time);
        return this;
    }
}