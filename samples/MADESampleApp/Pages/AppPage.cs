namespace MADESampleApp.Pages
{
    using System;
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.MADE;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;

    public class AppPage : BasePage
    {
        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => ByExtensions.AutomationId("DropDownList");

        public InputValidator TextInputValidator =>
            this.WindowsApp.FindElement(ByExtensions.AutomationId("TextBoxValidator"));

        public TextBox TextInput => this.TextInputValidator.Input(ByExtensions.AutomationId("TextBox"));

        public InputValidator DateInputValidator =>
            this.WindowsApp.FindElement(ByExtensions.AutomationId("DatePickerValidator"));

        public DatePicker DateInput => this.DateInputValidator.Input(ByExtensions.AutomationId("DatePicker"));

        public void SetTextBoxText(string text)
        {
            this.TextInput.SetText(text);
        }

        public void SetDatePickerDate(DateTime date)
        {
            this.DateInput.SetDate(date);
        }
    }
}
