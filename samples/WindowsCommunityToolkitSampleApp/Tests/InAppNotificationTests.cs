namespace WindowsCommunityToolkitSampleApp.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;

    [TestClass]
    public class InAppNotificationTests : BaseTestClass
    {
        private static InAppNotificationPage InAppNotificationPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            InAppNotificationPage = new AppPage().SelectSample<InAppNotificationPage>("InAppNotification");
        }

        [TestMethod]
        public void ShowAndDismissNotificationWithRandomText()
        {
            // Act & Assert
            InAppNotificationPage
                .ShowNotificationWithRandomText()
                .VerifyExampleInAppNotificationShown()
                .DismissExampleInAppNotification()
                .VerifyExampleInAppNotificationHidden();
        }

        [TestMethod]
        public void ShowAndDismissNotificationWithButtons()
        {
            // Act & Assert
            InAppNotificationPage
                .ShowNotificationWithButtons()
                .VerifyExampleInAppNotificationShown()
                .DismissExampleInAppNotification()
                .VerifyExampleInAppNotificationHidden();
        }

        [TestMethod]
        public void ShowAndDismissNotificationWithVSCodeTemplate()
        {
            // Act & Assert
            InAppNotificationPage
                .ShowNotificationWithVSCodeTemplate()
                .VerifyExampleVSCodeInAppNotificationShown()
                .DismissExampleVSCodeInAppNotification()
                .VerifyExampleVSCodeInAppNotificationHidden();
        }
    }
}