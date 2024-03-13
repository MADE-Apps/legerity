namespace Legerity.WinUI.Tests.Pages;

using Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;

internal class RatingControlPage : BaseNavigationPage
{
    public RatingControlPage(WebDriver app) : base(app)
    {
    }

    public RatingControl SimpleRatingControl => FindElement(WindowsByExtras.AutomationId("RatingControl1"));

    public RatingControlPage SetSimpleRatingValue(double value)
    {
        SimpleRatingControl.SetValue(value);
        return this;
    }
}
