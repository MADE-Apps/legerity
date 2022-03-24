namespace MADESampleApp.Pages
{
    using System;
    using System.Collections.Generic;
    using Legerity.Pages;
    using Legerity.Windows;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.MADE;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;

    public class AppPage : BasePage
    {
        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => WindowsByExtras.AutomationId("DropDownList");

        public InputValidator TextInputValidator =>
            this.WindowsApp.FindElement(WindowsByExtras.AutomationId("TextBoxValidator"));

        public TextBox TextInput => this.TextInputValidator.Input(WindowsByExtras.AutomationId("TextBox"));

        public InputValidator DateInputValidator =>
            this.WindowsApp.FindElement(WindowsByExtras.AutomationId("DatePickerValidator"));

        public DatePicker DateInput => this.DateInputValidator.Input(WindowsByExtras.AutomationId("DatePicker"));

        public DropDownList DropDownList => this.WindowsApp.FindElementByAutomationId("DropDownList");

        public void SetTextBoxText(string text)
        {
            this.TextInput.SetText(text);
        }

        public void SetDatePickerDate(DateTime date)
        {
            this.DateInput.SetDate(date);
        }

        public void SetDropDownListItems(IEnumerable<string> items)
        {
            foreach (string item in items)
            {
                this.DropDownList.SelectItem(item);
            }
        }
    }
}
