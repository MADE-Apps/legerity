namespace WebTests.Tests.Edge
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;

    [TestClass]
    public class HomePageTests : EdgeBaseTestClass
    {
        private HomePage Homepage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.Homepage = new HomePage();
        }

        [TestMethod]
        public void ReadHeroPost()
        {
            this.Homepage.NavigateToHeroPost().ReadPost(1);
        }
    }
}
