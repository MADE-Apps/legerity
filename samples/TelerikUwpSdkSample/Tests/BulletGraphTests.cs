namespace TelerikUwpSdkSample.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;
    using Pages.BulletGraph;
    using Shouldly;

    [TestClass]
    public class BulletGraphTests : BaseTestClass
    {
        private static CustomizationsPage CustomizationsPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            CustomizationsPage = new ControlsPage().GoToBulletGraph().GoToCustomizations();
        }

        [TestMethod]
        public void VerifyValue()
        {
            const double value = 95;
            const double min = 50;
            const double max = 200;

            CustomizationsPage.BulletGraph.Value.ShouldBe(value);
            CustomizationsPage.BulletGraph.Minimum.ShouldBe(min);
            CustomizationsPage.BulletGraph.Maximum.ShouldBe(max);
        }
    }
}