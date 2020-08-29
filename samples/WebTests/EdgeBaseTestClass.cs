namespace WebTests
{
    using System;
    using System.IO;
    using Legerity;
    using Legerity.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class EdgeBaseTestClass
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new WebAppManagerOptions(WebAppDriverType.Edge,
                    Path.Combine(Environment.CurrentDirectory, "Tools\\Edge"))
                {
                    Maximize = true,
                    Url = "https://www.jamescroft.co.uk"
                });
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            AppManager.StopApp();
        }
    }
}