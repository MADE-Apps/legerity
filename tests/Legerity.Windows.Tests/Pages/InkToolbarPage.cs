namespace Legerity.Windows.Tests.Pages;

using Legerity.Windows;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class InkToolbarPage : BaseNavigationPage
{
    public InkToolbarPage(WebDriver app) : base(app)
    {
    }

    public InkToolbar InkToolbar => this.FindElement(WindowsByExtras.AutomationId("inkToolbar"));

    public InkToolbarPage SelectBallpointPenColor(string color)
    {
        this.InkToolbar.SetBallpointPenColor(color);
        return this;
    }

    public InkToolbarPage SelectBallpointPenPartialColor(string color)
    {
        this.InkToolbar.SetBallpointPenColorByPartialName(color);
        return this;
    }

    public InkToolbarPage SelectPencilColor(string color)
    {
        this.InkToolbar.SetPencilColor(color);
        return this;
    }

    public InkToolbarPage SelectPencilPartialColor(string color)
    {
        this.InkToolbar.SetPencilColorByPartialName(color);
        return this;
    }

    public InkToolbarPage SelectHighlighterColor(string color)
    {
        this.InkToolbar.SetHighlighterColor(color);
        return this;
    }

    public InkToolbarPage SelectHighlighterPartialColor(string color)
    {
        this.InkToolbar.SetHighlighterColorByPartialName(color);
        return this;
    }
}