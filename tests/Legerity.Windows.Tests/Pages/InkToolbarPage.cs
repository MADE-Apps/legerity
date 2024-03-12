namespace Legerity.Windows.Tests.Pages;

using Windows;
using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class InkToolbarPage : BaseNavigationPage
{
    public InkToolbarPage(WebDriver app) : base(app)
    {
    }

    public InkToolbar InkToolbar => FindElement(WindowsByExtras.AutomationId("inkToolbar"));

    public InkToolbarPage SelectBallpointPenColor(string color)
    {
        InkToolbar.SetBallpointPenColor(color);
        return this;
    }

    public InkToolbarPage SelectBallpointPenPartialColor(string color)
    {
        InkToolbar.SetBallpointPenColorByPartialName(color);
        return this;
    }

    public InkToolbarPage SelectPencilColor(string color)
    {
        InkToolbar.SetPencilColor(color);
        return this;
    }

    public InkToolbarPage SelectPencilPartialColor(string color)
    {
        InkToolbar.SetPencilColorByPartialName(color);
        return this;
    }

    public InkToolbarPage SelectHighlighterColor(string color)
    {
        InkToolbar.SetHighlighterColor(color);
        return this;
    }

    public InkToolbarPage SelectHighlighterPartialColor(string color)
    {
        InkToolbar.SetHighlighterColorByPartialName(color);
        return this;
    }
}
