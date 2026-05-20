
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class TextBlockPage : BaseNavigationPage
{
    public TextBlockPage(WebDriver app) : base(app)
    {
    }

    public TextBlock TextBlock => this.FindElement(By.Name("I am a TextBlock."));
}