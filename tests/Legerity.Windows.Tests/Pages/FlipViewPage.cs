namespace Legerity.Windows.Tests.Pages;

using System.Linq;
using Elements.Core;
using OpenQA.Selenium;

internal class FlipViewPage : BaseNavigationPage
{
    private readonly By _flipViewLocator = By.ClassName(nameof(FlipView));

    public FlipViewPage(WebDriver app) : base(app)
    {
    }

    public FlipView XamlFlipView => FindElements(_flipViewLocator).LastOrDefault();

    public FlipViewPage SelectXamlFlipViewItem(string name)
    {
        XamlFlipView.SelectItem(name);
        return this;
    }

    public FlipViewPage SelectXamlFlipViewItemByIndex(int index)
    {
        XamlFlipView.SelectItemByIndex(index);
        return this;
    }

    public FlipViewPage SelectNextXamlFlipViewItem()
    {
        XamlFlipView.SelectNext();
        return this;
    }

    public FlipViewPage SelectPreviousXamlFlipViewItem()
    {
        XamlFlipView.SelectPrevious();
        return this;
    }

    public FlipViewPage ClickNextXamlFlipViewItem()
    {
        XamlFlipView.NextButton.Click();
        return this;
    }

    public FlipViewPage ClickPreviousXamlFlipViewItem()
    {
        XamlFlipView.PreviousButton.Click();
        return this;
    }
}
