namespace Legerity.Windows.Tests.Pages;

using Legerity.Windows;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium.Remote;

internal class CommandBarPage : BaseNavigationPage
{
    public CommandBarPage(RemoteWebDriver app) : base(app)
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