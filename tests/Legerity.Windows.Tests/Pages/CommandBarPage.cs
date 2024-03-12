namespace Legerity.Windows.Tests.Pages;

using Legerity.Windows;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class CommandBarPage : BaseNavigationPage
{
    public CommandBarPage(WebDriver app) : base(app)
    {
    }

    public CommandBar PrimaryCommandBar => FindElement(WindowsByExtras.AutomationId("PrimaryCommandBar"));

    public CommandBarPage ClickPrimaryAddButton()
    {
        PrimaryCommandBar.ClickPrimaryButton("addButton");
        return this;
    }

    public CommandBarPage ClickPrimaryButton(string name)
    {
        PrimaryCommandBar.ClickPrimaryButtonByPartialName(name);
        return this;
    }

    public CommandBarPage ClickSecondarySettingsButton()
    {
        PrimaryCommandBar.ClickSecondaryButton("settingsButton");
        return this;
    }

    public CommandBarPage ClickSecondaryButton(string name)
    {
        PrimaryCommandBar.ClickSecondaryButtonByPartialName(name);
        return this;
    }
}