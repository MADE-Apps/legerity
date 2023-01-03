namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class RangeInputPage : W3SchoolsBasePage
{
    private readonly By volumeRangeInputLocator = By.Id("vol");

    public RangeInputPage(RemoteWebDriver app) : base(app)
    {
    }

    public RangeInput VolumeRangeInput => this.FindElement(this.volumeRangeInputLocator);

    public RangeInputPage SetVolume(int volume)
    {
        this.VolumeRangeInput.SetValue(volume);
        return this;
    }

    public RangeInputPage IncrementVolume()
    {
        this.VolumeRangeInput.Increment();
        return this;
    }

    public RangeInputPage DecrementVolume()
    {
        this.VolumeRangeInput.Decrement();
        return this;
    }
}