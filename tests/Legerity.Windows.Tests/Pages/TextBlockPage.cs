namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;

internal class TextBlockPage : BaseNavigationPage
{
    public TextBlockPage(WebDriver app) : base(app)
    {
    }

    public TextBlock TextBlock => FindElement(By.Name("I am a TextBlock."));
}
