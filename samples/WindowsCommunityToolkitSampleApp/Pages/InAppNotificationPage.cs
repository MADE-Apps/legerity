namespace WindowsCommunityToolkitSampleApp.Pages
{
    using System.Linq;
    using Elements;
    using Legerity.Exceptions;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.WCT;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the InAppNotification page of the Windows Community Toolkit sample application.
    /// </summary>
    public class InAppNotificationPage : AppPage
    {
        private readonly By exampleInAppNotificationQuery = ByExtensions.AutomationId("ExampleInAppNotification");

        private readonly By exampleCodeInAppNotificationQuery =
            ByExtensions.AutomationId("ExampleVSCodeInAppNotification");

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@ClassName='TextBlock'][@Name='InAppNotification']");

        /// <summary>
        /// Gets the example in-app notification element.
        /// </summary>
        public InAppNotification ExampleInAppNotification =>
            this.WindowsApp.FindElement(this.exampleInAppNotificationQuery);

        /// <summary>
        /// Gets the example VS Code in-app notification element.
        /// </summary>
        public VsCodeInAppNotification ExampleVSCodeInAppNotification =>
            this.WindowsApp.FindElement(this.exampleCodeInAppNotificationQuery);

        public Button NotificationWithRandomTextButton => this.WindowsApp.FindElements(By.ClassName("Button"))
            .FirstOrDefault(x => x.GetAttribute("Name") == "Show notification with random text");

        public Button NotificationWithButtonsButton => this.WindowsApp.FindElements(By.ClassName("Button"))
            .FirstOrDefault(x => x.GetAttribute("Name") == "Show notification with buttons (without DataTemplate)");

        public Button NotificationWithVSCodeTemplateButton => this.WindowsApp.FindElements(By.ClassName("Button"))
            .FirstOrDefault(x => x.GetAttribute("Name") == "Show notification with Visual Studio Code template (info notification)");

        public InAppNotificationPage ShowNotificationWithRandomText()
        {
            this.NotificationWithRandomTextButton.Click();
            return this;
        }

        public InAppNotificationPage ShowNotificationWithButtons()
        {
            this.NotificationWithButtonsButton.Click();
            return this;
        }

        public InAppNotificationPage ShowNotificationWithVSCodeTemplate()
        {
            this.NotificationWithVSCodeTemplateButton.Click();
            return this;
        }

        public InAppNotificationPage VerifyExampleInAppNotificationShown()
        {
            if (!this.ExampleInAppNotification.IsVisible)
            {
                throw new ElementNotShownException(this.exampleInAppNotificationQuery.ToString());
            }

            return this;
        }

        public InAppNotificationPage DismissExampleInAppNotification()
        {
            this.ExampleInAppNotification.Dismiss();
            return this;
        }

        public InAppNotificationPage VerifyExampleInAppNotificationHidden()
        {
            if (this.ExampleInAppNotification.IsVisible)
            {
                throw new ElementShownException(this.exampleInAppNotificationQuery.ToString());
            }

            return this;
        }

        public InAppNotificationPage VerifyExampleVSCodeInAppNotificationShown()
        {
            if (!this.ExampleVSCodeInAppNotification.IsVisible)
            {
                throw new ElementNotShownException(this.exampleCodeInAppNotificationQuery.ToString());
            }

            return this;
        }

        public InAppNotificationPage DismissExampleVSCodeInAppNotification()
        {
            this.ExampleVSCodeInAppNotification.Dismiss();
            return this;
        }

        public InAppNotificationPage VerifyExampleVSCodeInAppNotificationHidden()
        {
            if (this.ExampleVSCodeInAppNotification.IsVisible)
            {
                throw new ElementShownException(this.exampleCodeInAppNotificationQuery.ToString());
            }

            return this;
        }
    }
}