namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TextBlockPage : BaseNavigationPage
{
    public TextBlockPage(WebDriver app) : base(app)
    {
    }

    public TextBlock TextBlock => this.FindElement(By.Name("I am a TextBlock."));
}