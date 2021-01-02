namespace TelerikUwpSdkSample.Pages.BulletGraph
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Telerik;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;

    public class CustomizationsPage : BasePage
    {
        public RadBulletGraph BulletGraph => this.WindowsApp.FindElementByAutomationId("bullet");

        protected override By Trait => By.XPath(".//*[@Name='Customizations']");
    }
}
