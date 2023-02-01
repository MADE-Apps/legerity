namespace Legerity.Windows.Tests.Pages;

using System.Linq;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class FlipViewPage : BaseNavigationPage
{
    private readonly By flipViewLocator = By.ClassName(nameof(FlipView));

    public FlipViewPage(RemoteWebDriver app) : base(app)
    {
    }

    public FlipView XamlFlipView => this.FindElements(this.flipViewLocator).LastOrDefault();

    public FlipViewPage SelectXamlFlipViewItem(string name)
    {
        this.XamlFlipView.SelectItem(name);
        return this;
    }

    public FlipViewPage SelectXamlFlipViewItemByIndex(int index)
    {
        this.XamlFlipView.SelectItemByIndex(index);
        return this;
    }

    public FlipViewPage SelectNextXamlFlipViewItem()
    {
        this.XamlFlipView.SelectNext();
        return this;
    }

    public FlipViewPage SelectPreviousXamlFlipViewItem()
    {
        this.XamlFlipView.SelectPrevious();
        return this;
    }

    public FlipViewPage ClickNextXamlFlipViewItem()
    {
        this.XamlFlipView.NextButton.Click();
        return this;
    }

    public FlipViewPage ClickPreviousXamlFlipViewItem()
    {
        this.XamlFlipView.PreviousButton.Click();
        return this;
    }
}