namespace Legerity.WinUI.Tests.Pages;

using Legerity.Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

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