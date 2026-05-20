using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

namespace Legerity.WinUI.Tests.Pages;

internal class RatingControlPage : BaseNavigationPage
{
    public RatingControlPage(WebDriver app) : base(app)
    {
    }

    public RatingControl SimpleRatingControl => this.FindElement(WindowsByExtras.AutomationId("RatingControl1"));

    public RatingControlPage SetSimpleRatingValue(double value)
    {
        this.SimpleRatingControl.SetValue(value);
        return this;
    }
}