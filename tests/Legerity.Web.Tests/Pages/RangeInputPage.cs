using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class RangeInputPage : W3SchoolsBasePage
{
    private readonly By _volumeRangeInputLocator = By.Id("vol");

    public RangeInputPage(WebDriver app) : base(app)
    {
    }

    public RangeInput VolumeRangeInput => FindElement(_volumeRangeInputLocator);

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
