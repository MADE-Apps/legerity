using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class CommandBarPage : BaseNavigationPage
{
    public CommandBarPage(WebDriver app) : base(app)
    {
    }

    public CommandBar PrimaryCommandBar => this.FindElement(WindowsByExtras.AutomationId("PrimaryCommandBar"));

    public CommandBarPage ClickPrimaryAddButton()
    {
        this.PrimaryCommandBar.ClickPrimaryButton("addButton");
        return this;
    }

    public CommandBarPage ClickPrimaryButton(string name)
    {
        this.PrimaryCommandBar.ClickPrimaryButtonByPartialName(name);
        return this;
    }

    public CommandBarPage ClickSecondarySettingsButton()
    {
        this.PrimaryCommandBar.ClickSecondaryButton("settingsButton");
        return this;
    }

    public CommandBarPage ClickSecondaryButton(string name)
    {
        this.PrimaryCommandBar.ClickSecondaryButtonByPartialName(name);
        return this;
    }
}