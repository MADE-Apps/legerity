namespace WebTests
{
    using System;
    using Legerity;
    using Legerity.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class EdgeBaseTestClass
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new WebAppManagerOptions(WebAppDriverType.EdgeChromium, Environment.CurrentDirectory)
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