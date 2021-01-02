namespace TelerikUwpSdkSample.Pages
{
    using System;
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using OpenQA.Selenium;

    public class ListPage : BasePage
    {
        protected override By Trait => By.ClassName("ListView");

        public ListView List => this.WindowsApp.FindElement(this.Trait);

        public TPage Select<TPage>(string name)
        {
            this.List.ClickItem(name);
            return Activator.CreateInstance<TPage>();
        }
    }
}
