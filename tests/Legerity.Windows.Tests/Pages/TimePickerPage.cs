using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class TimePickerPage : BaseNavigationPage
{
    public TimePickerPage(WebDriver app) : base(app)
    {
    }

    public TimePicker TimePicker => this.FindElement(By.Name("time picker"));

    public TimePickerPage SetTimePickerTime(TimeSpan time)
    {
        this.TimePicker.SetTime(time);
        return this;
    }
}