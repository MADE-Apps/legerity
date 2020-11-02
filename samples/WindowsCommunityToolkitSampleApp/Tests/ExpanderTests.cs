namespace WindowsCommunityToolkitSampleApp.Tests
{
    using WindowsCommunityToolkitSampleApp;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;

    [TestClass]
    public class ExpanderTests : BaseTestClass
    {
        private static ExpanderPage ExpanderPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            ExpanderPage = new AppPage().SelectSample<ExpanderPage>("Expander");
        }

        [TestMethod]
        public void SetVerticalExpanderExpanded()
        {
            // Arrange
            const bool expectedState = true;

            // Act
            ExpanderPage.ToggleVerticalExpander(expectedState);

            // Assert
            ExpanderPage.VerifyVerticalExpanderState(expectedState);
        }

        [TestMethod]
        public void SetVerticalExpanderCollapsed()
        {
            // Arrange
            const bool expectedState = false;

            // Act
            ExpanderPage.ToggleVerticalExpander(expectedState);

            // Assert
            ExpanderPage.VerifyVerticalExpanderState(expectedState);
        }

        [TestMethod]
        public void SetHorizontalExpanderExpanded()
        {
            // Arrange
            const bool expectedState = true;

            // Act
            ExpanderPage.ToggleHorizontalExpander(expectedState);

            // Assert
            ExpanderPage.VerifyHorizontalExpanderState(expectedState);
        }

        [TestMethod]
        public void SetHorizontalExpanderCollapsed()
        {
            // Arrange
            const bool expectedState = false;

            // Act
            ExpanderPage.ToggleHorizontalExpander(expectedState);

            // Assert
            ExpanderPage.VerifyHorizontalExpanderState(expectedState);
        }
    }
}