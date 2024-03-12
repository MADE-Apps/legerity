namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class RangeInputPage : W3SchoolsBasePage
{
    private readonly By volumeRangeInputLocator = By.Id("vol");

    public RangeInputPage(WebDriver app) : base(app)
    {
    }

    public RangeInput VolumeRangeInput => FindElement(volumeRangeInputLocator);

    public RangeInputPage SetVolume(int volume)
    {
        VolumeRangeInput.SetValue(volume);
        return this;
    }

    public RangeInputPage IncrementVolume()
    {
        VolumeRangeInput.Increment();
        return this;
    }

    public RangeInputPage DecrementVolume()
    {
        VolumeRangeInput.Decrement();
        return this;
    }
}