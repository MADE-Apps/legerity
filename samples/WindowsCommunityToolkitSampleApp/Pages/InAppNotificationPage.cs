namespace WindowsCommunityToolkitSampleApp.Pages
{
    using System.Linq;
    using Elements;
    using Legerity.Exceptions;
    using Legerity.Extensions;
    using Legerity.Windows;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.WCT;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the InAppNotification page of the Windows Community Toolkit sample application.
    /// </summary>
    public class InAppNotificationPage : AppPage
    {
        private readonly By exampleInAppNotificationLocator = WindowsByExtras.AutomationId("ExampleInAppNotification");

        private readonly By exampleCodeInAppNotificationLocator =
            WindowsByExtras.AutomationId("ExampleVSCodeInAppNotification");

        /// <summary>
        /// Gets the example in-app notification element.
        /// </summary>
        public InAppNotification ExampleInAppNotification =>
            this.WindowsApp.FindElement(this.exampleInAppNotificationLocator);

        /// <summary>
        /// Gets the example VS Code in-app notification element.
        /// </summary>
        public VsCodeInAppNotification ExampleVSCodeInAppNotification =>
            this.WindowsApp.FindElement(this.exampleCodeInAppNotificationLocator);

        public Button NotificationWithRandomTextButton => this.WindowsApp.FindElements(By.ClassName(nameof(Button)))
            .FirstOrDefault(x => x.GetName() == "Show notification with random text");

        public Button NotificationWithButtonsButton => this.WindowsApp.FindElements(By.ClassName(nameof(Button)))
            .FirstOrDefault(x => x.GetName() == "Show notification with buttons (without DataTemplate)");

        public Button NotificationWithVSCodeTemplateButton => this.WindowsApp.FindElements(By.ClassName(nameof(Button)))
            .FirstOrDefault(x => x.GetName() == "Show notification with Visual Studio Code template (info notification)");

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@ClassName='TextBlock'][@Name='InAppNotification']");

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
                throw new ElementNotShownException(this.exampleInAppNotificationLocator.ToString());
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
            this.VerifyElementNotShown(this.exampleInAppNotificationLocator);
            return this;
        }

        public InAppNotificationPage VerifyExampleVSCodeInAppNotificationShown()
        {
            if (!this.ExampleVSCodeInAppNotification.IsVisible)
            {
                throw new ElementNotShownException(this.exampleCodeInAppNotificationLocator.ToString());
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
            this.VerifyElementNotShown(this.exampleCodeInAppNotificationLocator);
            return this;
        }
    }
}