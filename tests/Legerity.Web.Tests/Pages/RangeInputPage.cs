// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class RangeInputPage : W3SchoolsBasePage
{
    private readonly By volumeRangeInputLocator = By.Id("vol");

    public RangeInputPage(WebDriver app) : base(app)
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