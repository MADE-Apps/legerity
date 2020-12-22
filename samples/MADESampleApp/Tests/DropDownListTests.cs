namespace MADESampleApp.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;

    [TestClass]
    public class DropDownListTests : BaseTestClass
    {
        private static AppPage AppPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            AppPage = new AppPage();
        }

        [TestMethod]
        public void SelectItems()
        {
            var items = new List<string> {"Hello", "List"};
            AppPage.SetDropDownListItems(items);
        }
    }
}