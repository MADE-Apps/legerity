namespace TelerikUwpSdkSample.Pages.AutoCompleteBox
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Telerik;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using Shouldly;

    public class FilterSettingsPage : BasePage
    {
        public RadAutoCompleteBox AutoCompleteBox => this.WindowsApp.FindElementByAutomationId("autoComplete");

        protected override By Trait => By.XPath(".//*[@Name='Filter Settings']");

        public FilterSettingsPage SetText(string expectedText)
        {
            this.AutoCompleteBox.SetText(expectedText);
            return this;
        }

        public FilterSettingsPage SelectSuggestion(string value, string expectedSuggestion)
        {
            this.AutoCompleteBox.SelectSuggestion(value, expectedSuggestion);
            return this;
        }

        public void VerifyValue(string expectedText)
        {
            this.AutoCompleteBox.Text.ShouldBe(expectedText);
        }
    }
}
